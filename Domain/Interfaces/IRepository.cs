using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// This interface works with 
    /// data in context.
    /// </summary>
    /// <typeparam name="T">The type of model</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Getting data.
        /// </summary>
        /// <returns>the list of data</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Updating data
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> Update(T item);
    }
}
