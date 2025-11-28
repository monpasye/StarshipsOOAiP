using System.Collections.Generic;
using StarshipsGame;
using Hwdtech;

namespace StarshipsGame
{
    public class StopActionCommand : Hwdtech.ICommand
    {
        private readonly IDictionary<string, object> _order;

        public StopActionCommand(IDictionary<string, object> order)
        {
            _order = order;
        }

        public void Execute()
        {
            // тут вроде как остановка за константное время потому что метод пустой и ничего не делает
        }
    }
}
