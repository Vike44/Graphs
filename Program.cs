using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Устанавливает режим высокого DPI для приложения, что позволяет ему корректно отображаться на экранах с высоким разрешением.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // Включает визуальные стили для приложения, что позволяет использовать современные визуальные эффекты и стили Windows.
            Application.EnableVisualStyles();

            // Устанавливает режим совместимости рендеринга текста. Параметр false указывает на использование GDI+ для рендеринга текста, что обеспечивает более высокое качество.
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
