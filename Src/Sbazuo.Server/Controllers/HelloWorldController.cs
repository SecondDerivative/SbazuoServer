using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sbazuo.Server.Controllers {

    [Controller]
    //[Route("[controller]")]
    public class HelloWorldController : Controller {
        
        public string Index() {
            return "Hello, world!";
        }

        //[NonAction]
        public string Welcome() {
            return "Welcome, (test action)";
        }

        public string HardEventNonIncluded() {
            return "yes";
        }

    }
}