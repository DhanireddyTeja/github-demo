using AutoFixture;
using Employee.Controllers;
using Employee.Models;
using Employee.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee
{
    [TestClass]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeRepository> _employeeRepoMock;
        private Fixture _fixture;
        private EmployeeModelsController _controller;

        public EmployeeControllerTests()
        {
            _fixture = new Fixture();
            _employeeRepoMock = new Mock<IEmployeeRepository>();
        }
        [TestMethod]
        public async Task Get_EmployeeModels_Return()
        {
            var employeeList = _fixture.CreateMany<EmployeeModels>(3).ToList();

            _employeeRepoMock.Setup(Repository => Repository.Get()).Returns(employeeList);

            _controller = new EmployeeModelsController(_employeeRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task Get_Employee_ThrowException()
        {
            _employeeRepoMock.Setup(repo => repo.Get()).Throws(new Exception());

            _controller = new EmployeeModelsController(_employeeRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task Post_Employee_ReturningOK()
        {
            var employee = _fixture.Create<EmployeeModels>();

            _employeeRepoMock.Setup(repo => repo.Post(It.IsAny<EmployeeModels>())).Returns(employee);
            _controller = new EmployeeModelsController(_employeeRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task Put_Employee_ReturnOK()
        {
            var employee = _fixture.Create<EmployeeModels>();

            _employeeRepoMock.Setup(repo => repo.Put(It.IsAny<EmployeeModels>())).Returns(employee);
            _controller = new EmployeeModelsController(_employeeRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task Delete_Employee_ReturnOK()
        {
            _employeeRepoMock.Setup(repo => repo.Delete(It.IsAny<int>())).Returns(true);
            _controller = new EmployeeModelsController(_employeeRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
