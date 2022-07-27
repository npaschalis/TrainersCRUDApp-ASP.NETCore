using Microsoft.AspNetCore.Mvc;
using TrainersCRUDAppCore.DataAccess.Data;
using TrainersCRUDAppCore.DataAccess.Repository.IRepository;
using TrainersCRUDAppCore.Models;

namespace TrainersCRUDAppCoreWeb.Controllers
{
    public class TrainerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Trainer> objTrainerList = _unitOfWork.Trainer.GetAll();
            return View(objTrainerList);
        }


        // Create: GET
        public IActionResult Create()
        {
            return View();
        }

       // Create: POST
       [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult Create(Trainer obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Trainer.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Trainer created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // Edit: GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var trainerFromDb = _unitOfWork.Trainer.GetFirstOrDefault(u => u.Id == id);

            if  (trainerFromDb == null)
            {
                return NotFound();
            }

            return View(trainerFromDb);
        }

        // Edit: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Trainer obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Trainer.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Trainer updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Delete: GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var trainerFromDb = _unitOfWork.Trainer.GetFirstOrDefault(u => u.Id == id);

            if (trainerFromDb == null)
            {
                return NotFound();
            }

            return View(trainerFromDb);
        }


        // Delete: POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Trainer.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Trainer.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Trainer deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
