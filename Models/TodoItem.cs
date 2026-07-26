using System;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
