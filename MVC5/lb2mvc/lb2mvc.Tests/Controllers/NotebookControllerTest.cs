using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lb2mvc.DAL.Entities;
using lb2mvc.DAL.Repositories;
using lb2mvc.DAL.Interfaces;
using System.Web.Mvc;
using System.Web;
using Moq;
using System.Web.Routing;
using lb2mvc.Controllers;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using lb2mvc.Models;

namespace lb2mvc.Tests.Controllers
{
    [TestClass]
    public class NotebookControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {

            // Макеты для получения HttpContext HttpRequest 
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Arrange 
            // Макет репозитория
            var mock = new Mock<IRepository<Notebook>>();

            mock.Setup(r => r.GetAll()).Returns(new List<Notebook> {
                new Notebook { NotebookId = 1 },
                new Notebook { NotebookId = 2 },
                new Notebook { NotebookId = 3 },
                new Notebook { NotebookId = 4 },
                new Notebook { NotebookId = 5 }
            });
            

            // Создание объекта контроллера 
            var controller = new NotebookController(mock.Object)
            {
                // Создание контекста контроллера
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            // Вызов метода List
            var view = controller.List(null, 2) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Notebook> model = view.Model as PageListViewModel<Notebook>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].NotebookId);
            Assert.AreEqual(5, model[1].NotebookId); 
        }

        [TestMethod]
        public void CategoryTest()
        {
            // Макеты для получения HttpContext HttpRequest 
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            //Arrange
            var mock = new Mock<IRepository<Notebook>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Notebook> {
            new Notebook {NotebookId=1, GroupName="AMD"},
            new Notebook {NotebookId=2, GroupName="Intel"},
            new Notebook {NotebookId=3, GroupName="AMD"},
            new Notebook {NotebookId=4, GroupName="AMD"},
            new Notebook {NotebookId=5, GroupName="Intel"}
            });
            // Создание объекта контроллера
            var controller = new NotebookController(mock.Object)
            {
                // Создание контекста контроллера
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = httpContext.Object;
            //Act
            var view = controller.List("AMD", 1) as ViewResult;
            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Notebook> model = view.Model as PageListViewModel<Notebook>;
            Assert.AreEqual(3, model.Count);
            Assert.AreEqual(1, model[0].NotebookId);
            Assert.AreEqual(3, model[1].NotebookId); 
            
        }
    }
}
