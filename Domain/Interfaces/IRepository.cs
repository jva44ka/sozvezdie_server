using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class, IDataModel
    {
        /// <summary>
        /// Получение списка сущностей
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Асинхронное получение списка сущностей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync();

        /// <summary>
        /// Получение одного экземпляра по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Асинхронное получение одного экземпляра по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);
    }
}
