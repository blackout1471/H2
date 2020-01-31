using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            NordeaBankAccount account = new NordeaBankAccount();

            // Get users name
            Console.WriteLine("Enter Your Name:");
            string personName = Console.ReadLine();

            // Get users age
            Console.WriteLine("Enter Your Age");
            int age = GetValidNumberInput();

            // list to store the available cards for the user
            List<CreditCard> availableCards = new List<CreditCard>();

            // Add the cards if possible
            try
            {
                availableCards.Add(new VisaDankortCard(personName, age, account));
            }
            catch(Exception e)
            {}

            try
            {
                availableCards.Add(new MasterCard(personName, age, account));
            }
            catch (Exception e)
            { }

            try
            {
                availableCards.Add(new VisaElectronCard(personName, age, account));
            }
            catch (Exception e)
            { }

            try
            {
                availableCards.Add(new MaestroCard(personName, age, account));
            }
            catch (Exception e)
            { }

            try
            {
                availableCards.Add(new HaeveKortCard(personName, age, account));
            }
            catch (Exception e)
            { }

            // Output message to user, which cards is available
            Console.WriteLine("You can get the following cards");
            for (int i = 0; i < availableCards.Count; i++)
                Console.WriteLine($"[{i}]{availableCards[i].GetType().ToString()}");

            // Get input from user which cards is wished for
            Console.WriteLine("Choose a number");
            bool validated = false;
            int number = 0;
            while (!validated)
            {
                number = GetValidNumberInput();

                if (number >= 0 && number < availableCards.Count)
                    validated = true;
            }

            // Get the cards choosen
            CreditCard card = availableCards[number];

            // Print the cards
            Console.WriteLine($"You choose: {card}");

            Console.ReadKey();
        }

        // loop until getting valid number from input
        private static int GetValidNumberInput()
        {
            int number = 0;
            bool validated = false;

            while (!validated)
                validated = int.TryParse(Console.ReadLine(), out number);

            return number;
        }
    }
}
