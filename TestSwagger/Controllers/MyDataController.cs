using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace TestSwagger.Controllers
{
    [ApiController]
    [Route("/MyData/{id}/{name}")]
    [Produces("application/json")]
    public class MyDataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MyData> Get(int id, string name)
        {
            var myDatas = new List<MyData>();
            myDatas.Add(new MyData() { FirstName = "Jean", LastName = "Desorme", Age = 77, Id=$"{id}_{name}" });
            return myDatas;
        }
    }
}

