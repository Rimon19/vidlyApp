using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.EntryModel.SeedModel;
using Vidly.Models.EntryModel;
using Vidly.Models.ViewModel;


namespace Vidly.Controllers
{
	public class MovieController : Controller
	{
		private ApplicationDbContext _context;

		public MovieController()
		{
			_context=new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//
		// GET: /Movie/Random
		public ViewResult Random()
		{
			var movie = _context.Movies.Include(c=>c.Genre).ToList();
			var movieRandomViewModel = new MovieFormViewModel()
			{
				Movies=movie
			};
			return View(movieRandomViewModel);
		}
		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);

		}

		public ActionResult New()
		{
			var Genre = _context.Genres.ToList();
			var viewModel = new MovieFormViewModel
			{
				Genres = Genre
			};
			return View("MovieForm", viewModel);
		}
		 public ActionResult Edit(int id)
		{
			 var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
 
			 if (movie == null)
				 return HttpNotFound();
 
			 var viewModel = new MovieFormViewModel
			{
				 Movie = movie,
				 Genres = _context.Genres.ToList()
			 };
 
			 return View("MovieForm", viewModel);
		 }
			[HttpPost]
		 public ActionResult Save(Movie movie)
		 {
			 if (movie.Id == 0)
			 {
				 movie.DateAdded = DateTime.Now;
				 _context.Movies.Add(movie);
			 }
			 else
			 {
				 var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
				 movieInDb.MovieName = movie.MovieName;
				 movieInDb.GenreId = movie.GenreId;
				 movieInDb.NumberInStock = movie.NumberInStock;
				 movieInDb.ReleaseDate = movie.ReleaseDate;
			 }
				try
				{
					_context.SaveChanges();
				}
				catch (DbEntityValidationException e)
				{

					Console.WriteLine(e);
				}
 
		   
				   return RedirectToAction("Random", "Movie");
		 }
				  }
		
		
	}
