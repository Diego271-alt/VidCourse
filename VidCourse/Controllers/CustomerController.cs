using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using VidCourse.Models;
using VidCourse.ViewModels;


namespace VidCourse.Controllers
{
    public class CustomerController : Controller
    { 
        //Definimos el contexto de la applicacion
        private ApplicationDbContext _context;

        //Instanciamos el contexto
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Accion new
        /*
         Esta aaccions nos va a servir para poder crear un nuevo customer
        Cuando querramos agregar u nuevo customer se verá así 

        https://localhost:44337/Customer/new
         */

        public ActionResult New()
        {
            //Obtenemos una lista de las membresias
            var membershipTypes = _context.MembershipTypes.ToList();
            //Instanciamos el modelo CustomerFormViewModel
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            //Vista y Modelo
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),
                };
                     return View("CustomerForm",viewModel);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ViewResult Index()
        {

            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}