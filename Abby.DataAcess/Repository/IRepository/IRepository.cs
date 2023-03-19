﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAcess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //GET ALL, GET BY ID FIRST OR DEFAULT, ADD, REMOVE, REMOVERANGE
        //

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        IEnumerable<T> GetAll(string? includeProperties=null);

        T GetFirstOrDefault(Expression<Func<T, bool>>? filtert = null);  //TOHLE JE DEFINOVÁNO PEVNĚ, ABY MOHL PROGRAM OČEKÁVÁT FIRSTORDEFAUTL


    }
}
