using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using com.portfolio2.web.Data;
using com.portfolio2.web.Models;
using Microsoft.AspNetCore.Authorization;

namespace com.portfolio2.web.Controllers
{
    //[Authorize(Roles ="user,admin")]
    public class UserProfilesController : Controller
    {
        private readonly comportfolio2webContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserProfilesController(comportfolio2webContext context, IWebHostEnvironment hosting)
        {
            var fullname = "";// HttpContext.Session.GetString("fullname");
            
            _context = context;
            _hostingEnvironment = hosting;
        }

        // GET: UserProfiles
        public async Task<IActionResult> Index()
        {
            string fullName = HttpContext.Session.GetString("fullname")??"";
            ViewBag.fullName = fullName;

            return _context.UserProfile != null ?
                        View(await _context.UserProfile.ToListAsync()) :
                        Problem("Entity set 'comportfolio2webContext.UserProfile'  is null.");
        }

        // GET: UserProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserProfile == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Title,AboutMe,Resume")] UserProfile userProfile, FormFile resume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserProfile == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfile.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Title,AboutMe")] UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        //save files
                        //absolute path
                        // C://foldera//folderb//filename.ext
                        //relative path
                        //starts from wwwroot

                        userProfile.Resume = saveFileDir(Request.Form.Files["Resume"]);
                        userProfile.Photo = saveFileDir(Request.Form.Files["Photo"]);



                    }

                    _context.Update(userProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(userProfile.Id))
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
            return View(userProfile);
        }
        private string? saveFileDir(IFormFile file)
        {
            //finding root directory -> upto wwwroot folder
            //cobine root direct with uploads folder
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            if (file.Length > 0)
            {
                //creating full absolute path for saving image
                string filePath = Path.Combine(uploads, file.FileName);
                //for displaying image in html img element
                string relative = "/uploads/" + file.FileName;

                // a file stream is creating to write existing file in given directory.{filePath}
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    //existing file is copied to given directory of file.
                    file.CopyTo(fileStream);
                }
                return relative;
            }
            return "";

        }
        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserProfile == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserProfile == null)
            {
                return Problem("Entity set 'comportfolio2webContext.UserProfile'  is null.");
            }
            var userProfile = await _context.UserProfile.FindAsync(id);
            if (userProfile != null)
            {
                _context.UserProfile.Remove(userProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProfileExists(int id)
        {
            return (_context.UserProfile?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
