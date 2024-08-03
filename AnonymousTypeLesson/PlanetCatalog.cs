using System.Xml.Linq;

namespace AnonymousTypeLesson
{
    internal class PlanetCatalog
    {
        private List<Planet> _planets;
        public int attempt = 1;

        public PlanetCatalog()
        {
            _planets = new List<Planet>();

            var venus = new Planet("Венера", 2, 38025, Guid.NewGuid());
            var earth = new Planet("Земля", 3, 40075, venus.Id);
            var mars = new Planet("Марс", 4, 21344, earth.Id);

            _planets.Add(venus);
            _planets.Add(earth);
            _planets.Add(mars);
        }

        /*
        public (bool, string?) PlanetValidator(string name)
        {
            if (attempt % 3 != 0)
            {
                return (true, null);
            }
            else
            {
                return (false, "Вы спрашиваете слишком часто!");
            }
        }
        */

        public (int?, int?, string?) GetPlanet(string name)
        {
            List<int> numbers = new List<int>();
            List<int> equators = new List<int>();
            if (attempt % 3 != 0)
            {
                attempt++;
                for (int i = 0; i < _planets.Count; i++)
                {
                    if (_planets[i].Name == name)
                    {
                        numbers.Add(_planets[i].Number);
                        equators.Add(_planets[i].Equator);
                    }
                }
                if (numbers.Any())
                {
                    return (numbers.FirstOrDefault(), equators.FirstOrDefault(), null);
                }
                else
                {
                    return (null, null, "Не удалось найти планету");
                }
            }
            else
            {
                attempt++;
                return (null, null, "Вы спрашиваете слишком часто!");
            }
        }

        public (int?, int?, string?) GetPlanet(string name, PlanetValidatorDeligate planetValidatorDeligate)
        {
            List<int> numbers = new List<int>();
            List<int> equators = new List<int>();

            var validation = planetValidatorDeligate(name);
            var isValide = validation.Item1;
            var message = validation.Item2;

            if (isValide)
            {
                attempt++;
                for (int i = 0; i < _planets.Count; i++)
                {
                    if (_planets[i].Name == name)
                    {
                        numbers.Add(_planets[i].Number);
                        equators.Add(_planets[i].Equator);
                    }
                }
                if (numbers.Any())
                {
                    return (numbers.FirstOrDefault(), equators.FirstOrDefault(), null);
                }
                else
                {
                    return (null, null, "Не удалось найти планету");
                }
            }
            else
            {
                attempt++;
                return (null, null, message);
            }
        }

    }
}