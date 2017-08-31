﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using TrabalhoBackEnd.Enumeradores;
using TrabalhoBackEnd.Util;

namespace TrabalhoBackEnd.Seguranca
{
    public class Principal : IPrincipal
    {
        private readonly Identidade identidade;

        public IIdentity Identity { get { return identidade; } }

        public Principal(Identidade identidade)
        {
            if (identidade == null)
                throw new ArgumentNullException(nameof(identidade));

            this.identidade = identidade;
        }

        public bool IsInRole(string role)
        {
            var acessoPermitido = identidade?
                .Token?
                .Claims?
                .Any(c =>
                    c.Type.Equals(ClaimTypes.Role, StringComparison.OrdinalIgnoreCase)
                    && c.Value.Equals(role, StringComparison.OrdinalIgnoreCase));

            return acessoPermitido.Value;
        }

        public bool IsInRole(PerfilUsuario perfil)
        {
            var acessoPermitido = identidade?
                .Token?
                .Claims?
                .Any(c =>
                    c.Type.Equals(ClaimTypes.Role, StringComparison.OrdinalIgnoreCase)
                    && perfil.HasFlag<PerfilUsuario>(c.Value));

            return acessoPermitido.Value;
        }
    }
}