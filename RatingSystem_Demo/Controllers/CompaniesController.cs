using Microsoft.AspNetCore.Mvc;
using RatingSystem_Demo.Models;
using RatingSystem_Demo.Repositories;

namespace RatingSystem_Demo.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CompaniesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var companies = await unitOfWork.Companies.Get();
            var ratings = companies.Select(x => x.f_glassdoor_rating).ToList();
            ViewBag.Ratings = string.Join(", ", ratings);
            return View(companies);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var company = await unitOfWork.Companies.Find(id);
            return View(company);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyModel model)
        {
            var company = await unitOfWork.Companies.Add(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var company = await unitOfWork.Companies.Find(id);
            if (company == null)
            {
                return BadRequest();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CompanyModel model)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var company = await unitOfWork.Companies.Find(id);
            if (company == null)
            {
                return BadRequest();
            }
            await unitOfWork.Companies.Update(model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var company = await unitOfWork.Companies.Find(id);
            if (company == null)
            {
                return BadRequest();
            }
            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            var company = await unitOfWork.Companies.Find(id);
            await unitOfWork.Companies.Remove(company);
            return RedirectToAction(nameof(Index));
        }
    }
}
