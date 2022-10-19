using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShelfProject.Models;

namespace BookShelfProject.Controllers
{
    public class HomeController : Controller
    {
        BookshelfDBEntities db = new BookshelfDBEntities();  //BookShelf (models) içindeki verileri çağırdım.
        // GET: Home
        public ActionResult Index()
        {
            var Books = db.Book.ToList();        
            return View(Books);
         
        }
        [HttpGet]  //Başlangıçta hiçbirşey yapmazsak burası çalışsın.
        public ActionResult AddBook()
        {
             return View();

        }
        [HttpPost]  // Butona tıklarsak burası çalışsın.
        public ActionResult AddBook(Book b)
        {         
           db.Book.Add(b);
           db.SaveChanges();
           return RedirectToAction("Index");

        }
        public ActionResult BookDelete(int ID)
        {
            var Book = db.Book.Find(ID);
            db.Book.Remove(Book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookUpdate(int ID) // Kitapları getir.
        {
            var Bk =db.Book.Find(ID);
            return View ("BookUpdate",Bk);
        }
        [HttpPost]
        public ActionResult BookUpdate2 (Book b) // Kitapları Güncelle.
        {
            var Book = db.Book.Find(b.BookID);
            Book.Name = b.Name; 
            Book.Author = b.Author;
            Book.Page=b.Page;
            Book.Category=b.Category;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Category()
        {
            var categories=db.Category.ToList();
            return View(categories);
        }
    }
}