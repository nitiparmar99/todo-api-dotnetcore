using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services
{
    // Simple thread-safe in-memory store. Kept intentionally small.
    public class TodoService : ITodoService
    {
        private readonly ConcurrentDictionary<Guid, TodoItem> _store = new();

        public IEnumerable<TodoItem> GetAll()
        {
            return _store.Values;
        }

        public TodoItem Add(CreateTodoDto dto)
        {
            var item = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                IsComplete = false,
                CreatedAt = DateTime.UtcNow
            };

            _store[item.Id] = item;
            return item;
        }

        public bool Delete(Guid id)
        {
            return _store.TryRemove(id, out _);
        }

        public TodoItem? Get(Guid id)
        {
            _store.TryGetValue(id, out var item);
            return item;
        }

        public bool ToggleComplete(Guid id)
        {
            if (_store.TryGetValue(id, out var item))
            {
                item.IsComplete = !item.IsComplete;
                _store[id] = item;
                return true;
            }

            return false;
        }
    }
}
