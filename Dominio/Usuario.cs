﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public String Apellido { get; set; }
        public String UrlImagenPerfil { get; set; }
        public String Email { get; set; }
        public String Pass { get; set; }
        public Boolean Administrador { get; set; }
        
    }


}
