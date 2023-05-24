using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Operatorok
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Operatorok> operatorAdatok = new List<Operatorok>();

            try
            {
                File.ReadAllLines("kifejezesek.txt").ToList().ForEach(adatok => operatorAdatok.Add(new Operatorok(adatok)));
            }
            catch (IOException e)
            {
                Console.WriteLine($"Hiba történt a fájl olvasása közben: {e.Message}");
            }

            Console.WriteLine($"2. feladat: Kifejezések száma: {operatorAdatok.Count}.");

            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {operatorAdatok.Where(x => x.MuveletiJel == "mod").Count()}");

            Console.WriteLine("4. feladat:", operatorAdatok.Any(k => k.ElsoOperandus % 10 == 0 && k.MasodikOperandus % 10 == 0) ? "Van ilyen kifejezés" : "Nincs ilyen kifejezés");

            Console.WriteLine("5. feladat: Statisztika");
            string[] jelek = { "+", "-", "*", "/", "div", "mod" };
            operatorAdatok.Where(x => jelek.Contains(x.MuveletiJel)).GroupBy(x => x.MuveletiJel).ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} -> {x.Count()} db".PadLeft(20)));


            string felhasznaloKifejezes;
            try
            {
                do
                {
                    Console.WriteLine("7. feladat: Adjon meg egy kifejezést (pl.: 1 + 1):");
                    felhasznaloKifejezes = Console.ReadLine();
                    Console.WriteLine(KifejezesErtek(jelek, new Operatorok(felhasznaloKifejezes)));
                } while (felhasznaloKifejezes != "vége");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Hibás adat: {error.Message}");
            }

            List<string> kesz = new List<string>();

            using (StreamWriter writer = new StreamWriter("eredmenyek.txt"))
            {
                foreach (Operatorok op in operatorAdatok)
                {
                    string eredmeny = KifejezesErtek(jelek, op);
                    writer.WriteLine($"{Convert.ToString(op.ElsoOperandus) + Convert.ToString(op.MuveletiJel) + Convert.ToString(op.MasodikOperandus)} = {eredmeny}");
                }
            }
            static string KifejezesErtek(string[] jelek, Operatorok operatorok)
            {

                if (!jelek.Contains(operatorok.MuveletiJel))
                {
                    return "Hibás operátor!";
                }
                else
                {
                    double eredmeny;
                    switch (operatorok.MuveletiJel)
                    {
                        case "+":

                            eredmeny = operatorok.ElsoOperandus + operatorok.MasodikOperandus;
                            break;
                        case "-":
                            eredmeny = operatorok.ElsoOperandus - operatorok.MasodikOperandus;
                            break;
                        case "*":
                            eredmeny = operatorok.ElsoOperandus * operatorok.MasodikOperandus;
                            break;
                        case "/":
                            if (operatorok.MasodikOperandus == 0)
                                return "Nullával való osztás!";
                            eredmeny = operatorok.ElsoOperandus / operatorok.MasodikOperandus;
                            break;
                        case "div":
                            if (operatorok.MasodikOperandus == 0)
                                return "Nullával való osztás!";
                            eredmeny = Math.Floor(operatorok.ElsoOperandus / (double)operatorok.MasodikOperandus);
                            break;
                        case "mod":
                            if (operatorok.MasodikOperandus == 0)
                                return "Nullával való osztás!";
                            eredmeny = operatorok.ElsoOperandus % operatorok.MasodikOperandus;
                            break;
                        default:
                            return "Hibás operátor!";
                    }

                    return eredmeny.ToString();
                }

            }
        }

    }
}