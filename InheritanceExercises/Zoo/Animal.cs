﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        private string name;
        public string Name { get; set; }

        public Animal(string name)
        {
            this.Name = name;
        }
    }
}
