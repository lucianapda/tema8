using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;

namespace Aplicacao.Services
{
    public class ServiceDisciplina
    {
        public List<DisciplinaDto> ObterTodas(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("disciplina").Result;

                return response.Content.ReadAsAsync<List<DisciplinaDto>>().Result;
            }
        }

        public DisciplinaDto Obter(string token, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("disciplina/" + id.ToString()).Result;

                return response.Content.ReadAsAsync<DisciplinaDto>().Result;
            }
        }

        public bool Cadastrar(string token, DisciplinaDto disciplina)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.PostAsJsonAsync("disciplina", disciplina).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public bool Atualizar(string token, DisciplinaDto disciplina)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.PutAsJsonAsync("disciplina", disciplina).Result;

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

                var response = client.DeleteAsync("disciplina/" + id).Result;
                
                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
        }
    }
}
