using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypeLesson
{
    internal class Planet
    {
        public Guid Id;
        public string Name {  get; set; }
        public int Number { get; set; }
        public int Equator { get; set; }
        public Guid PreviousPlanetId { get; set; }

        public Planet(string name, int number, int equator, Guid previousPlanetId) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Number = number;
            Equator = equator;
            PreviousPlanetId = previousPlanetId;
        }
    }
}
