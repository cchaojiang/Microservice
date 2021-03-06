﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
   public  interface IBaseRepository<T> where T : class
    {
        Task<T> QueryById(object obj_id);
        Task<bool> Add(T model);
        Task<bool> Update(T model);
        Task<bool> DeleteByIds(object[] ids);
    }
}
