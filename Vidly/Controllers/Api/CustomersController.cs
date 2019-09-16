using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.EntryModel;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _Context;

        public CustomersController()
        {
            _Context=new ApplicationDbContext();
        }

        //Get: api/customers
        public IEnumerable<CustomerDto> GetCustomer()
        {
            return _Context.Customers.ToList()
            .Select(Mapper.Map<Customer,CustomerDto>);
        } 
        //Get: api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) 
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);

        }
        //Post:api/customers
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
          var customer= Mapper.Map<CustomerDto, Customer>(customerDto);
            _Context.Customers.Add(customer);
            _Context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }
        //Put:api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb==null)
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<CustomerDto, Customer>(customerDto);
            //customerInDb.CustomerName = customer.CustomerName;
            //customerInDb.BirthDate = customer.BirthDate;
            //customerInDb.IsSubscribeNewsLetter = customer.IsSubscribeNewsLetter;
            //customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            _Context.SaveChanges();

        }
        
        //Delete:api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _Context.Customers.Remove(customer);
            _Context.SaveChanges();
        }
    }
}
