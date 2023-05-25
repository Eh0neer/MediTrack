using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Controls;
using System.Windows.Media;


namespace mi.net2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра класса PrintDocument
            PrintDocument pd = new PrintDocument();

            // Обработчик события печати страницы
            pd.PrintPage += new PrintPageEventHandler(PrintPageHandler);

            // Установка принтера по умолчанию
            pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[0];

            // Установка настроек печати
            Margins margins = new Margins(100, 100, 100, 100); // Отступы в пикселях
            pd.DefaultPageSettings.Margins = margins;

            // Запуск печати
            pd.Print();
        }

        // Обработчик события печати страницы
        private static void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // Создание объекта Graphics из текущего события печати
            Graphics g = e.Graphics;

            // Создание объекта Font для текста
            Font font = new Font("TimesNewRoman", 12);

            // Создание объекта Brush для цвета текста
            System.Drawing.Brush brush = System.Drawing.Brushes.Black;

            // Получение размеров страницы
            float pageWidth = e.PageBounds.Width;
            float pageHeight = e.PageBounds.Height;

            // Определение позиции для печати текста
            float x = 100; // Горизонтальное смещение
            float y = 100; // Вертикальное смещение

            // Получение ссылки на элемент управления DataGrid
            datagrid = GetYourDataGridReference(); // Замените на ссылку на свой элемент DataGrid

            // Печать заголовков столбцов
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                g.DrawString(dataGrid.Columns[i].HeaderText, font, brush, x, y);
                x += dataGrid.Columns[i].Width;
            }

            // Печать содержимого ячеек
            y += 20; // Смещение после печати заголовков

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                x = 100; // Возврат в начальную позицию по горизонтали

                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    g.DrawString(dataGrid.Rows[i].Cells[j].FormattedValue.ToString(), font, brush, x, y);
                    x += dataGrid.Columns[j].Width;
                }

                y += 20; // Смещение после печати строки
            }
        }

        private static DataGridView GetYourDataGridReference()
        {
            // Здесь вам нужно вернуть ссылку на ваш элемент управления DataGrid.
            // Если вы используете Windows Forms, у вас может быть ссылка на экземпляр класса DataGridView, например:
            // return dataGridView1;

            // Если вы используете WPF, у вас может быть ссылка на экземпляр класса DataGrid, например:
            // return dataGrid1;

            // Замените этот код на свою реализацию.
            return null;
        }
    }
}

