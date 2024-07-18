﻿using ef_core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ef_core;

public class BookController(ApplicationDBContext _db) : Controller
{
    public IActionResult Index()
    {
        List<Book> objList = [.. _db.Books];
        return View(objList);
    }

    public IActionResult Upsert(int? id)
    {
        BookViewModel obj = new();

        obj.PublisherList = _db.Publishers.Select(p => new SelectListItem
        {
            Text = p.Name,
            Value = p.Publisher_Id.ToString()
        });

        if (id is null || id == 0)
        {
            return View(obj);
        }
        obj.Book = _db.Books.FirstOrDefault(b => b.Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(BookViewModel obj)
    {
        if (obj.Book.Id == 0)
        {
            await _db.AddAsync(obj.Book);
        }
        else
        {
            _db.Update(obj.Book);
        }

        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        Book obj = new();
        obj = _db.Books.FirstOrDefault(c => c.Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        _db.Books.Remove(obj);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
