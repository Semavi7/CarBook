﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carbook.Persistence.Context;
using CarBook.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarBookContext _contex;

        public Repository(CarBookContext contex)
        {
            _contex = contex;
        }

        public async Task CreateAsync(T entity)
        {
            _contex.Set<T>().Add(entity);
            await _contex.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _contex.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _contex.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _contex.Set<T>().Remove(entity);
            await _contex.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _contex.Set<T>().Update(entity);
            await _contex.SaveChangesAsync();
        }
    }
}
