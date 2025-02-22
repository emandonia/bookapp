﻿using Book_BLL;
using Book_Dal;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace bookapp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return View(authors);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVmAuthor model)
        {
            var image = model.ImageFiles;
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    Name = model.Name,
                    
                    Bio = model.Bio,
                    

                };

                // images
               
                {
                    if (image != null && image.Length > 0)
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagepath/profile", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }

                        // تخزين مسار الصورة في الـ author
                        author.ImagePath = "/imagepath/profile/" + fileName;
                    }
                }
                await _authorService.CreateAuthorAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }
            var model = new EditVmAuthor
            {
               AuthorId=author.AuthorId,
                Name = author.Name,
                Bio = author.Bio,
                CurrentImagePath = author.ImagePath
            };



            return View(model);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditVmAuthor model)
        {

            var image = model.ImageFiles;
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    AuthorId = id,
                    Name = model.Name,

                Bio = model.Bio,


            };

            // images

            {
                if (image != null && image.Length > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagepath/profile", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
}

// تخزين مسار الصورة في الـ author
                        author.ImagePath = "/imagepath/profile/" + fileName;

                    }
                }
            await _authorService.UpdateAuthorAsync(author);
return RedirectToAction(nameof(Index));

//    if (id != author.AuthorId)
//{
//    return NotFound();
//}

//if (ModelState.IsValid)
//{
//    await _authorService.UpdateAuthorAsync(author);
//    return RedirectToAction(nameof(Index));
//}
return View(author);
        }
        return View(model);


    }

    // GET: Authors/Delete/5
    public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
