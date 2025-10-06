namespace Weddeberekening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            decimal hourlyWage;
            decimal grossPayout;
            decimal netPayout; 
            decimal workedHours;

            decimal taxesTotal = 0;


            //Vraag om naam
            Console.WriteLine("Wat is uw naam?");
            userName = Console.ReadLine();

            //Vraag om uurloon
            Console.WriteLine("Wat is uw uurloon?");
            bool validHourlyWage = decimal.TryParse(Console.ReadLine(), out hourlyWage);

            if (!validHourlyWage || hourlyWage < 0)
            {
                Console.WriteLine("Ongeldig uurloon!");
                return;
            }

            //Vraag gewerkte uren
            Console.WriteLine("Hoeveel uren heeft u gewerkt?");
            bool validWorkedHours = decimal.TryParse(Console.ReadLine(), out workedHours);

            if (!validWorkedHours || workedHours < 0)
            {
                Console.WriteLine("Ongeldig aantal uren!");
                return;
            }

            //Bereken brutosalaris
            grossPayout = workedHours * hourlyWage;

            //Math.min pakt het kleinste tussen de twee opties
            if (grossPayout > 10000)
            {
                decimal bracket = Math.Min(grossPayout, 15000) - 10000; // deel 10.001 - 15.000
                taxesTotal += bracket * 0.2M;
            }

            if (grossPayout > 15000)
            {
                decimal bracket = Math.Min(grossPayout, 25000) - 15000; // deel 15.001 - 25.000
                taxesTotal += bracket * 0.3M;
            }

            if (grossPayout > 25000)
            {
                decimal bracket = Math.Min(grossPayout, 50000) - 25000; // deel 25.001 - 50.000
                taxesTotal += bracket * 0.4M;
            }

            if (grossPayout > 50000)
            {
                decimal bracket = grossPayout - 50000; // deel boven 50.000
                taxesTotal += bracket * 0.5M;
            }

            netPayout = grossPayout - taxesTotal;

            Console.WriteLine($"Aantal gewerkte uren: {workedHours}");
            Console.WriteLine($"Uurloon: {hourlyWage}");
            Console.WriteLine($"Brutojaarloon: {grossPayout}");
            Console.WriteLine($"Belasting: {taxesTotal}");
            Console.WriteLine($"Nettojaarloon: {netPayout}"); 
        }

    }
}
