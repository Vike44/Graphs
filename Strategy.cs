using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    /* Калькулятор для вычисления значений функции
     * Применяется для изоляции алгоритма вычисления значений функции.
     * Позволяет менять способ расчета, не трогая основной код.
     * Содержит один главный метод для вычисления значения.*/
    public class FunctionCalculator
    {
        private readonly string _expression;

        public FunctionCalculator(string expression)
        {
            _expression = expression;
        }

        public double Calculate(double x)
        {
            try
            {
                var arg = new Argument("x");
                arg.setArgumentValue(x);
                var expr = new Expression(_expression.Replace(',', '.'), arg);
                return expr.calculate();
            }
            catch
            {
                return 0;
            }
        }
    }
}
