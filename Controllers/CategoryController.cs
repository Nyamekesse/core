using Microsoft.AspNetCore.Mvc;

namespace ef_core;

public class CategoryController(ApplicationDBContext _db) : Controller
{
    public IActionResult Index()
    {
        List<Category> objList = [.. _db.Categories];
        return View(objList);
    }

    public IActionResult Upsert(int? id)
    {
        Category obj = new Category();
        if (id is null || id == 0)
        {
            //create
            return View(obj);
        }
        else
        {
            //update
            obj = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (obj is null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Category obj)
    {
        if (ModelState.IsValid)
        {
            if (obj.Id == 0)
            {
                await _db.Categories.AddAsync(obj);
            }
            else
            {
                _db.Categories.Update(obj);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(obj);
    }

    public async Task<IActionResult> Delete(int id)
    {
        Category obj = new();

        obj = _db.Categories.FirstOrDefault(c => c.Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        _db.Categories.Remove(obj);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
