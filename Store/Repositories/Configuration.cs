using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Repositories
{
   static class Configuration
	{
		public static string ConnectionString
		{
			get
			{
				//This configurationmanager can be used with Microsoft.Extensions.Configuration
				ConfigurationManager configurationManager = new();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../StoreApp"));
				configurationManager.AddJsonFile("appsettings.json");

				return configurationManager.GetConnectionString("DefaultConnection");
			}

		}
	}
}