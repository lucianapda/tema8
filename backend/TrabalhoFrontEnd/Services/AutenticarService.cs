using Aplicacao.Entidades;
using Aplicacao.Seguranca;
using Aplicacao.Util;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using TrabalhoFrontEnd.Models;

namespace TrabalhoFrontEnd.Services
{
    public class AutenticarService
    {
        public bool Autenticar(LoginModel login)
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
                        return true;
                    }
                    else
                    {
                        return false;
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