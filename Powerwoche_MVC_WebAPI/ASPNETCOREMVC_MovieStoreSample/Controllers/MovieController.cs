﻿using ASPNETCOREMVC_MovieStoreSample.Data;
using ASPNETCOREMVC_MovieStoreSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieStoreDbContext _context;

        public MovieController(MovieStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

         [HttpPost]
         [AutoValidateAntiforgeryToken]
         public async Task<IActionResult> Create(Movie movie)
         {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
         }

        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Movie currentMovie = await _context.Movies.FindAsync(Id.Value);


            return View(currentMovie);
        }

    }
}
