using LuccaDevises.Services;

namespace LuccaDevises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage : LuccaDevises.exe <fichier de données>");
                return;
            }

            try
            {
                using var reader = new StreamReader(args[0]);
                var input = InputBuilder.BuildFrom(reader);
                var converter = new AmountConverter(input.ExchangeRates);
                var result = converter.Convert(input.InitialAmount, input.TargetCurrency);

                Console.WriteLine(Math.Round(result.Value));
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine($"Impossible de lire le fichier {args[0]}");
            }
            catch (InvalidDataException)
            {
                Console.WriteLine($"Le fichier {args[0]} est mal formé");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Une erreur s'est produite : {e.Message}");
            }
        }
    }
}