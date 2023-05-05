using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data;
using PhoneBook.Models;


namespace PhoneBook.Controllers
{
    public class SubscribersController : Controller
    {
        private readonly AppDbContext _db;
        public SubscribersController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Subscriber> objList = _db.Subscribers;
            return View(objList);
        }


        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subscriber obj)
        {
            _db.Subscribers.Add(obj);   
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Subscribers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subscriber obj)
        {
            if(ModelState.IsValid)
            {
                _db.Subscribers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Subscribers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Subscribers.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Subscribers.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
