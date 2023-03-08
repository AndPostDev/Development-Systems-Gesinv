﻿using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class MarcaViewModel
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; } = null!;

        public static MarcaViewModel ConvertToViewModel(Marca marca)
        {
            MarcaViewModel marcaViewModel = new MarcaViewModel()
            {
                MarcaId = marca.MarcaId,
                Nombre = marca.Nombre,
            };
            return marcaViewModel;
        }

        public static Marca ConvertToModel(MarcaViewModel marcaViewModel)
        {
            Marca marca = new Marca()
            {
                MarcaId = marcaViewModel.MarcaId,
                Nombre = marcaViewModel.Nombre,
            };
            return marca;
        }

        public static List<MarcaViewModel> ListViewModel(IEnumerable<Marca> lstModel)
        {
            List<MarcaViewModel> listViewModel = new List<MarcaViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }
    }
}