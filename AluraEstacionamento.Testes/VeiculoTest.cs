using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System.Xml.Serialization;
using Xunit.Abstractions;

namespace AluraEstacionamento.Testes
{
    public class VeiculoTest : IDisposable
    {

        private Veiculo veiculo;
        private ITestOutputHelper SaidaConsoleTest;
        public VeiculoTest(ITestOutputHelper _saidaConsoleTest)
        {
            SaidaConsoleTest = _saidaConsoleTest;
            veiculo = new Veiculo();
        }

        [Fact]
        [Trait ("Funcionalidade", "Acelerar")]
        public void TesteVeiculoAcelerarComParamentro10()
        {
            //var veiculo = new Veiculo();
            veiculo.Acelerar(10);
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void testaVeiculoFrear()
        {
            //var vaiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact (Skip = "Test ainda não implementado. ignorar")]
        public void validarNomeProprieratioComParamentro10()
        {

        }

        [Fact]
        public void DadosAutomovel()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo: ", dados);
        }

        [Fact]
        public void TesteNomeProprietarioVeicoloComMenosDe3Caracteres()
        {   
            //Arrange
            string nomeProprietario = "ad";

            //Act
            Assert.Throws<System.FormatException>(
                //Assert
                () => new Veiculo(nomeProprietario));
        }

        [Fact]
        public void TestmensagemdeExcecaoDoQUartoCaracterDaPlaca()
        {
            //Arrange
            string placa = "DASD8888";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa);

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTest.WriteLine("Construtor chamado veiculo.");
        }
    }
}