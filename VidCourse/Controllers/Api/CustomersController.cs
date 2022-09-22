using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using VidCourse.Dtos;
using VidCourse.Models;
using System.Data.Entity;
namespace VidCourse.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();  
        }

        //Get /api/customers
        public IHttpActionResult GetCustomers()
        {
            //Select para pasar un delegadoy en este caso Mapper serà el delegado
            /*
             
             */

            var customerDtos= _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault( x => x.Id == id);    
             if(customer== null)
            {
                return NotFound();
                }
             //Surce,target
             return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        //Post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();

            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);   
            _context.SaveChanges();


            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }
        //PUT api/customers/1
        //Put
        [HttpPut]

        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            var customerInDb =_context.Customers.SingleOrDefault( x => x.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto, customerInDb);
            /*customerInDb.Name= customerDto.Name;
            customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;*/
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
 
            var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
