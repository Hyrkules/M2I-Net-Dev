using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Structural.Decorator
{
    internal class TextInitial : ITexte
    {
        public string GetTransform(string text)
        {
            return text;
        }
    }
}
