using System;

class Converter
{
    public decimal DollarRate;
    public decimal EuroRate;

    public Converter(decimal dollarRate, decimal euroRate)
    {
        DollarRate = dollarRate;
        EuroRate = euroRate;
    }

    public decimal ConvertHryvniaToDollar(decimal amountInHryvnia)
    {
        return amountInHryvnia / DollarRate;
    }

    public decimal ConvertDollarToHryvnia(decimal amountInDollars)
    {
        return amountInDollars * DollarRate;
    }

    public decimal ConvertHryvniaToEuro(decimal amountInHryvnia)
    {
        return amountInHryvnia / EuroRate;
    }

    public decimal ConvertEuroToHryvnia(decimal amountInEuros)
    {
        return amountInEuros * EuroRate;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть курс долара до гривні:");
        decimal dollarRate;
        while (!decimal.TryParse(Console.ReadLine(), out dollarRate) || dollarRate == 0)
        {
            Console.WriteLine("Некоректне значення. Будь ласка, введіть курс долара");
        }

        Console.WriteLine("Введіть курс євро до гривні:");
        decimal euroRate;
        while (!decimal.TryParse(Console.ReadLine(), out euroRate) || euroRate == 0)
        {
            Console.WriteLine("Некоректне значення. Будь ласка, введіть курс євро");
        }

        Converter converter = new Converter(dollarRate, euroRate);

        while (true)
        {
            Console.WriteLine("\nОберіть опцію:");
            Console.WriteLine("1 - Конвертувати гривні в долари");
            Console.WriteLine("2 - Конвертувати долари в гривні");
            Console.WriteLine("3 - Конвертувати гривні в євро");
            Console.WriteLine("4 - Конвертувати євро в гривні");
            Console.WriteLine("5 - Вийти");

            int choice;
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Некоректне значення. Будь ласка, введіть число від 1 до 5.");
                continue; // Повернутися на початок циклу
            }

            if (choice == 5)
                break;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введіть суму в гривнях:");
                    decimal amountHryvniaToDollar = decimal.Parse(Console.ReadLine());
                    decimal dollars = converter.ConvertHryvniaToDollar(amountHryvniaToDollar);
                    Console.WriteLine($"{amountHryvniaToDollar} грн = {dollars:F2} доларів");
                    break;

                case 2:
                    Console.WriteLine("Введіть суму в доларах:");
                    decimal amountDollarToHryvnia = decimal.Parse(Console.ReadLine());
                    decimal hryvniasFromDollars = converter.ConvertDollarToHryvnia(amountDollarToHryvnia);
                    Console.WriteLine($"{amountDollarToHryvnia} доларів = {hryvniasFromDollars:F2} грн");
                    break;

                case 3:
                    Console.WriteLine("Введіть суму в гривнях:");
                    decimal amountHryvniaToEuro = decimal.Parse(Console.ReadLine());
                    decimal euros = converter.ConvertHryvniaToEuro(amountHryvniaToEuro);
                    Console.WriteLine($"{amountHryvniaToEuro} грн = {euros:F2} євро");
                    break;

                case 4:
                    Console.WriteLine("Введіть суму в євро:");
                    decimal amountEuroToHryvnia = decimal.Parse(Console.ReadLine());
                    decimal hryvniasFromEuros = converter.ConvertEuroToHryvnia(amountEuroToHryvnia);
                    Console.WriteLine($"{amountEuroToHryvnia} євро = {hryvniasFromEuros:F2} грн");
                    break;

                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }
}
