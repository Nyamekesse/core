using Microsoft.AspNetCore.Mvc;

namespace ef_core.Controllers;

public class PublisherController(ApplicationDBContext _db) : Controller
{
    public IActionResult Index()
    {
        List<Publisher> objList = [.. _db.Publishers];
        return View(objList);
    }

    public IActionResult Upsert(int? id)
    {
        Publisher obj = new();
        if (id is null || id == 0)
        {
            //create
            return View(obj);
        }
        else
        {
            //update
            obj = _db.Publishers.FirstOrDefault(c => c.Publisher_Id == id);
            if (obj is null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Publisher obj)
    {
        if (ModelState.IsValid)
        {
            if (obj.Publisher_Id == 0)
            {
                await _db.Publishers.AddAsync(obj);
            }
            else
            {
                _db.Publishers.Update(obj);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(obj);
    }

    public async Task<IActionResult> Delete(int id)
    {
        Publisher obj = new();

        obj = _db.Publishers.FirstOrDefault(c => c.Publisher_Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        _db.Publishers.Remove(obj);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
