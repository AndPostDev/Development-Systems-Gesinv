﻿using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Services
{
    public class CondicionPagoService : GenericService<CondicionPago>, ICondicionPagoService
    {
        public CondicionPagoService(IGenericRepository<CondicionPago> respository) : base(respository)
        {
        }
    }
}