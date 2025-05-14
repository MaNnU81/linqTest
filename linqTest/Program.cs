

namespace linqTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var temperatures = new List<double> { 30.5, 32.0, 31.5, 29.0, 28.5, 33.0, 34.5, 31.5, 29.0, 28.5 };
            var cities = new List<string> { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose" };
            var students = new List<Student>
            {
                new Student("Alice", 20, true),
                new Student("Bob", 22, false),
                new Student("Charlie", 21, true),
                new Student("Grace", 23, false),
                new Student("Eve", 19, true),
                new Student("Frank", 24, false),
                new Student("Grace", 20, true),
                new Student("Heidi", 22, false),
                new Student("Ivan", 21, true),
                new Student("Grace", 27, false)

            };

            var cityTemperature = new Dictionary<string, double>()
            {
                { "New York", 30.5 },
                { "Los Angeles", 32.0 },
                { "Chicago", 31.5 },
                { "Houston", 29.0 },
                { "Phoenix", 28.5 },
                { "Philadelphia", 33.0 },
                { "San Antonio", 34.5 },
                { "San Diego", 31.5 },
                { "Dallas", 29.0 },
                { "San Jose", 28.5 }
            };

            var nicknameStudent = new Dictionary<string, Student>()
            {
                {"pippo", new Student("Alice", 20, true) },
                {"pluto", new Student("Bob", 22, false) },
                {"paperino", new Student("Charlie", 21, true) },
                {"topolino", new Student("Grace", 23, false) },
                {"minnie", new Student("Eve", 19, true) },
                {"paperina", new Student("Frank", 24, false) },
                {"topa", new Student("Grace", 20, true) },
                {"pernabucco", new Student("Heidi", 22, false) },
                {"napoli", new Student("Ivan", 21, true) },
                {"felice", new Student("Grace", 27, false) }
            };


            var temperatureAbove30 = temperatures.Where(t => t > 30).OrderByDescending(t => t).ToList();


            var temperatureAbove30sql = (from t in temperatures
                                         where t > 30
                                         select t).ToList();



            for (int i = 0; i < temperatureAbove30.Count; i++)
            {
                Console.WriteLine($"{temperatureAbove30[i]} {temperatureAbove30sql[i]}");
            }


            var EsseCity = cities.Where(c => c.StartsWith("S")).Take(2).ToList();

            var EsseCitysql = (from c in cities
                               where c.StartsWith("S")
                               select c).Take(2).ToList();

            for (int i = 0; i < EsseCity.Count; i++)
            {
                Console.WriteLine($"{EsseCity[i]} {EsseCitysql[i]} ");
            }



            var studentsByNamesThenAges = students.OrderBy(s => s.Name).ThenByDescending(a => a.Age).ToList();


            for (int i = 0; i < studentsByNamesThenAges.Count; i++)
            {
                Console.WriteLine($"{studentsByNamesThenAges[i].Name} {studentsByNamesThenAges[i].Age}");
            }

            var citiesWithTemperaturesAbove30 = cityTemperature
                .Where(ct => ct.Value > 30)
                .Select(ct => ct.Key)
                .ToList();

            for (int i = 0; i < citiesWithTemperaturesAbove30.Count; i++)
            {
                Console.WriteLine($"{citiesWithTemperaturesAbove30[i]}");
            }



            /////solo i nickname, poi nickname + name, poi solo i maschi

            //var allNicknames = nicknameStudent.Keys.ToList();
            //// Stampa tutti i nickname
            //foreach (var nickname in allNicknames)
            //{
            //    Console.WriteLine(nickname);
            //}



            var allNicknames = nicknameStudent.ToList();
            Console.WriteLine("----------Soprannomi-----------");
            foreach (var entry in allNicknames)
            {
                Console.WriteLine($"{entry.Key} è il soprannome di {entry.Value.Name}");
            }



            Console.WriteLine("----------Soprannomi Maschi-----------");
            var maleNicknames = nicknameStudent.Where(entry => entry.Value.IsMale).ToList();

            foreach (var entry in maleNicknames)
            {
                Console.WriteLine($"{entry.Key} è il soprannome di {entry.Value.Name} (Maschio)");
            }



            ////////////3- faccia una media delle temperature delle citta che iniziano con la s
            Console.WriteLine("----------Temperature Average & MAX -----------");
            var averageTempSCities = cityTemperature
                                                    .Where(city => city.Key.StartsWith("S", StringComparison.OrdinalIgnoreCase))
                                                    .Average(city => city.Value);

            Console.WriteLine($"Temperatura media città con 'S': {averageTempSCities}°C");


            ///////////4- nome citta con temperatura piu alta

            // Con OrderByDescending e First
            var hottestCity = cityTemperature.OrderByDescending(entry => entry.Value).First();
            Console.WriteLine($"La città con la temperatura più alta è {hottestCity.Key} con {hottestCity.Value}°C");

           // Maxby
            var hottestCityAlt = cityTemperature.MaxBy(entry => entry.Value);
            Console.WriteLine($"La città con la temperatura più alta è {hottestCityAlt.Key} con {hottestCityAlt.Value}°C");

            /////////////////////////////prenda aray cities e temperature e fonda i due array in un dizionario (da liste e crei diionario)
            Console.WriteLine("----------Dictionary cities/temperatures-----------"); 
            var weatherDict = cities.Zip(temperatures)
                          .ToDictionary(
                              pair => pair.First,    
                              pair => pair.Second   
                          );

            
            foreach (var entry in weatherDict)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}°C");
            }

            Console.WriteLine("----------Dictionary Nicknames/Ages -----------");
            
            var NickAgeDictionary = nicknameStudent.ToDictionary(
                    entry => entry.Key,     
                    entry => entry.Value.Age 
            );

            foreach (var entry in NickAgeDictionary)
            {
                Console.WriteLine($"Nickname: {entry.Key}, Età: {entry.Value}");
            }

        }

    }

}



//////compiti
///1-riscrivere tutto cio che è stato fatto in classe ma con aggregate. (facoltativo, corrispondente a reduce).
///2- scrivere una query che mi dia tutti inickname degli studenti maschi
///3- faccia una media delle temperature delle citta che iniziano con la s
///4- nome citta con temperatura piu alta
///5- prendi list cities e temperature e crea dizionario uguale a cityTemp (list to dictionary)
///6-  prendi nick e fai dizionario nick ed age
///learn microsoft linq 