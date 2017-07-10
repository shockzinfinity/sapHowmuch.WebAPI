using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataHandler.Encoder;
using sapHowmuch.Api.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class RefreshTokenManager : IDisposable
	{
		private ApplicationDbContext _context;

		public RefreshTokenManager(ApplicationDbContext dbContext)
		{
			this._context = dbContext;
		}

		public static RefreshTokenManager Create(IdentityFactoryOptions<RefreshTokenManager> options, IOwinContext context)
		{
			return new RefreshTokenManager(context.Get<ApplicationDbContext>());
		}

		public IEnumerable<Client> GetClients()
		{
			return _context.Clients.ToList();
		}

		public IEnumerable<Client> GetAllowedClients()
		{
			return _context.Clients.Where(x => x.Active);
		}

		public Client FindClient(string clientId)
		{
			var client = _context.Clients.Find(clientId);

			return client;
		}

		public async Task<Client> AddClientAsync(ClientBindingModel clientModel)
		{
			var key = new byte[32];
			RNGCryptoServiceProvider.Create().GetBytes(key);
			var base64Secret = TextEncodings.Base64Url.Encode(key);

			var client = new Client
			{
				Id = Guid.NewGuid().ToString("D"),
				Active = true,
				AllowedOrigin = (string.IsNullOrWhiteSpace(clientModel.AllowedOrigin)) ? "*" : clientModel.AllowedOrigin,
				ApplicationType = clientModel.ApplicationType,
				Name = clientModel.Name,
				RefreshTokenLifeTime = clientModel.RefreshTokenLifeTime,
				Secret = base64Secret
			};

			this._context.Clients.Add(client);

			var result = await this._context.SaveChangesAsync() > 0;

			if (result)
			{
				return client;
			}

			return null;
		}

		public async Task<bool> RemoveClient(string id)
		{
			var client = await this._context.Clients.FindAsync(id);

			if (client != null)
			{
				this._context.Clients.Remove(client);

				return await this._context.SaveChangesAsync() > 0;
			}

			return false;
		}

		public async Task<bool> AddRefreshToken(RefreshToken token)
		{
			var existingToken = _context.RefreshTokens.Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();

			if (existingToken != null)
			{
				var result = await RemoveRefreshToken(existingToken);
			}

			_context.RefreshTokens.Add(token);

			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> RemoveRefreshToken(RefreshToken existingToken)
		{
			_context.RefreshTokens.Remove(existingToken);

			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> RemoveRefreshToken(string refreshTokenId)
		{
			var refreshToken = _context.RefreshTokens.Find(refreshTokenId);

			if (refreshToken != null)
			{
				_context.RefreshTokens.Remove(refreshToken);

				return await _context.SaveChangesAsync() > 0;
			}

			return false;
		}

		public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
		{
			var refreshToken = await _context.RefreshTokens.FindAsync(refreshTokenId);

			return refreshToken;
		}

		public List<RefreshToken> GetAllRefreshTokens()
		{
			return _context.RefreshTokens.ToList();
		}

		private bool _disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed) return;

			if (disposing)
			{
				// dispose managed resources
				_context.Dispose();
			}

			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}