using BusinessObject.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string[] children);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string[] children);
        T GetById(object id);
        ServiceResponse<object> Insert(T obj);
        ServiceResponse<object> Update(T obj);
        void Delete(object id);
    }
}
