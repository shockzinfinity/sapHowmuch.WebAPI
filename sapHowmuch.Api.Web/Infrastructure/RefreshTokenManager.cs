using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public IEnumerable<Client> GetAllowedClients()
		{
			return _context.Clients.Where(x => x.Active);
		}

		public Client FindClient(string clientId)
		{
			var client = _context.Clients.Find(clientId);

			return client;
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
			var refreshToken = _context.RefreshTokens.Find(refreshTokenId);

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