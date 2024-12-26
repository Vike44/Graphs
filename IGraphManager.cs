using Lab_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ZedGraph;

namespace Lab_2
{
    /*Используется в ZedGraphManager для создания единственного экземпляра управления графиком. 
     * Нужен, чтобы все части программы работали с одним и тем же объектом графика. 
     * Реализован через приватный конструктор и статический метод получения экземпляра.*/
    public interface IGraphManager
    {
        void Initialize();
        void Clear();
        void DrawFunction(string expression, double min, double max);
    }
}