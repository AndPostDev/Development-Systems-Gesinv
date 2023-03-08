﻿using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DevSys.Gesinv.UI.Controllers
{
    public class IngresoController : Controller 
    {
        private readonly IingresoService _service;

        public IngresoController(IingresoService service)
        {
            _service = service;
        } 


        // GET: IngresoController
        public async  Task<ActionResult> Index()
        {
            IEnumerable<Ingreso> query = await _service.GetAll();
            List<IngresoViewModel> lstViewModel =  IngresoViewModel.ToListIngModel(query);
            return View(lstViewModel);
        }

        // GET: IngresoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Ingreso query = await _service.GetById(id);
            IngresoViewModel modelView = IngresoViewModel.ToINGModelView(query);
            return View(modelView);
        }

        // GET: IngresoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngresoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                IngresoViewModel newIP = new IngresoViewModel()
                {
                     IngresoId = Convert.ToInt32(collection["IngresoId"]),
                     CodigoIngreso = Convert.ToInt32(collection["CodigoIngreso"]),
                     ProveedorId = Convert.ToInt32(collection["ProveedorId"]),
                     MotivoId = Convert.ToInt32(collection["MotivoId"]),
                     BodegaId = Convert.ToInt32(collection["BodegaId"]),
                     TipoIngresoId = Convert.ToInt32((collection["TipoIngresoId"])),
                     Fecha = Convert.ToDateTime(collection["Fecha"]),
                     Descuento = Convert.ToDouble(collection["Descuento"]),
                     Impuestos = Convert.ToDouble(collection["Impuestos"]),
                     Total = Convert.ToDouble(collection["Total"]),
                };
                
                int cantidad = Convert.ToInt32(collection["cantidadProducto"]);

                for (int i = 1; i <= cantidad; i++)
                {
                    IngresoDetalleViewModel row = new IngresoDetalleViewModel();
                    try
                    {
                        row.ProductoId = Convert.ToInt32(collection[$"Nombre{i}"]);
                    }
                    catch (Exception)
                    {
                        row.ProductoId = 0;
                        row.Producto = new Producto
                        {
                            Nombre = collection[$"Nombre{i}"],
                            Precio = Convert.ToDouble(collection[$"PrecioUnitario"])
                        };
                    }
                    row.IngresoDetalleId = Convert.ToInt32(collection[$"IngresoDetalle{i}"]);
                    row.ProductoId = Convert.ToInt32(collection[$"Producto{i}"]);
                    row.IngresoId = Convert.ToInt32(collection[$"Ingreso{i}"]);
                    row.PrecioBruto = Convert.ToDouble(collection[$"PrecioBruto{i}"]);
                    row.Caja = 0;
                    row.Cantidad = Convert.ToInt32(collection[$"Cantidad{i}"]);
                }

                Ingreso model = IngresoViewModel.ToModelViewING(newIP);
                Ingreso result = await _service.Modificar(model);
                return View(result);
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: IngresoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngresoController/Edit/5
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

        // GET: IngresoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngresoController/Delete/5
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