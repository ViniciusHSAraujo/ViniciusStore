using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniciusStore.Domain.StoreContext.Entities;

namespace ViniciusStore.API.Controllers {
    public class CustomerController : Controller {

        [HttpGet]
        [Route("customers")]
        public List<Customer> GetAll() {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id) {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrdersByCustomerId(Guid id) {
            return null;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] Customer customer) {
            return null;
        }

        [HttpPut]
        [Route("customers")]
        public Customer Put([FromBody] Customer customer) {
            return null;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public string Delete(Guid id) {
            return null;
        }

    }
}