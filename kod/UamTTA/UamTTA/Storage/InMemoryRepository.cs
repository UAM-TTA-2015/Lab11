﻿using System.Collections.Generic;
using System.Linq;
using UamTTA.Model;

namespace UamTTA.Storage
{
    public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IEnumerator<int> _idGenerator;
        private readonly IDictionary<int, T> _storage = new Dictionary<int, T>();

        public InMemoryRepository()
        {
            _idGenerator = Enumerable.Range(1, int.MaxValue).GetEnumerator();
        }

        public IEnumerable<T> GetAll()
        {
            return _storage.Values;
        }

        public T FindById(int id)
        {
            T result;
            return !_storage.TryGetValue(id, out result) ? null : result;
        }

        public T Persist(T item)
        {
            var copy = (T) item.Clone();
            copy.Id = copy.Id.HasValue ? copy.Id : GetNextId();
            _storage[copy.Id.Value] = copy;

            return copy;
        }

        public void Remove(T item)
        {
            if (item.Id.HasValue && _storage.ContainsKey(item.Id.Value))
            {
                _storage.Remove(item.Id.Value);
            }
        }

        private int GetNextId()
        {
            _idGenerator.MoveNext();
            return _idGenerator.Current;
        }
    }
}