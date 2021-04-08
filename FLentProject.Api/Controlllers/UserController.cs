using System;
using System.Net;
using CoreProject.Core.Interfaces.Validations;
using CoreProject.Core.ValueObjects;
using FLentProject.Api.Controlllers.ViewModels.UserViewModels;
using FLentProject.Domain.Users;
using FLentProject.Domain.Users.UserInterfaces.Services;
using FLentProject.Infra.CrossCutting.Auth.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FLentProject.Api.Controlllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IUserIdentity _userIdentity;

        public UserController(IValidationNotification validationNotification, IUserService userService, IUserIdentity userIdentity) : base(validationNotification)
        {
            _userService = userService;
            _userIdentity = userIdentity;
        }


        [Filters.Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _userService.GetAll(_userIdentity.GetUserId()));
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [Filters.Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _userService.GetById(id, _userIdentity.GetUserId()));
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Authenticate([FromBody] UserAuthenticateRequest userAuthenticateRequest)
        {
            try
            {
                var login = new Email(userAuthenticateRequest.Login);
                return CreateResponse(HttpStatusCode.OK, _userService.Authenticate(login, userAuthenticateRequest.Password));
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
        
        //[Filters.Authorize]
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        var user = _userService.GetById(id);
        //        _userService.Delete(user);

        //        return CreateResponse(HttpStatusCode.OK, "Object deleted");
        //    }
        //    catch (Exception err)
        //    {
        //        return CreateResponse(HttpStatusCode.BadRequest, err.Message);
        //    }
        //}
    }
}
