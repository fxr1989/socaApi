﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Autenticacion
{
    public class UsuarioTokenDto
    {
        public bool Error { get; set; }
        public string Token { get; set; }
        public int TenantId { get; set; }
        public string UsuarioId { get; set; }
        public string NombreTenant { get; set; } 
    }
}
