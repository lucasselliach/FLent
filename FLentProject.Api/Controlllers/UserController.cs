﻿using System;
using System.Net;
using CoreProject.Core.Interfaces.Validations;
using CoreProject.Core.ValueObjects;
using FLentProject.Api.Controlllers.ViewModels.UserViewModels;
using FLentProject.Domain.Users;
using FLentProject.Domain.Users.UserInterfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FLentProject.Api.Controlllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IValidationNotification validationNotification, IUserService userService) : base(validationNotification)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _userService.GetAll());
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _userService.GetById(id));
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreateViewModel userCreateViewModel)
        {
            try
            {
                var login = new Email(userCreateViewModel.Login);
                var user = new User(userCreateViewModel.Name,
                                    login,
                                    userCreateViewModel.Password);

                _userService.Create(user);

                return CreateResponse(HttpStatusCode.OK, "Object created");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult Edit(string id, [FromBody] UserEditViewModel userEditViewModel)
        //{
        //    try
        //    {
        //        var user = _userService.GetById(id);
        //        user.Edit(userEditViewModel.Name);

        //        _userService.Edit(user);

        //        return CreateResponse(HttpStatusCode.OK, "Object edited");
        //    }
        //    catch (Exception err)
        //    {
        //        return CreateResponse(HttpStatusCode.BadRequest, err.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var user = _userService.GetById(id);
                _userService.Delete(user);

                return CreateResponse(HttpStatusCode.OK, "Object deleted");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }
    }
}
