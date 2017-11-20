using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;

namespace Aplicacao.Services
{
    public class ServiceAgendamento
    {
        public List<AgendamentoDto> ObterTodas(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("agendamento").Result;

                return response.Content.ReadAsAsync<List<AgendamentoDto>>().Result;
            }
        }

        public bool Cadastrar(string token, AgendamentoDto agendamento)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.PostAsJsonAsync("agendamento", agendamento).Result;

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

                var response = client.PutAsJsonAsync("agendamento/liberar", disciplina).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public AgendamentoDto Obter(string token, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("agendamento").Result;

                return response.Content.ReadAsAsync<List<AgendamentoDto>>().Result.FirstOrDefault(a => a.Id == id);
            }
        }

        public bool Cancelar(string token, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54438/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = client.GetAsync("agendamento").Result;

                return response.Content.ReadAsAsync<List<AgendamentoDto>>().Result.FirstOrDefault(a => a.Id == id);
            }
        }

    }
}
