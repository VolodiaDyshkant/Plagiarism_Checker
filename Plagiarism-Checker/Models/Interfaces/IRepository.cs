using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.Interfaces
{
    public interface IRepository<T> 
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
