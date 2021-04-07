using System;
using System.Net;
using CoreProject.Core.Interfaces.Validations;
using CoreProject.Core.ValueObjects;
using FLentProject.Api.Controlllers.ViewModels.FriendViewModels;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Friends.FriendInterfaces.Services;
using FLentProject.Infra.CrossCutting.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FLentProject.Api.Controlllers
{
    [Route("[controller]/")]
    [ApiController]
    public class FriendController : ApiController
    {
        private readonly IFriendService _friendService;
        private readonly IUserIdentity _userIdentity;

        public FriendController(IValidationNotification validationNotification, IFriendService friendService, IUserIdentity userIdentity) : base(validationNotification)
        {
            _friendService = friendService;
            _userIdentity = userIdentity;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _friendService.GetAll());
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
                return CreateResponse(HttpStatusCode.OK, _friendService.GetById(id));
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] FriendCreateViewModel friendCreateViewModel)
        {
            try
            {
                var email = new Email(friendCreateViewModel.Email);
                var phone = new Phone(friendCreateViewModel.Phone);

                var friend = new Friend(friendCreateViewModel.Name,
                                        friendCreateViewModel.NickName,
                                        email,
                                        phone,
                                        _userIdentity.GetUserId());

                _friendService.Create(friend);

                return CreateResponse(HttpStatusCode.OK, "Object created");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] FriendEditViewModel friendEditViewModel)
        {
            try
            {
                var email = new Email(friendEditViewModel.Email);
                var phone = new Phone(friendEditViewModel.Phone);

                var friend = _friendService.GetById(id);
                friend.Edit(friendEditViewModel.NickName,
                            email, 
                            phone);

                _friendService.Edit(friend);

                return CreateResponse(HttpStatusCode.OK, "Object edited");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var friend = _friendService.GetById(id);
                _friendService.Delete(friend);

                return CreateResponse(HttpStatusCode.OK, "Object deleted");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }
    }
}
