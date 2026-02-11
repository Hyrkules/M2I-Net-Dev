using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Structural.Decorator
{
    internal class TextePrefixe : TextDecorator
    {
        private readonly string _prefix;

        public TextePrefixe(ITexte Texte, string prefix) : base(Texte)
        {
            _prefix = prefix;
        }
        public override string GetTransform(string text) => _prefix + base.GetTransform(text);
    }
}
