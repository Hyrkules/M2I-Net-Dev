using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Structural.Decorator
{
    internal abstract class TextDecorator : ITexte
    {
        protected readonly ITexte Texte;

        protected TextDecorator(ITexte Texte)
        {
            this.Texte = Texte;
        }

        public virtual string GetTransform(string text) => Texte.GetTransform(text);
    }
}
