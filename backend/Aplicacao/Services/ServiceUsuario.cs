using Aplicacao.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Aplicacao.Services
{
    public class ServiceUsuario
    {
        public List<UsuarioDto> ObterTodas(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("usuario").Result;

                return response.Content.ReadAsAsync<List<UsuarioDto>>().Result;
            }
        }

        public UsuarioDto Obter(string token, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("usuario/" + id.ToString()).Result;

                return response.Content.ReadAsAsync<UsuarioDto>().Result;
            }
        }

        public bool Cadastrar(string token, UsuarioDto usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.PostAsJsonAsync("usuario", usuario).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public bool Atualizar(string token, UsuarioDto usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.PutAsJsonAsync("usuario", usuario).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public bool Remover(string token, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.DeleteAsync("usuario/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
        }
    }
}
