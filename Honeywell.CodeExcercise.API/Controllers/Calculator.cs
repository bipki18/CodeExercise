using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExcercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Calculator : ControllerBase
    {
        [Route("add")]
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<int> GetAddition(int i, int j)
        {
            return (i + j);
        }

        [Route("sub")]
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<int> GetSubstration(int i, int j)
        {
            return (i - j);
        }


        [Route("mul")]
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<int> GetMultiplication(int i, int j)
        {
            return (i * j); 
        }

        [Route("div")]
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<int> Getdivide(int i, int j)
        {
            return (i / j);
        }

    }
}
