using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    /*Реализован через DrawGraphCommand и ClearGraphCommand. 
     * Превращает операции с графиком в объекты. 
     * Нужен для выполнения действий асинхронно и отделения вызова операции от её реализации.*/
    public interface IGraphCommand
    {
        Task Execute();
    }
    // Команды для работы с графиком
    public class DrawGraphCommand : IGraphCommand
    {
        private readonly IGraphManager _manager;
        private readonly string _expression;
        private readonly double _min;
        private readonly double _max;

        public DrawGraphCommand(IGraphManager manager, string expression, double min, double max)
        {
            _manager = manager;
            _expression = expression;
            _min = min;
            _max = max;
        }

        public async Task Execute()
        {
            await Task.Run(() => _manager.DrawFunction(_expression, _min, _max));
        }
    }

    public class ClearGraphCommand : IGraphCommand
    {
        private readonly IGraphManager _manager;

        public ClearGraphCommand(IGraphManager manager)
        {
            _manager = manager;
        }

        public async Task Execute()
        {
            await Task.Run(() => _manager.Clear());
        }
    }
}
