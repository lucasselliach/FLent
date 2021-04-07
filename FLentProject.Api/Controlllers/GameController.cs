using System;
using System.Net;
using CoreProject.Core.Interfaces.Validations;
using FLentProject.Api.Controlllers.ViewModels.GameViewModels;
using FLentProject.Domain.Games;
using FLentProject.Domain.Games.GameInterfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FLentProject.Api.Controlllers
{
    [Route("[controller]/")]
    [ApiController]
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;
        public GameController(IValidationNotification validationNotification, IGameService gameService) : base(validationNotification)
        {
            _gameService = gameService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _gameService.GetAll());
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
                return CreateResponse(HttpStatusCode.OK, _gameService.GetById(id));
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] GameCreateViewModel gameCreateViewModel)
        {
            try
            {
                var game = new Game(gameCreateViewModel.Name);

                _gameService.Create(game);

                return CreateResponse(HttpStatusCode.OK, "Object created");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] GameEditViewModel gameEditViewModel)
        {
            try
            {
                var game = _gameService.GetById(id);
                game.Edit(gameEditViewModel.Name);

                _gameService.Edit(game);

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
                var county = _gameService.GetById(id);
                _gameService.Delete(county);

                return CreateResponse(HttpStatusCode.OK, "Object deleted");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }
    }
}
