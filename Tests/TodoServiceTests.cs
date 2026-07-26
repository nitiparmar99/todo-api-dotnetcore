using System.Linq;
using TodoApi.DTOs;
using TodoApi.Services;
using NUnit.Framework;

namespace TodoApi.Tests
{
    public class TodoServiceTests
    {
        [Test]
        public void Add_ShouldStoreAndReturnItem()
        {
            var svc = new TodoService();
            var dto = new CreateTodoDto { Title = "Test", Description = "desc" };

            var added = svc.Add(dto);

            Assert.NotNull(added);
            Assert.AreEqual(dto.Title, added.Title);
            Assert.AreEqual(dto.Description, added.Description);
            Assert.False(added.IsComplete);
            Assert.That(svc.GetAll(), Has.Exactly(1).Items);
        }

        [Test]
        public void Delete_RemovesItem()
        {
            var svc = new TodoService();
            var dto = new CreateTodoDto { Title = "ToDelete" };
            var added = svc.Add(dto);

            var ok = svc.Delete(added.Id);

            Assert.True(ok);
            Assert.IsEmpty(svc.GetAll());
        }

        [Test]
        public void ToggleComplete_TogglesFlag()
        {
            var svc = new TodoService();
            var added = svc.Add(new CreateTodoDto { Title = "toggle" });

            var first = svc.ToggleComplete(added.Id);
            Assert.True(first);
            var item = svc.Get(added.Id);
            Assert.True(item!.IsComplete);

            var second = svc.ToggleComplete(added.Id);
            Assert.True(second);
            Assert.False(svc.Get(added.Id)!.IsComplete);
        }
    }
}
