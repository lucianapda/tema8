using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace TrabalhoBackEnd.Mapeamentos
{
    public static class RegistrarMapeamentos
    {
        public static void Registrar()
        {
            Mapper.Initialize(x=> x.AddProfile<EntidadeToDto>());
        }

        public static IEnumerable<Profile> GetProfiles()
        {
            var profiles = new List<Profile>();
            profiles.Add(new EntidadeToDto());

            return profiles;
        }
    }
}