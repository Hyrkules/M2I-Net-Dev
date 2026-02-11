using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Structural.Decorator
{
    internal class TextUpper : TextDecorator
    {
        public TextUpper(ITexte Texte) : base(Texte)
        {
        }
        public override string GetTransform(string text) => base.GetTransform(text).ToUpper();
    }
}
