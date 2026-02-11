using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.Builder
{
    internal class Personne
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        private Personne(Builder builder)
        {
            FirstName = builder.FirstName ?? "";
            LastName = builder.LastName ?? "";
            Age = builder.Age;
        }

        public override string ToString()
        {
            return $"Person :\n firstname : {FirstName}\n lastName : {LastName}\n age : {Age}";
        }

        public sealed class Builder
        {
            public string? FirstName { get; private set; }
            public string? LastName { get; private set; }
            public int Age { get; private set; }

            public Builder FirstNameValue(string firstName)
            {
                FirstName = firstName;
                return this;
            }
            public Builder LastNameValue(string lastName)
            {
                LastName = lastName;
                return this;
            }
            public Builder AgeValue(int age)
            {
                Age = age;
                return this;
            }

            public Personne Build() => new(this); // égal à new Personne(this);
        }
    }
}
