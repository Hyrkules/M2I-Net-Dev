using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Structural.Decorator
{
    internal class TextFirstUpper : TextDecorator
    {
        public TextFirstUpper(ITexte Texte) : base(Texte)
        {
        }
        public override string GetTransform(string text)
        {
            var textTransform = base.GetTransform(text);
            return char.ToUpper(textTransform[0]) + textTransform.Substring(1);
        }
    }
}
