using System;
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
            // ������������� ����� �������� DPI ��� ����������, ��� ��������� ��� ��������� ������������ �� ������� � ������� �����������.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // �������� ���������� ����� ��� ����������, ��� ��������� ������������ ����������� ���������� ������� � ����� Windows.
            Application.EnableVisualStyles();

            // ������������� ����� ������������� ���������� ������. �������� false ��������� �� ������������� GDI+ ��� ���������� ������, ��� ������������ ����� ������� ��������.
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
