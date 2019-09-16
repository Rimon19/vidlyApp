using System;
using System.Collections.Generic;
using  System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.EntryModel;
using Vidly.Models.ViewModel;

namespace Vidly.Controllers
{
	public class CustomerController : Controller
	{
		private ApplicationDbContext _context;

		public CustomerController()
		{
			_context=new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//
		// GET: /Customer/
		public ActionResult Index()
		{
			var customer = _context.Customers.Include(c=>c.MemberShipType).ToList();
			var customers = new CustomerViewModel()
			{
				Customers = customer
			};
			return View(customers);
		}

		public ActionResult New()
		{
			var memberShipType = _context.MemberShipTypes.ToList();
			var viewModel = new CustomerFormViewModel
			{
				MemberShipTypes = memberShipType
			};
			return View("CustomerForm",viewModel);
		}
		[HttpPost]
		public ActionResult Create(Customer customer)
		{
            //if (!ModelState.IsValid)
            //{
            //    var ViewModel = new CustomerFormViewModel
            //    {
            //        Customer = customer,
            //        MemberShipTypes = _context.MemberShipTypes.ToList()
            //    };
            //    return View("Customer", ViewModel);
            //}
			if(customer.Id==0)
			_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
				customerInDb.CustomerName = customer.CustomerName;
				customerInDb.BirthDate = customer.BirthDate;
				customerInDb.IsSubscribeNewsLetter = customer.IsSubscribeNewsLetter;
				customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Customer");
		}

		public ActionResult Details(byte id)
		{
			var customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c => c.Id == id);
			if (customer == null)
			{
				return HttpNotFound();
			}
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
				MemberShipTypes = _context.MemberShipTypes.ToList()
			};
			return View("CustomerForm", viewModel);
		}
	}
}