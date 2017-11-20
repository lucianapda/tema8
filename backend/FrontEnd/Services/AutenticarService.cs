using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using FrontEnd.Models;

namespace FrontEnd.Services
{
    public class AutenticarService
    {
        public string Autenticar(LoginModel login)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54438/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.PostAsJsonAsync("login/autenticar", login).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Headers.FirstOrDefault(t => t.Key == "Authorization").Value.FirstOrDefault();
                    }
                    else
                    {
                        return "";
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}