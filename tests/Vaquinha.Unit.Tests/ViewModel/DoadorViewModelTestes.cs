using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.Domain.ViewModels;
using Xunit;

namespace Vaquinha.Unit.Tests.ViewModel
{
    public class DoadorViewModelTestes
    {

        [Fact]
        [Trait("DoadorViewModel", "DoadorViewModel_GerarDescricaoTempo_TestEmpty")]
        public void DoadorViewModel_GerarDescricaoTempo_TestEmpty()
        {
            //Arrage
            var doador = new DoadorViewModel();
            doador.DataHora = new DateTime(0001, 1, 1, 0, 0, 0);

            //Act
            string descricao = doador.DescricaoTempo;

            //Assert
            descricao.Should().Be(string.Empty);
        }

        [Theory]
        [InlineData("1 ano atrás", 31970000)]
        [InlineData("2 anos atrás", 69120000)]
        [InlineData("1 mês atrás", 3024000)]
        [InlineData("2 mêses atrás", 5616000)]
        [InlineData("1 dia atrás", 86400)]
        [InlineData("5 dias atrás", 432000)]
        [InlineData("1 hora atrás", 3600)]
        [InlineData("2 horas atrás", 7200)]
        [InlineData("1 minuto atrás", 60)]
        [InlineData("2 minutos atrás", 120)]
        [InlineData("nesse instante", 30)]
        [InlineData("nesse instante", 0)]
        [Trait("DoadorViewModel", "DoadorViewModel_GerarDescricaoTempo_TestGeral")]
        public void DoadorViewModel_GerarDescricaoTempo_TestGeral(string result, int intervaloSegundos)
        {
            //Arrage
            var doador = new DoadorViewModel();
            doador.DataHora = (DateTime.Now).AddSeconds(-intervaloSegundos);

            //Act
            string descricao = doador.DescricaoTempo;

            //Assert
            descricao.Should().Be(result);

        }
    }
}
