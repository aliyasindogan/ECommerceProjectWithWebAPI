using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using WebAPIWithCoreMvc.ViewModels;

namespace WebAPIWithCoreMvc.Controllers
{
    public class UsersController : Controller
    {
        #region Defines

        private readonly HttpClient _httpClient;
        private string url = "http://localhost:63545/api/";

        #endregion Defines

        #region Constructor

        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion Constructor

        #region Crud

        public async Task<IActionResult> Index()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "Users/GetList");
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.GenderList = GenderFill();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddViewModel userAddViewModel)
        {
            UserAddDto userAddDto = new UserAddDto()
            {
                FirstName = userAddViewModel.FirstName,
                Gender = userAddViewModel.GenderID == 1 ? true : false,
                LastName = userAddViewModel.LastName,
                Address = userAddViewModel.Address,
                DateOfBirth = userAddViewModel.DateOfBirth,
                Email = userAddViewModel.Email,
                Password = userAddViewModel.Password,
                UserName = userAddViewModel.UserName,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Users/Add", userAddDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<UserDto>(url + "Users/GetById/" + id);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel()
            {
                FirstName = user.FirstName,
                GenderID = user.Gender == true ? 1 : 2,
                LastName = user.LastName,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName,
            };
            ViewBag.GenderList = GenderFill();
            return View(userUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UserUpdateViewModel userUpdateViewModel)
        {
            UserUpdateDto userUpdateDto = new UserUpdateDto()
            {
                FirstName = userUpdateViewModel.FirstName,
                Gender = userUpdateViewModel.GenderID == 1 ? true : false,
                LastName = userUpdateViewModel.LastName,
                Address = userUpdateViewModel.Address,
                DateOfBirth = userUpdateViewModel.DateOfBirth,
                Email = userUpdateViewModel.Email,
                Password = userUpdateViewModel.Password,
                UserName = userUpdateViewModel.UserName,
                Id = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Users/Update", userUpdateDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion Crud

        #region Methods

        private List<Gender> GenderFill()
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender() { Id = 1, GenderName = "Erkek" });
            genders.Add(new Gender() { Id = 2, GenderName = "Kadın" });
            return genders;
        }

        private class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }

        #endregion Methods
    }
}