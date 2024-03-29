﻿using EmployeeService.Controllers;
using EmployeeService.Data;
using EmployeeService.Models.Dto;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using EmployeeService07.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceTests
{
    public class DictionariesControllerTests
    {
        private readonly DictionariesController _dictionariesController;
        private readonly Mock<IEmployeeTypeRepository> _mockEmployeeTypeRepository;

        public DictionariesControllerTests()
        {
            _mockEmployeeTypeRepository = new Mock<IEmployeeTypeRepository>();
            _dictionariesController = new DictionariesController(_mockEmployeeTypeRepository.Object);
        }

        [Fact]
        public void GetAllEmployeeTypesTest()
        {
            //[1] Подготовка данных

            _mockEmployeeTypeRepository.Setup(repository =>
            repository.GetAll()).Returns(new List<EmployeeType>());

            //[2] Исполнение тестируемого метода
            var result = _dictionariesController.GetAllEmployeeTypes();

            _mockEmployeeTypeRepository.Verify(repository =>
            repository.GetAll(), Times.Once());

            //[3] Подготовка эталонного результата и проверка на валидность
            //Assert.IsAssignableFrom<ActionResult<IList<EmployeeTypeDto>>>(result);
        }

        [Theory]
        [InlineData("test1")]
        [InlineData("test2")]
        [InlineData("test3")]
        public void CreateEmployeeTypeTest(string description)
        {
            _mockEmployeeTypeRepository.Setup(repository =>
            repository.Create(It.IsAny<EmployeeType>())).Verifiable();

            var result = _dictionariesController.CreateEmployeeType(description);

            _mockEmployeeTypeRepository.Verify(repository =>
            repository.Create(It.IsAny<EmployeeType>()), Times.Once());

            //Assert.IsAssignableFrom<ActionResult<int>>(result);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteEmployeeTypeTest(int id)
        {
            _mockEmployeeTypeRepository.Setup(repository =>
            repository.Delete(It.IsAny<int>())).Verifiable();
            var result = _dictionariesController.DeleteEmployeeType(id);

            _mockEmployeeTypeRepository.Verify(repository =>
            repository.Delete(It.IsAny<int>()), Times.Once());
            //Assert.IsAssignableFrom<ActionResult<bool>>(result);
        }
    }
}
