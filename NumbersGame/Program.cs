using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args) //Vitoria Borg Vidal, SUT-21
        {
            Console.ForegroundColor = ConsoleColor.Magenta; 
            Console.WriteLine("Välkommen! Det är dags att spela 'Gissa Nummret'"); 
            Console.WriteLine("Först får du välja vilken svårighetsgrad du skulle vilja spela i! " +
                "Var snäll välj nivå från superlätt till supersvår!"); 

            int menuChoices = 6; 
            string[] choices = new string[menuChoices]; 
            bool menu = true; //Initiates the while loop below. 

            while (menu) 
            {
                Console.WriteLine();
              Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[1]Superlätt"); 
              Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[2]Lätt"); 
              Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[3]Medium"); 
              Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[4]Svår"); 
              Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[5]Supersvår"); 
              Console.ResetColor();
                Console.WriteLine("[6]Avsluta"); 
                Int32.TryParse(Console.ReadLine(), out menuChoices); 
                Console.WriteLine();                                 

                switch (menuChoices) 
                {
                    case 1: //Super easy
                        PlayGame(10, ConsoleColor.Cyan); 
                        break;

                    case 2: //Easy
                        PlayGame(15, ConsoleColor.Blue); 
                        break;

                    case 3: //Medium
                        PlayGame(30, ConsoleColor.Green); 
                        break;

                    case 4: //Hard 
                        PlayGame(60, ConsoleColor.Yellow); 
                        break;

                    case 5: //Superhard
                        PlayGame(100, ConsoleColor.Red); 
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Tack för denna gången! Vi ses nästa gång, hejdå!");
                        menu = false;
                        break;

                    default:
                        Console.WriteLine("Du har tyvärr inte valt något giltigt menyalternativ... Var vänlig och testa igen!");
                        break;
                }
            }
        }
        public static void PlayGame(int maxDecidedNum, ConsoleColor textColor) 
        {
            Random random = new Random(); 
            int decidedNum = random.Next(1, maxDecidedNum);
            int choosingNum;
            Console.ForegroundColor = textColor;
            Console.WriteLine($"Jag tänker på ett nummer mellan 1-{maxDecidedNum}. Kan du gissa vilket? Du har 5 försök!");
            for (int turn = 1; turn <= 5; turn++)
            {
                Console.ForegroundColor = textColor;
                Console.Write("Du använder nu" + " " + turn + " " + "försöket: ");
                choosingNum = Int32.Parse(Console.ReadLine());
                if (choosingNum < decidedNum)
                {
                    Console.ResetColor();
                    Console.WriteLine("Numret var snäppet för litet...");
                    if (turn == 5)
                    {
                        Console.ForegroundColor= ConsoleColor.Magenta;
                        Console.WriteLine("Game Over! Numret var" +" " + decidedNum);
                    }
                }
                else if (choosingNum > decidedNum)
                {
                    Console.ResetColor();
                    Console.WriteLine("Numret är lite för stort...");
                    if (turn == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Game Over! Numret var" + " " +decidedNum);
                    }
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine("Grattis!!! Du har väldigt bra instinkt!");
                    break;
                }
            }
        }
    }
}
