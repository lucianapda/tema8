using Aplicacao.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Aplicacao.Services
{
    public class ServiceLaboratorio
    {
        public List<LaboratorioDto> ObterTodas(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("laboratorio").Result;

                return response.Content.ReadAsAsync<List<LaboratorioDto>>().Result;
            }
        }

        public LaboratorioDto Obter(string token, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("laboratorio/" + id.ToString()).Result;

                return response.Content.ReadAsAsync<LaboratorioDto>().Result;
            }
        }

        public bool Cadastrar(string token, LaboratorioDto laboratorio)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.PostAsJsonAsync("laboratorio", laboratorio).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public bool Atualizar(string token, LaboratorioDto laboratorio)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.PutAsJsonAsync("laboratorio", laboratorio).Result;

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

                var response = client.DeleteAsync("laboratorio/" + id).Result;
                
                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
        }
    }
}
