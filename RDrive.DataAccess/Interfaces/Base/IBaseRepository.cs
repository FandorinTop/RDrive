﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDrive.DataAccess.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        Task CreateMultiple(List<T> items);
        Task Update(T item);
        Task UpdateMultiple(List<T> items);
        Task Delete(int id);
}
}
