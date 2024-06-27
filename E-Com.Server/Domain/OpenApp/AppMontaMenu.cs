using Domain.Interfaces.InterfacesApp;
using Domain.Interfaces.InterfaceServices;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OpenApp
{
    public class AppMontaMenu : InterfaceMontaMenu
    {
        private readonly IServiceMontaMenu _IServiceMontaMenu;
        public AppMontaMenu(IServiceMontaMenu IServiceMontaMenu)
        {
            _IServiceMontaMenu = IServiceMontaMenu;
        }

        public async Task<List<MenuSite>> MontaMenuPorPerfil(string userID)
        {
            return await _IServiceMontaMenu.MontaMenuPorPerfil(userID);
        }
    }
}