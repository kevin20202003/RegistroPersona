using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPersona.Model
{
    public class Persona
    {
        [PrimaryKey, NotNull]
        public string Cedula { get; set; }

        public string NombreCompleto { get; set; }
    }
}
