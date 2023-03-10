﻿using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    namespace DevSys.Gesinv.UI.Models.ViewModels
    {
    public class IngresoViewModel
    {
        
        public int IngresoId { get; set; }
        public int OrdenCompraId { get; set; }

        public int? ProveedorId { get; set; }
        public int? MotivoId { get; set; }
        public int? BodegaId { get; set; }
        public int? TipoIngresoId { get; set; }
        public DateTime Fecha { get; set; }
        public double Descuento { get; set; }
        public double Impuestos { get; set; }
        public double Total { get; set; }

        // Sets de datos que podemos usar para la vista (Recordar que esto no es necesario validarlo)
        [ValidateNever]
        public string? ProveedorNombre { get; set; }
        [ValidateNever]
        public string? MotivoNombre { get; set; } 
        [ValidateNever]
        public string? BodegaNombre { get; set; }
        [ValidateNever]
        public string? TipoIngresoNombre { get; set; }

        public virtual ICollection<IngresoDetalleViewModel>? IngresoDetalle { get; set; } // <-- Recuerda que esta va a ser tu referencia para crear y visualizar. No sirve para actualizar

        // Esta funcion recibe una lista de Ingreso y devuelve una lista de IngresoViewModel
        public static List<IngresoViewModel> ToListViewModel(IEnumerable<Ingreso> lstIngreso) // Perdon le cambie el nombre de la funcion nombre anterior ToListIngModel
        {
            
            List<IngresoViewModel> lstIngresoModelView = new List<IngresoViewModel>();
            foreach (var model in lstIngreso) 
            {
                lstIngresoModelView.Add(ToViewModel(model));
            }
            return lstIngresoModelView;
        }
        // Funcion que recibe un IngresoViewModel y devuelve un Ingreso
        public static Ingreso ToModel(IngresoViewModel modelViewIngreso)
        {
            Ingreso model = new Ingreso()
            {
                IngresoId = modelViewIngreso.IngresoId,
                OrdenCompraId = modelViewIngreso.OrdenCompraId,
                ProveedorId = modelViewIngreso.ProveedorId,
                MotivoId = modelViewIngreso.MotivoId,
                BodegaId = modelViewIngreso.BodegaId,
                TipoIngresoId = modelViewIngreso.TipoIngresoId,
                Fecha = modelViewIngreso.Fecha,
                Descuento = modelViewIngreso.Descuento,
                Impuestos = modelViewIngreso.Impuestos,
                Total = modelViewIngreso.Total, 
             
            };
            return model;
        }
        // Funcion que recibe un Ingreso y devuelve un IngresoViewModel
        public static IngresoViewModel ToViewModel(Ingreso model)
        {
            IngresoViewModel result = new IngresoViewModel()
             {
                    IngresoId = model.IngresoId,
                    OrdenCompraId = model.OrdenCompraId,
                    ProveedorId = model.ProveedorId,
                    MotivoId = model.MotivoId,
                    BodegaId = model.BodegaId,
                    TipoIngresoId = model.TipoIngresoId,
                    Fecha = model.Fecha,
                    Descuento = model.Descuento,
                    Impuestos = model.Impuestos,
                    Total = model.Total,
                    IngresoDetalle = IngresoDetalleViewModel.ToListViewModel(model.IngresoDetalle),
                    // Apartir de aqui relleno los datos extras en mi view model
                    ProveedorNombre = model.Proveedor?.RazonSocial ?? "Ninguna",
                    BodegaNombre = model.Bodega?.Direccion ?? "Ninguna",
                    MotivoNombre = model.Motivo?.Nombre ?? "Ninguna",
                    TipoIngresoNombre = model.TipoIngreso?.Nombre ?? "Ninguna"



            };
            return result;   
        }    
    }
}