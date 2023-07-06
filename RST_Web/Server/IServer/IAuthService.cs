using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_Web.Models.Dto;

namespace RST_Web.Server.IServer
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
        Task<T> RegisterAsync<T>(RegisterationRequestDTO objToCreate);
    }
}