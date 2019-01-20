using App.Data.DataBase;
using App.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {

        private readonly DbContext _context;
        private AppModel model;

        public AppUnitOfWork(DbContext context) {
            _context = context;
            this.CategoriaRepository = new CategoriaRepository(context);
        }

        public ICategoriaRepository CategoriaRepository { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
