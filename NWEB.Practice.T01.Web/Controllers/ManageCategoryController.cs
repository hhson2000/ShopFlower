using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NWEB.Practice.T01.Web.Data;
using NWEB.Practice.T01.Web.IRepositories;
using NWEB.Practice.T01.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageCategoryController : Controller
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public ManageCategoryController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<AppUser> userManager
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        // GET: ManageCategory
        public async Task<ActionResult> Index()
        {
            var cate = await _unitOfWork.Categories.FindAll();
            var model = _mapper.Map<List<Category>, List<CategoryVM>>(cate.ToList());
            return View(model);
        }

        // GET: ManageCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var category = _mapper.Map<Category>(model);
                await _unitOfWork.Categories.Create(category);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        // GET: ManageCategory/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Categories.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var category = await _unitOfWork.Categories.Find(q => q.Id == id);
            var model = _mapper.Map<CategoryVM>(category);
            return View(model);
        }

        // POST: ManageCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var category = _mapper.Map<Category>(model);
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...!");
                return View();
            }
        }

        // GET: ManageCategory/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _unitOfWork.Categories.Find(q => q.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        // POST: ManageCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
