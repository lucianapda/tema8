using System.Collections.Generic;

namespace Aplicacao.Dto
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public virtual ICollection<PerfilDto> Perfis { get; set; }
    }
}