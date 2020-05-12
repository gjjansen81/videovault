using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VideoVault.WebApi.Controllers
{
    public class KeyGenController : ApiController
    {
        public IActionResult GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var key = new byte[64];
                rng.GetBytes(key);
                return Ok(Convert.ToBase64String(key));
            }
        }
    }
}
