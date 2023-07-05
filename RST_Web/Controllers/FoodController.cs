using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RST_Utility;
using RST_Web.Models;
using RST_Web.Models.Dto;
using RST_Web.Server.IServer;

namespace RST_Web.Controllers
{

    public class FoodController : Controller
    {
        private readonly IFoodService _FoodService;
        private readonly IMapper _mapper;
        public FoodController(IFoodService FoodService, IMapper mapper)
        {
            _FoodService = FoodService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexFood()
        {
            List<FoodDTO> list = new();
            // HttpContext.Session.GetString(SD.SessionToken);
            var response = await _FoodService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<FoodDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        // [Authorize(Roles ="admin")]
//         public async Task<IActionResult> CreateFood()
//         {
//             return View();
//         }
//         [Authorize(Roles = "admin")]
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> CreateFood(FoodCreateDTO model)
//         {
//             if (ModelState.IsValid)
//             {

//                 var response = await _FoodService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
//                 if (response != null && response.IsSuccess)
// {
//                     TempData["success"] = "Food created successfully";
//                     return RedirectToAction(nameof(IndexFood));
//                 }
//             }
//             TempData["error"] = "Error encountered.";
//             return View(model);
//         }
//         [Authorize(Roles = "admin")]
//         public async Task<IActionResult> UpdateFood(int FoodId)
// {
//             var response = await _FoodService.GetAsync<APIResponse>(FoodId, HttpContext.Session.GetString(SD.SessionToken));
//             if (response != null && response.IsSuccess)
//             {
                
//                 FoodDTO model = JsonConvert.DeserializeObject<FoodDTO>(Convert.ToString(response.Result));
//                 return View(_mapper.Map<FoodUpdateDTO>(model));
//             }
//             return NotFound();
//         }
//         [Authorize(Roles = "admin")]
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> UpdateFood(FoodUpdateDTO model)
//         {
//             if (ModelState.IsValid)
//             {
//                 TempData["success"] = "Food updated successfully";
//                 var response = await _FoodService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
//                 if (response != null && response.IsSuccess)
//                 {
//                     return RedirectToAction(nameof(IndexFood));
//                 }
//             }
//             TempData["error"] = "Error encountered.";
//             return View(model);
//         }
//         [Authorize(Roles = "admin")]
//         public async Task<IActionResult> DeleteFood(int FoodId)
//         {
//             var response = await _FoodService.GetAsync<APIResponse>(FoodId, HttpContext.Session.GetString(SD.SessionToken));
//             if (response != null && response.IsSuccess)
//             {
//                 FoodDTO model = JsonConvert.DeserializeObject<FoodDTO>(Convert.ToString(response.Result));
//                 return View(model);
//             }
//             return NotFound();
//         }
//         [Authorize(Roles = "admin")]
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteFood(FoodDTO model)
//         {
            
//                 var response = await _FoodService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
//                 if (response != null && response.IsSuccess)
//                 {
//                 TempData["success"] = "Food deleted successfully";
//                 return RedirectToAction(nameof(IndexFood));
//                 }
//             TempData["error"] = "Error encountered.";
//             return View(model);
//         }
    }
}