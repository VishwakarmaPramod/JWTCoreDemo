using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTCoreDemo.Services
{
    interface ITestService
    {
        IEnumerable<string> Get();
        string Get(int id);
        void Post([FromBody] string value);
        void Put(int id, [FromBody] string value);
        void Delete(int id);
    }
}
