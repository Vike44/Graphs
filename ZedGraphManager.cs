using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ZedGraph;

namespace Lab_2
{
    // Реализация менеджера графика
    public class ZedGraphManager : IGraphManager
    {
        private static ZedGraphManager _instance;
        private readonly ZedGraphControl _control;
        private readonly PointPairList _points;

        private ZedGraphManager(ZedGraphControl control)
        {
            _control = control;
            _points = new PointPairList();
        }

        public static ZedGraphManager GetInstance(ZedGraphControl control)
        {
            return _instance ??= new ZedGraphManager(control);
        }

        public void Initialize()
        {
            var pane = _control.GraphPane;
            pane.Border.Color = Color.Black;
            pane.Chart.Border.Color = Color.Black;
            pane.Fill.Type = FillType.Solid;
            pane.Fill.Color = Color.FromArgb(50, 49, 69);
            pane.Chart.Fill.Type = FillType.Solid;
            pane.Chart.Fill.Color = Color.Black;
            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = true;
            pane.XAxis.Color = Color.CornflowerBlue;
            pane.YAxis.Color = Color.CornflowerBlue;
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.Color = Color.FromArgb(62, 120, 138);
            pane.YAxis.MajorGrid.Color = Color.FromArgb(62, 120, 138);
            pane.XAxis.Title.FontSpec.FontColor = Color.Silver;
            pane.YAxis.Title.FontSpec.FontColor = Color.Silver;
            pane.XAxis.Scale.FontSpec.FontColor = Color.Silver;
            pane.YAxis.Scale.FontSpec.FontColor = Color.Silver;
            pane.Title.FontSpec.FontColor = Color.White;
        }

        public void Clear()
        {
            _points.Clear();
            _control.GraphPane.CurveList.Clear();
            _control.GraphPane.GraphObjList.Clear();
            _control.AxisChange();
            _control.Invalidate();
        }

        public void DrawFunction(string expression, double min, double max)
        {
            var calculator = new FunctionCalculator(expression);
            _points.Clear();

            for (double x = min; x <= max; x += 0.1)
            {
                _points.Add(x, calculator.Calculate(x));
            }

            _control.GraphPane.AddCurve(expression, _points, Color.Blue, SymbolType.None);
            _control.GraphPane.Title.Text = "График " + expression;
            _control.AxisChange();
            _control.Invalidate();
        }
    }
}
