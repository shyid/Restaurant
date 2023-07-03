using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_Web.Models;

namespace RST_Web.Server.IServer
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}