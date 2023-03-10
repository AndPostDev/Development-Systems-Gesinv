﻿using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Contracts
{
  public interface ISalidaService : IGenericService<Salida>
  {
        Task<Salida> Registrar(Salida salida);
    }
}
