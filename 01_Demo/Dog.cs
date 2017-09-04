using System;

namespace _01_Demo
{
    class Dog : Animal
    {
        // Error: cannot change tuple element names when overriding.

        public override (int ID, string AnimalName) M1()
        {
            throw new NotImplementedException();
        }
    }
}