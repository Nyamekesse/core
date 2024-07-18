using ef_core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ef_core;

public class BookController(ApplicationDBContext _db) : Controller
{
    public IActionResult Index()
    {
        List<Book> objList = [.. _db.Books.Include(b => b.Publisher)];
        // foreach (var obj in objList)
        // {
        //     // obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
        //     _db.Entry(obj).Reference(b => b.Publisher).Load();
        // }
        return View(objList);
    }

    public IActionResult Upsert(int? id)
    {
        BookViewModel obj =
            new()
            {
                PublisherList = _db.Publishers.Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Publisher_Id.ToString()
                })
            };

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
        obj = _db.Books.FirstOrDefault(b => b.Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        _db.Books.Remove(obj);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int? id)
    {
        BookDetail obj = new();
        if (id is null || id == 0)
        {
            return NotFound();
        }

        obj = _db.BookDetails.Include(b => b.Book).FirstOrDefault(b => b.Book_Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Details(BookDetail obj)
    {
        if (obj.BookDEtail_I == 0)
        {
            _db.BookDetails.Add(obj);
        }
        else
        {
            _db.BookDetails.Update(obj);
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult ManageAuthors(int id)
    {
        BookAuthorViewModel obj =
            new()
            {
                BookAuthorList =
                [
                    .. _db
                        .BookAuthorMaps.Include(b => b.Author)
                        .Include(b => b.Book)
                        .Where(b => b.Book_Id == id)
                ],
                BookAuthor = new() { Book_Id = id },
                Book = _db.Books.FirstOrDefault(b => b.Id == id),
            };
        List<int> tempListOfAssignedAuthors = obj.BookAuthorList.Select(b => b.Author_Id).ToList();

        var tempList = _db
            .Authors.Where(a => !tempListOfAssignedAuthors.Contains(a.Author_Id))
            .ToList();
        obj.AuthorList = tempList.Select(a => new SelectListItem
        {
            Text = a.FullName,
            Value = a.Author_Id.ToString()
        });
        return View(obj);
    }

    [HttpPost]
    public IActionResult ManageAuthors(BookAuthorViewModel obj)
    {
        if (obj.BookAuthor.Book_Id != 0 && obj.BookAuthor.Author_Id != 0)
        {
            _db.BookAuthorMaps.Add(obj.BookAuthor);
            _db.SaveChanges();
        }
        return RedirectToAction(nameof(ManageAuthors), new { @id = obj.BookAuthor.Book_Id });
    }
}
