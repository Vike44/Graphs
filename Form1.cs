using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        private readonly IGraphManager _graphManager; // Управление графиками
        private readonly InputValidator _validator;  // Валидатор ввода

        // Константы для перетаскивания окна
        private const int WM_NCLBUTTONDOWN = 0xA1; // Сообщение "нажатие левой кнопки мыши"
        private const int HT_CAPTION = 0x2; // Код области заголовка окна

        // Импорт внешних функций из библиотеки user32.dll
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        // Конструктор формы
        public Form1()
        {
            InitializeComponent(); // Инициализация компонентов формы
            _graphManager = Singleton.GetInstance(zedGraphControl1); // Получение объекта управления графиками через Singleton
            _graphManager.Initialize(); // Инициализация графического менеджера
            _validator = new InputValidator(); // Создание валидатора входных данных
        }

        // Обработчик кнопки "Рассчитать" для построения графика
        private async void buttonras_Click(object sender, EventArgs e)
        {
            if (!_validator.Validate(textBox2.Text, textBox3.Text))
            {
                MessageBox.Show(_validator.Error);
                return;
            }

            try
            {
                // Создание команды для построения графика
                var command = new DrawGraphCommand(
                    _graphManager,           // Менеджер графиков
                    textBox1.Text,           // Выражение функции
                    double.Parse(textBox2.Text), // Нижняя граница
                    double.Parse(textBox3.Text)  // Верхняя граница
                );

                // Асинхронное выполнение команды построения графика
                await command.Execute();
            }
            catch (Exception ex)
            {
                // Обработка исключений при ошибках выполнения
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Обработчик пункта меню "Очистить"
        private async void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var command = new ClearGraphCommand(_graphManager);
            await command.Execute();
        }

        // Ограничение ввода символов в текстовое поле для функции
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Запрещает ввод точки (символа '.')
            if (e.KeyChar == 46) e.Handled = true;
        }

        // Ограничение ввода символов в текстовое поле для нижней границы
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешены только цифры, Backspace, запятая и минус
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45)
                e.Handled = true;
        }

        // Ограничение ввода символов в текстовое поле для верхней границы
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешены только цифры, Backspace, запятая и минус
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45)
                e.Handled = true;
        }

        // Ограничение ввода в поле текстового значения для определенного формата
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если в поле уже есть 2 символа, разрешается ввод только Backspace
            if (textBox4.Text.Length == 2)
                e.Handled = e.KeyChar == 8 || !char.IsDigit(e.KeyChar);
            else
                // Если меньше 2 символов, разрешается ввод цифр и Backspace
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        // Обработчик пункта меню "Закрыть" для завершения работы приложения
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close(); // Закрывает текущую форму
        }

        // Обработка перемещения окна мышью
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Освобождает захват мыши
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); // Отправляет сообщение для перемещения окна
            }
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Освобождает захват мыши
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); // Отправляет сообщение для перемещения окна
            }
        }
    }
}