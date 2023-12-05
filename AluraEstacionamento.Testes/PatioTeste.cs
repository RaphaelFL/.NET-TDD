using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AluraEstacionamento.Testes
{
    public class patioTeste : IDisposable
    {
        private Patio patioTest;
        private Veiculo veiculoTest;
        private ITestOutputHelper SaidaConsoleTest;
        private Operador operadorTest;

        public patioTeste(ITestOutputHelper _saidaConsoleTest)
        {
            SaidaConsoleTest = _saidaConsoleTest;
            veiculoTest = new Veiculo();
            patioTest = new Patio();
            operadorTest = new Operador();
            operadorTest.Nome = "Ronaldinho";

        }

                [Fact]
        public void ValidarFaturamento()
        {
            // Arrange
            var patioTest = dados();

            //Act
            double faturament = patioTest.TotalFaturado();

            //Assert
            Assert.Equal(2, faturament);
        }

        public Patio dados()
        {
            //var patioTest = new Patio();
            //var veiculoTest = new Veiculo();
            veiculoTest.Proprietario = "Ronaldo";
            veiculoTest.Tipo = TipoVeiculo.Automovel;
            veiculoTest.Cor = "Verde";
            veiculoTest.Placa = "and-8888";
            patioTest.OperadorPatio = operadorTest;
            patioTest.RegistrarEntradaVeiculo(veiculoTest);
            patioTest.RegistrarSaidaVeiculo(veiculoTest.Placa);
            return patioTest;
        }

        [Theory]
        [InlineData("Carlos","ASF-7894","preto","Gol")]
        [InlineData("Julho", "AFF-7894", "preto", "Eco Ford")]
        [InlineData("Antonio", "WRR-7894", "preto", "Palio")]
        public void ValidarFaturamentoComVariosVeiculos(string proprietario,
                                                        string placa,
                                                        string cor,
                                                        string modelo)
        {
            //var patioTest = new Patio();
            //var veiculoTest = new Veiculo();
            veiculoTest.Proprietario = proprietario;
            veiculoTest.Tipo = TipoVeiculo.Automovel;
            veiculoTest.Cor = cor;
            veiculoTest.Placa = placa;
            veiculoTest.Modelo = modelo;
            patioTest.OperadorPatio = operadorTest;
            patioTest.RegistrarEntradaVeiculo(veiculoTest);
            patioTest.RegistrarSaidaVeiculo(veiculoTest.Placa);

            //Act
            double faturament = patioTest.TotalFaturado();

            //Assert
            Assert.Equal(2, faturament);
        }

        [Theory]
        [InlineData("Micalatei", "SEX-6924", "azul", "fusca")]
        public void LocalizarVeiculoNoPatioComBaseNoId(string proprietario,
                                                        string placa,
                                                        string cor,
                                                        string modelo)
        {
            //Arrange
            //var patioTest = new Patio();
            //var veiculoTest = new Veiculo();
            veiculoTest.Proprietario = proprietario;
            veiculoTest.Tipo = TipoVeiculo.Automovel;
            veiculoTest.Cor = cor;
            veiculoTest.Placa = placa;
            veiculoTest.Modelo = modelo;
            patioTest.OperadorPatio = operadorTest;
            patioTest.RegistrarEntradaVeiculo(veiculoTest);
            //Act
            var consultado = patioTest.PesquisaVeiculo(veiculoTest.IdTicket);

            //Assert
            Assert.Contains("###Ticket Estacionamento Alura###", consultado.Ticket);

        }

        public void Dispose()
        {
            SaidaConsoleTest.WriteLine("Construtor chamado patio.");
        }
    }
}
