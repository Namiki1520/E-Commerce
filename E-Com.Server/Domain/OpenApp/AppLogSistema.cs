﻿using Domain.Interfaces.InterfaceLogSistema;
using Domain.Interfaces.InterfacesApp;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OpenApp
{
    public class AppLogSistema : InterfaceLogSistemaApp
    {
        private readonly ILogSistema _ILogSistema;

        public AppLogSistema(ILogSistema ILogSistema)
        {
            _ILogSistema = ILogSistema;
        }

        public async Task Add(LogSistema Objeto)
        {
            await _ILogSistema.Add(Objeto);
        }

        public async Task Delete(LogSistema Objeto)
        {
            await _ILogSistema.Delete(Objeto);
        }

        public async Task<LogSistema> GetEntityById(int Id)
        {
            return await _ILogSistema.GetEntityById(Id);
        }

        public async Task<List<LogSistema>> List()
        {
            return await _ILogSistema.List();
        }

        public async Task Update(LogSistema Objeto)
        {
            await _ILogSistema.Update(Objeto);
        }
    }
}