namespace CursoNetMVC.Tools
{
    public interface IMatematicas
    {
        int division(int num1, int num2);
        int modulo(int num1, int num2);
        int multiplicacion(int num1, int num2);
        int resta(int num1, int num2);
        decimal suma(decimal num1, decimal num2);
    }
}