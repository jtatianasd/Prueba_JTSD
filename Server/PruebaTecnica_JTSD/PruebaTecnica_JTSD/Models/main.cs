using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace PruebaTecnica_JTSD.Models
{
		public class main
		{
			public string Post(string url, string json)
			{
				try
				{
					var client = new RestClient(url);
					var request = new RestRequest(Method.POST);
					request.AddHeader("content-type", "application/json");
					request.AddParameter("application/json", json, ParameterType.RequestBody);
					IRestResponse response = client.Execute(request);
					token datos = JsonConvert.DeserializeObject<token>(response.Content);

					return datos.id_token;
				}
				catch (Exception ex)
				{

					return ex.ToString();
				}
			}

			public List<Agencies> Get(string url, string token)
			{
				HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
				myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
				myWebRequest.Headers.Add("Authorization", "Bearer " + token);
				myWebRequest.Credentials = CredentialCache.DefaultCredentials;
				myWebRequest.Proxy = null;
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
				Stream myStream = myHttpWebResponse.GetResponseStream();
				StreamReader myStreamReader = new StreamReader(myStream);
				//Leemos los datos
				string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

				List<Agencies> data = JsonConvert.DeserializeObject<List<Agencies>>(Datos);

				return data;
			}
		}
	
}
