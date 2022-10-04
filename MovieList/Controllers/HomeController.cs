using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Controllers
{
    public class HomeController : Controller            //in order to access table we need a context table object
    {
          private MovieContext Context { get; set; }

          public HomeController(MovieContext ctx)
        {
            Context = ctx;
        }

          public IActionResult Index()              //send index list of movies
        {
            var movies = Context.Movies.Include(m=>m.Genre).OrderBy(m => m.Name).ToList();   //this retrieved list from table will go into the movies variable we created.
            return View(movies);
        }

    }
}
