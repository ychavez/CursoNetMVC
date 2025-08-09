namespace CursoNetMVC.Tools
{
    public class Matematicas : IMatematicas
    {
        public Matematicas(IConfiguration configuration)
        {
            
        }

        public decimal suma(decimal num1, decimal num2)
        {
            return num1 + num2;
        }

        public int resta(int num1, int num2)
        {
            return num1 - num2;
        }

        public int multiplicacion(int num1, int num2)
        {
            return num1 * num2;
        }

        public int division(int num1, int num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("No se puede dividir por cero.");
            return num1 / num2;
        }

        public int modulo(int num1, int num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("No se puede calcular el módulo con divisor cero.");
            return num1 % num2;
        }
    }
}
