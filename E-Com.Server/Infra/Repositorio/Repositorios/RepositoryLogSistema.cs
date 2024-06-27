using Domain.Interfaces.InterfaceLogSistema;
using Entities.Entidades;
using Infra.Repositorio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio.Repositorios
{
    public class RepositoryLogSistema : RepositoryGenerics<LogSistema>, ILogSistema
    {
    }
}