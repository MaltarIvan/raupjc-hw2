using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Task2;

namespace Task3
{
    [TestClass]
    public class Task2Tests
    {
        [TestMethod]
        public void TodoItem_Equals()
        {
            TodoItem todoItem1 = new TodoItem("Some Text.");
            TodoItem todoItem2 = new TodoItem("");
            Assert.IsFalse(todoItem1.Equals(todoItem2));

            todoItem2.Id = todoItem1.Id;
            Assert.IsTrue(todoItem1.Equals(todoItem2));
        }

        [TestMethod]
        public void Todoitem_MarkAsCompleted()
        {
            TodoItem todoItem = new TodoItem("Some text!");
            Assert.IsFalse(todoItem.IsCompleted);
            todoItem.MarkAsCompleted();
            Assert.IsTrue(todoItem.IsCompleted);
        }

        [TestMethod]
        public void TodoItem_GetHashCode()
        {
            TodoItem todoItem = new TodoItem("Some Text!");
            Guid id = todoItem.Id;
            Assert.AreEqual(id.GetHashCode(), todoItem.GetHashCode());
        }

        [TestMethod]
        public void TodoRepository_Add()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem = new TodoItem("Some Text");
            todoRepository.Add(todoItem);
            try
            {
                todoRepository.Add(todoItem);
            }
            catch (DuplicateTodoItemException ex1)
            {

                Assert.AreEqual("Duplicate id: {" + todoItem.Id + "}", ex1.Message);
            }
            catch (Exception ex2)
            {
                Assert.Fail("Unexpected exception of type: " + ex2.GetType().ToString());
            }
            Assert.AreEqual(todoItem, todoRepository.Get(todoItem.Id));
        }

        [TestMethod]
        public void TodoRepository_Get()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem = new TodoItem("Some Text");
            todoRepository.Add(todoItem);
            Assert.AreEqual(todoItem, todoRepository.Get(todoItem.Id));
            Assert.AreEqual(null, todoRepository.Get(new Guid()));
        }

        [TestMethod]
        public void TodoRepository_GetActive()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem1 = new TodoItem("Some Text");
            TodoItem todoItem2 = new TodoItem("Some Text");
            TodoItem todoItem3 = new TodoItem("Some Text");
            TodoItem todoItem4 = new TodoItem("Some Text");

            todoItem4.MarkAsCompleted();

            todoRepository.Add(todoItem1);
            todoRepository.Add(todoItem2);
            todoRepository.Add(todoItem3);
            todoRepository.Add(todoItem4);

            List<TodoItem> list = todoRepository.GetActive();
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(todoItem1, list[0]);
        }

        [TestMethod]
        public void TodoRepository_GetAll()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem1 = new TodoItem("Some Text");
            TodoItem todoItem2 = new TodoItem("Some Text");
            TodoItem todoItem3 = new TodoItem("Some Text");

            todoItem1.DateCreated = todoItem1.DateCreated.AddDays(3);
            todoItem2.DateCreated = todoItem1.DateCreated.AddDays(1);

            todoRepository.Add(todoItem1);
            todoRepository.Add(todoItem2);
            todoRepository.Add(todoItem3);

            List<TodoItem> list = todoRepository.GetAll();
            Assert.AreEqual(3, list.Count);
            Assert.IsTrue(list[0].DateCreated >= list[1].DateCreated && list[1].DateCreated >= list[2].DateCreated);
        }

        [TestMethod]
        public void TodoRepository_GetCompleted()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem1 = new TodoItem("Some Text");
            TodoItem todoItem2 = new TodoItem("Some Text");
            TodoItem todoItem3 = new TodoItem("Some Text");
            TodoItem todoItem4 = new TodoItem("Some Text");

            todoItem4.MarkAsCompleted();

            todoRepository.Add(todoItem1);
            todoRepository.Add(todoItem2);
            todoRepository.Add(todoItem3);
            todoRepository.Add(todoItem4);

            List<TodoItem> list = todoRepository.GetCompleted();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(todoItem4, list[0]);
        }

        [TestMethod]
        public void TodoRepository_GetFiltered()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem1 = new TodoItem("Some Text");
            TodoItem todoItem2 = new TodoItem("Some Text");
            TodoItem todoItem3 = new TodoItem("Some Text");
            TodoItem todoItem4 = new TodoItem("");

            todoRepository.Add(todoItem1);
            todoRepository.Add(todoItem2);
            todoRepository.Add(todoItem3);
            todoRepository.Add(todoItem4);

            List<TodoItem> list1 = todoRepository.GetFiltered(i => i.Text.Equals(""));
            Assert.AreEqual(todoItem4, list1[0]);

            List<TodoItem> list2 = todoRepository.GetFiltered(i => i.Text.Equals("dfghj"));
            Assert.AreEqual(0, list2.Count);
        }

        [TestMethod]
        public void TodoRepository_MarkAsCompleted()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem1 = new TodoItem("Some Text");

            todoRepository.Add(todoItem1);

            Assert.IsFalse(todoRepository.MarkAsCompleted(new Guid()));
            Assert.IsTrue(todoRepository.MarkAsCompleted(todoItem1.Id));
            Assert.IsFalse(todoRepository.MarkAsCompleted(todoItem1.Id));
            Assert.IsTrue(todoRepository.Get(todoItem1.Id).IsCompleted);
        }

        [TestMethod]
        public void TodoRepository_Remove()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem1 = new TodoItem("Some Text");

            todoRepository.Add(todoItem1);
            Assert.IsFalse(todoRepository.Remove(new Guid()));
            Assert.IsTrue(todoRepository.Remove(todoItem1.Id));
            Assert.AreEqual(null, todoRepository.Get(todoItem1.Id));
        }

        [TestMethod]
        public void TodoRepository_Update()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem1 = new TodoItem("Some Text 1");
            TodoItem todoItem2 = new TodoItem("Some Text 2");
            todoRepository.Add(todoItem1);

            todoItem1.Text = "New Text";
            todoRepository.Update(todoItem1);
            List<TodoItem> list = todoRepository.GetAll();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("New Text", list[0].Text);

            todoRepository.Add(todoItem2);
            list = todoRepository.GetAll();
            Assert.AreEqual(2, list.Count);
        }
    }
}

