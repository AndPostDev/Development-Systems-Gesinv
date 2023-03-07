﻿using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _serviceProveedor;
        private readonly IEmpresaService _serviceEmpresa;
        private readonly ITipoProveedorService _serviceTipoProveedor;
        private readonly IEstadoService _serviceEstado;
        private readonly IProvinciaService _serviceProvincia;
        private readonly ITipoPersonaService _serviceTipoPersona;

        public ProveedorController(IProveedorService serviceProveedor, IEmpresaService serviceEmpresa, ITipoProveedorService serviceTipoProveedor, IEstadoService serviceEstado, IProvinciaService serviceProvincia, ITipoPersonaService serviceTipoPersona)
        {
            _serviceProveedor = serviceProveedor;
            _serviceEmpresa = serviceEmpresa;
            _serviceTipoProveedor = serviceTipoProveedor;
            _serviceEstado = serviceEstado;
            _serviceProvincia = serviceProvincia;
            _serviceTipoPersona = serviceTipoPersona;
        }

        // GET: ProveedorController
        public async Task<IActionResult> Index()
        {
            List<ProveedorViewModel> lstPedido = ProveedorViewModel.ToViewModelList(await _serviceProveedor.GetAll());
            return View(lstPedido);
        }
        [HttpGet]
        public async Task<IActionResult> getList()
        {
            IEnumerable<Proveedor> query = await _serviceProveedor.GetAll();
            List<object> result = new List<object>();
            foreach (Proveedor prov in query)
            {
                result.Add(new { ProveedorId = prov.ProveedorId, RazonSocial = prov.RazonSocial });
            }
            ViewBag.Proveedores =  result;
            return StatusCode(StatusCodes.Status200OK, result);
        }

        // GET: ProveedorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ProveedorViewModel prov = ProveedorViewModel.ToViewModel(await _serviceProveedor.GetById(id));
            return View(prov);
        }

        // GET: ProveedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProveedorViewModel proveedorViewModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        // GET: ProveedorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ProveedorViewModel prov = ProveedorViewModel.ToViewModel(await _serviceProveedor.GetById(id));
            return View(prov);
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
        public async Task<IActionResult> Delete(int id)
        {
            ProveedorViewModel prov = ProveedorViewModel.ToViewModel(await _serviceProveedor.GetById(id));
            return View(prov);
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
