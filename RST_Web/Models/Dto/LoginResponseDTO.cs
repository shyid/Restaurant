using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RST_Web.Models;
namespace RST_Web.Models.Dto
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
        // public string Role { get; set; }
    }
}