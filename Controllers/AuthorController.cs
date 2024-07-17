using ef_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ef_core.Controllers;

public class AuthorController(ApplicationDBContext _db) : Controller
{
    public IActionResult Index()
    {
        List<Author> objList = _db.Authors.ToList();
        return View(objList);
    }

    public IActionResult Upsert(int? id)
    {
        Author obj = new();
        if (id is null || id == 0)
        {
            //create
            return View(obj);
        }
        else
        {
            //update
            obj = _db.Authors.FirstOrDefault(c => c.Author_Id == id);
            if (obj is null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Author obj)
    {
        if (ModelState.IsValid)
        {
            if (obj.Author_Id == 0)
            {
                obj.BirthDate = obj.BirthDate.ToUniversalTime();
                await _db.Authors.AddAsync(obj);
            }
            else
            {
                obj.BirthDate = obj.BirthDate.ToUniversalTime();
                _db.Authors.Update(obj);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(obj);
    }

    public async Task<IActionResult> Delete(int id)
    {
        Author obj = new();

        obj = _db.Authors.FirstOrDefault(c => c.Author_Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        _db.Authors.Remove(obj);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
