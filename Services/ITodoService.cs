using System;
using System.Collections.Generic;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Add(CreateTodoDto dto);
        bool Delete(Guid id);
        TodoItem? Get(Guid id);
        bool ToggleComplete(Guid id);
    }
}
