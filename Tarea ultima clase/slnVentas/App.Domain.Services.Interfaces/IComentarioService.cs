using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface IComentarioService
    {

        IEnumerable<Comentario> GetAll();
        bool Save(Comentario comentario);

        //Comentario GetById(int id);
    }
}
