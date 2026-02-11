using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Structural.Decorator
{
    internal class TextPointFinal : TextDecorator
    {
        public TextPointFinal(ITexte Texte) : base(Texte)
        {
        }
        public override string GetTransform(string text) => base.GetTransform(text) + ".";
    
    }
}
