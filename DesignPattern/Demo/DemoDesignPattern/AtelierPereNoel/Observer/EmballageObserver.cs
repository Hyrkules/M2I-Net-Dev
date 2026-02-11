using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Observer
{
    internal class EmballageObserver : IObserver    
    {
        public void Update(string message)
        {
            Console.WriteLine($"[Le lutin voit] {message}");
        }
    }
}
