using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Form1()
        {
            InitializeComponent(); // Инициализация компонентов формы
            _graphManager = ZedGraphManager.GetInstance(zedGraphControl1); // Получение объекта управления графиками через ZedGraphManager
            _graphManager.Initialize(); // Инициализация графического менеджера
            _validator = new InputValidator(); // Создание валидатора входных данных
        }
        
        private async void buttonras_Click(object sender, EventArgs e)
        {
            if (!_validator.Validate(textBox2.Text, textBox3.Text))
            {
                MessageBox.Show(_validator.Error);
                return;
            }

            try
            {
                string expression = textBox1.Text;
                double min = double.Parse(textBox2.Text);
                double max = double.Parse(textBox3.Text);
                string request = $"{expression}|{min}|{max}";

                string response = await SendToServerAsync(request);

                if (!string.IsNullOrEmpty(response))
                {
                    _graphManager.Clear();
                    _graphManager.DrawFunction(expression, min, max);
                    MessageBox.Show("График успешно построен!", "Успех");
                }
                else
                {
                    MessageBox.Show("Ошибка при обработке данных на сервере.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private async Task<string> SendToServerAsync(string request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        socket.Connect("127.0.0.1", 5000);

                        byte[] data = Encoding.UTF8.GetBytes(request);
                        socket.Send(data);

                        byte[] buffer = new byte[4096];
                        int bytesRead = socket.Receive(buffer);
                        return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка соединения с сервером: {ex.Message}");
                    return string.Empty;
                }
            });
        }
        private async void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var command = new ClearGraphCommand(_graphManager);
            await command.Execute();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46) e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешены только цифры, Backspace, запятая и минус
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45)
                e.Handled = true;
        }
        
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close(); 
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