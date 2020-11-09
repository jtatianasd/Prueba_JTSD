using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaTecnica_JTSD.Models;

namespace PruebaTecnica_JTSD.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AgenciesController : ControllerBase
	{
		main comm = new main();
		[HttpPost]
		[Route("auth")]
		public string Authentication(string url_auth)
		{

			string username_auth = "techuser";
			string password_auth = "TechUser123";
			string token;
			
			Authentication auth = new Authentication
			{
				password = password_auth,
				username = username_auth
			};
			string post_authentication = url_auth;
			string json = JsonConvert.SerializeObject(auth);
			token = comm.Post(post_authentication, json);
			return token;

	
		}

		[HttpGet]
		[Route("agencies")]
		public string List_agencies(string token)
		{
			string url_agencias = "https://v45hh4g3q5.execute-api.us-east-1.amazonaws.com/Dev/agencias";
			string jsonAgencies = JsonConvert.SerializeObject(comm.Get(url_agencias, token));
			return jsonAgencies;
		}


	}
}
