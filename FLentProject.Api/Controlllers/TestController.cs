using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FLentProject.Api.Controlllers
{

    [Route("[controller]/")]
    [ApiController]
    public class TestController
    {
        [HttpGet]
        public string GetAll()
        {
            try
            {
                return "TESTE P";
            }
            catch (Exception err)
            {
                return "ERRO";
            }
        }
    }



}
