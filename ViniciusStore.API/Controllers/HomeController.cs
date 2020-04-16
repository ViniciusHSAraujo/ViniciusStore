using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ViniciusStore.Domain.StoreContext.Entities;

namespace ViniciusStore.API.Controllers {
    public class HomeController : Controller {

        public dynamic Index() {
            return new { version = "1.0.0" };
        }
    }
}