using System;
using System.Net;
using CoreProject.Core.Interfaces.Validations;
using FLentProject.Domain.Lends;
using FLentProject.Domain.Lends.LendInterfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FLentProject.Api.Controlllers
{
    [Route("[controller]/")]
    [ApiController]
    public class LendController : ApiController
    {
        private readonly ILendService _lendService;
        public LendController(IValidationNotification validationNotification, ILendService lendService) : base(validationNotification)
        {
            _lendService = lendService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _lendService.GetAll());
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
                return CreateResponse(HttpStatusCode.OK, _lendService.GetById(id));
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] LendCreateViewModel lendCreateViewModel)
        //{
        //    try
        //    {
        //        var lend = new Lend(lendCreateViewModel.Name);

        //        _lendService.Create(lend);

        //        return CreateResponse(HttpStatusCode.OK, "Object created");
        //    }
        //    catch (Exception err)
        //    {
        //        return CreateResponse(HttpStatusCode.BadRequest, err.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public IActionResult Edit(string id, [FromBody] LendEditViewModel lendEditViewModel)
        //{
        //    try
        //    {
        //        var lend = _lendService.GetById(id);
        //        lend.Edit(lendEditViewModel.Name);

        //        _lendService.Edit(lend);

        //        return CreateResponse(HttpStatusCode.OK, "Object edited");
        //    }
        //    catch (Exception err)
        //    {
        //        return CreateResponse(HttpStatusCode.BadRequest, err.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        var lend = _lendService.GetById(id);
        //        _lendService.Delete(lend);

        //        return CreateResponse(HttpStatusCode.OK, "Object deleted");
        //    }
        //    catch (Exception err)
        //    {
        //        return CreateResponse(HttpStatusCode.BadRequest, err.Message);
        //    }
        //}
    }
}
