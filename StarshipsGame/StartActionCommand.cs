using Hwdtech;
using System.Collections.Generic;

namespace StarshipsGame
{
    public class StartActionCommand : ICommand
    {
        private readonly IDictionary<string, object> _order;

        public StartActionCommand(IDictionary<string, object> order)
        {
            _order = order;
        }

        public void Execute()
        {
            System.Console.WriteLine("StartActionCommand executed with order keys: " + string.Join(",", _order.Keys));
        }
    }
}
