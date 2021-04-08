using System;
using System.Net;
using CoreProject.Core.Interfaces.Validations;
using FLentProject.Api.Controlllers.ViewModels.LendViewModels;
using FLentProject.Domain.Friends.FriendInterfaces.Services;
using FLentProject.Domain.Games.GameInterfaces.Services;
using FLentProject.Domain.Lends;
using FLentProject.Domain.Lends.LendInterfaces.Services;
using FLentProject.Infra.CrossCutting.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FLentProject.Api.Controlllers
{
    [Route("[controller]/")]
    [ApiController]
    public class LendController : ApiController
    {
        private readonly ILendService _lendService;
        private readonly IGameService _gameService;
        private readonly IFriendService _friendService;
        private readonly IUserIdentity _userIdentity;

        public LendController(IValidationNotification validationNotification, ILendService lendService, IGameService gameService, IFriendService friendService, IUserIdentity userIdentity) : base(validationNotification)
        {
            _lendService = lendService;
            _gameService = gameService;
            _friendService = friendService;
            _userIdentity = userIdentity;
        }


        [Filters.Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _lendService.GetAll(_userIdentity.GetUserId()));
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
                return CreateResponse(HttpStatusCode.OK, _lendService.GetById(id, _userIdentity.GetUserId()));
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [Filters.Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] LendCreateViewModel lendCreateViewModel)
        {
            try
            {
                var game = _gameService.GetById(lendCreateViewModel.GamerId, _userIdentity.GetUserId());
                var friend = _friendService.GetById(lendCreateViewModel.FriendId, _userIdentity.GetUserId());

                var lend = new Lend(friend,
                                    game,
                                    _userIdentity.GetUserId());

                _lendService.Create(lend);

                return CreateResponse(HttpStatusCode.OK, "Object created");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }




    }
}
