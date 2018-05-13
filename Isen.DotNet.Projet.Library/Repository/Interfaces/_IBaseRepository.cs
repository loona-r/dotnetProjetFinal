using System;
using System.Collections.Generic;
using Isen.DotNet.Projet.Library.Models.Base;
using Isen.DotNet.Projet.Library.Models.Implementation;

namespace Isen.DotNet.Projet.Library.Repository.Interfaces
{
    public interface IBaseRepository<T>
        where T : BaseModel
    {
        // Listes
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(
            Func<T, bool> predicate);

        // Unitaires
        T Single(int id);
        T Single(string nom);

        // Deletes
        void Delete(int id);
        void Delete(T model);
        void DeleteRange(IEnumerable<T> models);
        void DeleteRange(params T[] models);

        // Updates
        void Update(T model);
        void UpdateRange(IEnumerable<T> models);
        void UpdateRange(params T[] models);

        // Save
        void Save();
    }
}