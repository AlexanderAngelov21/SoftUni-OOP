using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private Backpack bag = new Backpack();
        protected int oxygenDecrease = 10;
        public Astronaut(string name,double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        } 

        public double Oxygen
        {
            get { return this.oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            } 
        }

        public bool CanBreath => this.Oxygen - oxygenDecrease >= 0 ? true : false;

        public IBag Bag
        {
            get { return this.bag; }
            private set
            {
                this.bag = value as Backpack;
            }
        }

        public virtual void Breath()
        {
            this.oxygen -= 10;
        }
        public override string ToString()
        {
            return $"Name: {this.Name}{Environment.NewLine}Oxygen: {this.Oxygen}{Environment.NewLine}{this.Bag.ToString()}";
        }
    }
}
