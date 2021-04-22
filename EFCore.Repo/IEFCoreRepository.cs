﻿using EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        // metedos genericos
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Heroi[]> GetAllHerois();
        Task<Heroi> GetHeroiById(int id);
        Task<Heroi> GetHeroiByNome(string nome);
    }
}
