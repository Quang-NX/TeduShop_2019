﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TeduShop.Data.Infrastructure
{
    public interface IReponsitory<T> where T : class//where:nếu đó là class
    {
        //Định nghĩa ra các phương thức sẽ sử dụng lại nhiều lần như thêm sửa xóa

        //Add entites
        T Add(T entity);

        //Update
        void Update(T entity);

        //Delete
        T Delete(T entity);
        T Delete(int id);
        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        //get etities by id
        T GetSingleById(int id);

        T GetSingByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}