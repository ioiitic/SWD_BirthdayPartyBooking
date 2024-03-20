using AutoMapper;
using BusinessObject.DTO.ResponseDTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Impl
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected IRepoWrapper _repoWrapper;
        protected IMapper _mapper;

        public BaseService(IRepoWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        public IEnumerable<T> GetAll() => _repoWrapper.GetRepository<T>().GetAll();

        public IEnumerable<T> GetAll(string[] children) => _repoWrapper.GetRepository<T>().GetAll(children);

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter) => _repoWrapper.GetRepository<T>().GetAll(filter);

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string[] children) => _repoWrapper.GetRepository<T>().GetAll(filter, children);

        public T GetById(object id) => _repoWrapper.GetRepository<T>().GetById(id);

        public ServiceResponse<object> Insert(T obj)
        {
            _repoWrapper.GetRepository<T>().Insert(obj);

            return new ServiceResponse<object>(true, "Insert successfully.");
        }
        public ServiceResponse<object> Update(T obj)
        {
            _repoWrapper.GetRepository<T>().Update(obj);
            return new ServiceResponse<object>(true, "Update successfully.");
        }
        public void Delete(object id) => _repoWrapper.GetRepository<T>().Delete(id);
    }
}
