using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models.Dto
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}