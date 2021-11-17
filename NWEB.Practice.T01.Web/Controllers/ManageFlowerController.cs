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
    public class ManageFlowerController : Controller
    {

        private readonly IFlowerRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public ManageFlowerController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<AppUser> userManager
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        // GET: ManageFlowerController
        public async Task<ActionResult> Index()
        {
            var flower = await _unitOfWork.Flowers.FindAll();
            var model = _mapper.Map<List<Flower>, List<FlowerVM>>(flower.ToList());
            return View(model);
        }

        // GET: ManageFlowerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageFlowerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageFlowerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FlowerVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var flower = _mapper.Map<Flower>(model);
                await _unitOfWork.Flowers.Create(flower);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        // GET: ManageFlowerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Flowers.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var flower = await _unitOfWork.Flowers.Find(q => q.Id == id);
            var model = _mapper.Map<FlowerVM>(flower);
            return View(model);
        }

        // POST: ManageFlowerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(FlowerVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var flower = _mapper.Map<Flower>(model);
                _unitOfWork.Flowers.Update(flower);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...!");
                return View();
            }
        }

        // GET: ManageFlowerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var flower = await _unitOfWork.Flowers.Find(q => q.Id == id);
            if (flower == null)
            {
                return NotFound();
            }
            _unitOfWork.Flowers.Delete(flower);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        // POST: ManageFlowerController/Delete/5
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
