using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

//using sapHowmuch.Api.Common.Extensions;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace sapHowmuch.Api.Web.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ApplicationDbContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			// for code first migration
			//Enable-Migrations -ContextTypeName:sapHowmuch.Api.Web.Infrastructure.ApplicationDbContext -MigrationsDirectory:Migrations
			//Add-Migration -ConfigurationTypeName sapHowmuch.Api.Web.Migrations.Configuration initial
			//Update-Database -ConfigurationTypeName sapHowmuch.Api.Web.Migrations.Configuration -Verbose
			//Update-Database -ConfigurationTypeName sapHowmuch.Api.Web.Migrations.Configuration -Verbose - TargetMigration: Fourth

			var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
			var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

			if (!roleManager.Roles.Any(x => x.Name == "SuperAdmin"))
			{
				roleManager.Create(new ApplicationRole("SuperAdmin") { Description = "최고 관리자" });
			}

			if (!roleManager.Roles.Any(x => x.Name == "Admin"))
			{
				roleManager.Create(new ApplicationRole("Admin") { Description = "관리자" });
			}

			if (!roleManager.Roles.Any(x => x.Name == "User"))
			{
				roleManager.Create(new ApplicationRole("User") { Description = "사용자" });
			}

			var toAddUser = userManager.FindByName("shockz");
			if (toAddUser == null)
			{
				toAddUser = new ApplicationUser()
				{
					Id = Guid.Parse("7F6C21AC-0201-44D1-8F9A-A92AF2B58AE8").ToString(),
					UserName = "shockz",
					Email = "shockz@iquest.co.kr",
					EmailConfirmed = true,
					ProfileInfo = new UserProfile()
					{
						FullName = "Jun Yu",
						Description = "sapHowmuch Team",
						JoinDate = DateTime.UtcNow,
					}
				};

				userManager.Create(toAddUser, "iqst63214");
				userManager.SetLockoutEnabled(toAddUser.Id, false);

				userManager.AddToRoles(toAddUser.Id, "SuperAdmin", "Admin", "User");
			}

			if (context.Clients.Count() == 0)
			{
				foreach (var item in BuildClientList())
				{
					context.Clients.Add(item);
				}

				context.SaveChanges();
			}
		}

		private List<Client> BuildClientList()
		{
			List<Client> clientList = new List<Client>
			{
				new Client
				{
					Id = Guid.Parse("F1179B6B-15A8-4250-9ED9-4C2D5EE0376B").ToString(),
					Secret = GetHash("iqst63214"),
					Name = "JavaScript Front-end Application",
					ApplicationType = ApplicationType.JavaScript,
					Active = true,
					RefreshTokenLifeTime = 7200,
					AllowedOrigin = "http://192.168.1.229"
				},
				new Client
				{
					Id = Guid.Parse("3CFBC80C-9104-44E8-9E67-43663F25AC47").ToString(),
					Secret = GetHash("iqst63214"),
					Name = "Native console or winform Application",
					ApplicationType = ApplicationType.NativeConfidential,
					Active = true,
					RefreshTokenLifeTime = 14400,
					AllowedOrigin = "*"
				}
			};

			return clientList;
		}

		private byte[] ToByteArray(string str)
		{
			byte[] strBytes = Encoding.UTF8.GetBytes(str);
			return strBytes;
		}

		private string GetHash(string input)
		{
			HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
			byte[] byteValue = ToByteArray(input);
			byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

			return Convert.ToBase64String(byteHash);
		}
	}
}