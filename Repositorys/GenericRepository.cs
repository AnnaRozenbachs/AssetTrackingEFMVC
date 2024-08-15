using AssetTrackingEFMVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEFMVC.Repositorys
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public AssetsContext _context;
        public ILogger _logger;
        public GenericRepository(AssetsContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            Save();
        }

        public List<T> GetAll() 
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ee)
            {
                _logger.LogError($"Somethinq went wrong: {ee.InnerException}");
            }
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            Save();
        }
    }
}
