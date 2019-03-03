using App.Data.Repository;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ComentarioService : IComentarioService
    {
        public IEnumerable<Comentario> GetAll()
        {
            IEnumerable<Comentario> result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ComentarioRepository.GetAll().ToList();
            }

            return result;

        }

        public bool Save(Comentario comentario)
        {
            bool result = false;
            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {
                    if (comentario.ComentarioID == 0)
                    {
                        unitOfWork.ComentarioRepository.Add(comentario);
                    }
                    else
                    {
                        unitOfWork.ComentarioRepository.Update(comentario);
                    }
                    unitOfWork.Complete();
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


    }
}
