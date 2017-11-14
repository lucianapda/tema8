using System.Collections.Generic;

namespace Aplicacao.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<Perfil> Perfis { get; set; }


    }
}