using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTCoreDemo.Services
{
    public class TestService : ITestService
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }
    }
}
