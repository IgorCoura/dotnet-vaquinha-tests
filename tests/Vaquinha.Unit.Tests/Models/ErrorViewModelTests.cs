using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.MVC.Models;
using Xunit;

namespace Vaquinha.Unit.Tests.Models
{
    public class ErrorViewModelTest
    {
        [Fact]
        [Trait("ErrorViewModel", "ErrorViewModel_RequestTest")]
        public void ErrorViewModel_RequestTest()
        {
            //Arrage
            var model = new ErrorViewModel();

            //Act
            model.RequestId = "10";
            var get = model.RequestId;
            bool validar = model.ShowRequestId;

            //Assert
            get.Should().Be("10");
            validar.Should().BeTrue();
        }
    }
}
