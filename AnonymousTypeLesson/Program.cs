namespace AnonymousTypeLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var venus = new
            {
                Id = Guid.NewGuid(),
                Name = "Венера",
                Number = 2,
                Equator = 38025,
                PreviousPlanet = Guid.NewGuid(),
            };

            var earth = new
            {
                Id = Guid.NewGuid(),
                Name = "Земля",
                Number = 3,
                Equator = 40075,
                PreviousPlanet = venus.Id,
            };

            var mars = new
            {
                Id = Guid.NewGuid(),
                Name = "Марс",
                Number = 4,
                Equator = 21344,
                PreviousPlanet = earth.Id,
            };

            var venusAgain = new
            {
                Id = venus.Id,
                Name = "Венера",
                Number = 2,
                Equator = 38025,
                PreviousPlanet = venus.PreviousPlanet,
            };

            Console.WriteLine($"{venus.Name} is the {venus.Number} planet from the Sun. Its equator equals to {venus.Equator}. {venus.Equals(venus)}");
            Console.WriteLine($"{earth.Name} is the {earth.Number} planet from the Sun. Its equator equals to {earth.Equator}. {earth.Equals(venus)}");
            Console.WriteLine($"{mars.Name} is the {mars.Number} planet from the Sun. Its equator equals to {mars.Equator}. {mars.Equals(venus)}");
            Console.WriteLine($"{venusAgain.Name} is the {venusAgain.Number} planet from the Sun. Its equator equals to {venusAgain.Equator}. {venusAgain.Equals(venus)}");

            //#2
            var planetCatalog = new PlanetCatalog();

            Console.WriteLine("Какую планету вы хотите найти?");

            /*
            while (true)
            {

                var userPlanetName = Console.ReadLine();
                var planetInfo = planetCatalog.GetPlanet(userPlanetName);
                if (planetInfo.Item1 is not null)
                {
                    Console.WriteLine($"Я нашел планету {userPlanetName}, она {planetInfo.Item1} от Солнца, длина ее экватора составляет {planetInfo.Item2} км.");
                }
                else
                {
                    Console.WriteLine(planetInfo.Item3);

                }
            }
            */


            //#3
            while (true)
            {

                var userPlanetName = Console.ReadLine();
                var planetInfo = planetCatalog.GetPlanet(userPlanetName, i =>
                    {
                        if (planetCatalog.attempt % 3 != 0)
                        {
                            return (true, null);
                        }
                        else
                        {
                            return (false, "Вы спрашиваете слишком часто!");
                        }
                    }
                );

                if (planetInfo.Item1 is null && (planetCatalog.attempt - 1) % 3 != 0)
                {
                    planetInfo = planetCatalog.GetPlanet(userPlanetName, i =>
                        {
                            planetCatalog.attempt--;
                            if (userPlanetName != "Лимония")
                            {
                                return (false, "Не удалось найти планету");
                            }
                            else
                            {
                                return (false, "Это запретная планета");
                            }
                        }
                    );
                }

                if (planetInfo.Item1 is not null)
                {
                    Console.WriteLine($"Я нашел планету {userPlanetName}, она {planetInfo.Item1} от Солнца, длина ее экватора составляет {planetInfo.Item2} км.");
                }
                else
                {
                    Console.WriteLine(planetInfo.Item3);

                }
            }
        }
    }
}
