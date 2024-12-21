using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    /* Валидатор входных данных
     *Создан для проверки входных данных. 
     * Собирает всю логику проверок в одном месте. 
     * Возвращает понятный результат с текстом ошибки.*/
    public class InputValidator
    {
        public bool IsValid { get; private set; }
        public string Error { get; private set; }

        public bool Validate(string min, string max)
        {
            if (string.IsNullOrEmpty(min))
            {
                Error = "Введите границу А";
                return IsValid = false;
            }

            if (string.IsNullOrEmpty(max))
            {
                Error = "Введите границу Б";
                return IsValid = false;
            }

            if (min.Length >= 4 || max.Length >= 4)
            {
                Error = "Слишком большие границы!";
                return IsValid = false;
            }

            if (!double.TryParse(min, out double minVal) || !double.TryParse(max, out double maxVal))
            {
                Error = "Некорректные значения границ";
                return IsValid = false;
            }

            if (minVal >= maxVal)
            {
                Error = "Граница a должна быть меньше границы b";
                return IsValid = false;
            }

            return IsValid = true;
        }
    }
}
