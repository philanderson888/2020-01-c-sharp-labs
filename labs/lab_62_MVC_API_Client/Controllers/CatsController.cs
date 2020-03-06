#define API_ASYNC
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_62_MVC_API_Client.Models;
using System.Net.Http;
using System.Security.Policy;
using Newtonsoft.Json;

namespace lab_62_MVC_API_Client.Controllers
{
    public class CatsController : Controller
    {
        private readonly CatDbContext _context;
        private string url = "https://localhost:44307/api/CatsAPI/";

        public CatsController(CatDbContext context)
        {
            _context = context;
        }
#if API_SYNC
        // GET: Cats
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var jsonStringTask = client.GetStringAsync(url);
                var cats = JsonConvert.DeserializeObject<List<Cat>>(jsonStringTask.Result);
                return View(cats);
            }
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                var jsonStringTask = client.GetStringAsync(url + id);
                var cat = JsonConvert.DeserializeObject<Cat>(jsonStringTask.Result);
                if (cat == null)
                {
                    return NotFound();
                }
                return View(cat);
            }

        }

#elif API_ASYNC
        // GET: Cats
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var jsonString = await GetCatDataAsync();
                var cats = JsonConvert.DeserializeObject<List<Cat>>(jsonString);
                return View(cats);
            }
        }
        public async Task<string> GetCatDataAsync()
        {
            string jsonString = null;

            using (var client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(url);
            }
            return jsonString;
        }

        
        
        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                var jsonStringTask = client.GetStringAsync(url + id);
                var cat = JsonConvert.DeserializeObject<Cat>(jsonStringTask.Result);
                if (cat == null)
                {
                    return NotFound();
                }
                return View(cat);
            }

        }



#else
        // GET: Cats
        public async Task<IActionResult> Index()
        {
            var catDbContext = _context.Cats.Include(c => c.Category);
            return View(await catDbContext.ToListAsync());
        }



                // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

#endif


        // GET: Cats/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatId,CatName,CategoryId,DateOfBirth")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", cat.CategoryId);
            return View(cat);
        }

        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", cat.CategoryId);
            return View(cat);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatId,CatName,CategoryId,DateOfBirth")] Cat cat)
        {
            if (id != cat.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(cat.CatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", cat.CategoryId);
            return View(cat);
        }

        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatExists(int id)
        {
            return _context.Cats.Any(e => e.CatId == id);
        }
    }
}
