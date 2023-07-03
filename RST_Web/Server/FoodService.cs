using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_Utility;
using RST_Web.Models;
using RST_Web.Models.Dto;
using RST_Web.Server.IServer;

namespace RST_Web.Server
{
    public class FoodService: BaseService, IFoodService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;

        public FoodService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        }

        public Task<T> CreateAsync<T>(FoodDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaUrl + "/api/FoodAPI",
                // Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaUrl + "/api//" + id,
                // Token = token
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/FoodAPI",
                // Token = token
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/FoodAPI/" + id,
                // Token = token
            });
        }

        public Task<T> UpdateAsync<T>(FoodDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/FoodAPI/" + dto.Id,
                // Token = token
            }) ;
        }
        
    }
}