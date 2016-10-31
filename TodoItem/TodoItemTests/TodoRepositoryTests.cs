using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Models;
using Interfaces;

namespace Repositories.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {

        [TestMethod]
        public void GetExistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            var oldTodoItem = repository.Get(todoItem.Id);
            Assert.AreEqual(todoItem.Id, oldTodoItem.Id);
        }
        [TestMethod]
        public void GetUnexistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Beverages");
            repository.Add(todoItem);
            var oldTodoItem = repository.Get(todoItem2.Id);
            Assert.AreEqual(null, oldTodoItem);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }
        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }
        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }

        [TestMethod]
        public void RemoveExistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            bool test = repository.Remove(todoItem.Id);
            Assert.AreEqual(test, true);
        }
        [TestMethod]
        public void RemoveUnexistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Beverages");
            repository.Add(todoItem);
            bool test = repository.Remove(todoItem2.Id);
            Assert.AreEqual(test, false);
        }

        [TestMethod]
        public void UpdateExistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            todoItem.Text = "Beverages";
            repository.Update(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.AreEqual(repository.GetAll().First().Text, "Beverages");
        }
        [TestMethod]
        public void UpdateUnexistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Beverages");
            repository.Add(todoItem);
            repository.Update(todoItem2);
            Assert.AreEqual(2, repository.GetAll().Count);
        }

        [TestMethod]
        public void MarkAsCompletedExistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            bool test = repository.MarkAsCompleted(todoItem.Id);
            Assert.AreEqual(test, true);
        }
        [TestMethod]
        public void MarkAsCompletedUnexistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Beverages");
            repository.Add(todoItem);
            bool test = repository.MarkAsCompleted(todoItem2.Id);
            Assert.AreEqual(test, false);
        }

        [TestMethod]
        public void GetAllTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            Thread.Sleep(2000);
            var todoItem2 = new TodoItem("Beverages");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            List<TodoItem> list = repository.GetAll();
            Assert.IsTrue(list[0].DateCreated > list[1].DateCreated);
        }

        [TestMethod]
        public void GetActiveTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            todoItem.MarkAsCompleted();
            var todoItem2 = new TodoItem("Beverages");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            List<TodoItem> list = repository.GetActive();
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod]
        public void GetCompletedTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            todoItem.MarkAsCompleted();
            var todoItem2 = new TodoItem("Beverages");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            List<TodoItem> list = repository.GetActive();
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod]
        public void GetFilteredTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Beverages");
            repository.Add(todoItem);
            repository.Add(todoItem2);
            Func<TodoItem, bool> stringBeginning = i => i.Text.StartsWith("G");
            List<TodoItem> list = repository.GetFiltered(stringBeginning);
            Assert.AreEqual(list.Count, 1);
        }
    }
}