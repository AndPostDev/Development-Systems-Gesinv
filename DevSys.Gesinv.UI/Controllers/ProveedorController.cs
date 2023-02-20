﻿using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _service;
        public ProveedorController(IProveedorService service)
        {
            _service = service;
        }

        // GET: ProveedorController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> getList()
        {
            IEnumerable<Proveedor> query = await _service.GetAll();
            List<object> result = new List<object>();
            foreach (Proveedor prov in query)
            {
                result.Add(new { ProveedorId = prov.ProveedorId, RazonSocial = prov.RazonSocial });
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        // GET: ProveedorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProveedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ProveedorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProveedorController/Delete/5
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
