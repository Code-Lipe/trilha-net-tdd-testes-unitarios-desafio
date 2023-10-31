using NewTalents.Services;
namespace NewTalentsTests;

public class CalculadoraTest
{
    public Calculadora construirClasse()
    {
        string data = DateTime.Now.ToString("dd/MM/yyyy");
        Calculadora calc = new Calculadora(data);

        return calc;
    }

    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void TesteSomar(int valor1, int valor2, int resultadoEsperado)
    {
        Calculadora calc = construirClasse();

        int calcularResultado = calc.Somar(valor1, valor2);

        Assert.Equal(resultadoEsperado, calcularResultado);
    }

    [Theory]
    [InlineData (1, 2, 2)]
    [InlineData (4, 5, 20)]
    public void TesteMultiplicar(int valor1, int valor2, int resultadoEsperado)
    {
        Calculadora calc = construirClasse();

        int calcularResultado = calc.Multiplicar(valor1, valor2);

        Assert.Equal(resultadoEsperado, calcularResultado);
    }

    [Theory]
    [InlineData (6, 2, 4)]
    [InlineData (5, 5, 0)]
    public void TesteSubtrair(int valor1, int valor2, int resultadoEsperado)
    {
        Calculadora calc = construirClasse();

        int calcularResultado = calc.Subtrair(valor1, valor2);

        Assert.Equal(resultadoEsperado, calcularResultado);
    }

    [Theory]
    [InlineData (6, 2, 3)]
    [InlineData (5, 5, 1)]
    public void TesteDividir(int valor1, int valor2, int resultadoEsperado)
    {
        Calculadora calc = construirClasse();

        int calcularResultado = calc.Dividir(valor1, valor2);

        Assert.Equal(resultadoEsperado, calcularResultado);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Calculadora calc = construirClasse();

        Assert.Throws<DivideByZeroException>(() => calc.Dividir(3, 0));
    }

    [Fact]
    public void TestarHistorico()
    {
        Calculadora calc = construirClasse();

        calc.Somar(1, 2);
        calc.Somar(2, 8);
        calc.Somar(3, 7);
        calc.Somar(4, 1);

        var lista = calc.Historico();

        Assert.NotEmpty(calc.Historico());
        Assert.Equal(3, lista.Count);
    }
}