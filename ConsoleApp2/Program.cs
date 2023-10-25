using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        internal class Oceanarium :  IEnumerator<OceanAnimal>
        {
            protected List<OceanAnimal> animals;
            protected int _position = -1;

            public OceanAnimal Current { get { return animals[_position];} }

            object IEnumerator.Current { get; }

            public Oceanarium(List<OceanAnimal> animals)
            {
                this.animals = animals;
            }
            public Oceanarium(uint size = 0)  //uint - чтобы не писать try catch для отрицательного размера
            {
                animals = new List<OceanAnimal> ((int)size);
            }

            public void PushAnimal(OceanAnimal animal)
            {
                animals.Add(animal);
            }

            public void PopAnimal()
            {
                if (animals.Count >= 1) animals.RemoveAt(animals.Count - 1);
            }

            public IEnumerator<OceanAnimal> GetEnumerator()
            {
                return animals.GetEnumerator();
            }

            public void Dispose()
            {            
            }

            public bool MoveNext()
            {
                if (_position < animals.Count)
                {
                    _position++;
                    return true;
                }
                return false;
                
            }
            public void Reset()
            {
                _position = -1;
            }
        }

        abstract internal class OceanAnimal //абстрактный класс морского животног
            {
            protected bool _isPredator;
            public  string Type { get; set; }
            public string Name { get; set; }
            public  double Weight { get; set; }
            public bool isPredator { get { return _isPredator; } }
            public override string ToString()
            {
                return $"Type: {Type}, Name: {Name}, Weight: {Weight}, isPredator: {Convert.ToString(_isPredator)}";
            }

            public abstract void Feed();

        }

        internal class Shark : OceanAnimal
        {
            public Shark (string name, double weight)
            {
                Name = name;
                Weight = weight;
                Type = "Shark";
                _isPredator = true;
            }
            public Shark()
            {
                Name = "NoName";
                Weight = 0;
                Type = "Shark";
                _isPredator = true;
            }
            public override void Feed()
            {
                Weight *= 1.1;
            }

        }
        internal class Turtle : OceanAnimal
        {
            public Turtle(string name, double weight)
            {
                Name = name;
                Weight = weight;
                Type = "Turtle";
                _isPredator = false;
            }
            public Turtle()
            {
                Name = "NoName";
                Weight = 0;
                Type = "Turtle";
                _isPredator = false;
            }
            public override void Feed()
            {
                Weight += 1;
            }
        }
        internal class Octopus : OceanAnimal
        {
            public Octopus(string name, double weight)
            {
                Name = name;
                Weight = weight;
                Type = "Octopus";
                _isPredator = true;
            }
            public Octopus()
            {
                Name = "NoName";
                Weight = 0;
                Type = "Octopus";
                _isPredator = true;
            }
            public override void Feed()
            {
                Weight += 2;
            }
        }

        static void Main(string[] args)
        {
            Oceanarium Nemo = new Oceanarium();
            Nemo.PushAnimal(new Shark());
            Nemo.PushAnimal(new Turtle("Tortilla", 100));
            Nemo.PushAnimal(new Octopus());

            foreach (var it in Nemo)
                Console.WriteLine(it);
            Console.WriteLine();
        }
    }
}
