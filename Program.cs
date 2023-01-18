namespace Batalla_Naval
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            int[,] gb = new int[15, 15];
            int ships = 0;
            int dim = 0;
            string opt;

            do
            {
                Console.WriteLine($"\t\t- - - -  M E N U  - - - -\n\n");
                Console.WriteLine("\t1) Create new game.\n\t2) Play.\n\t3) Show gameboard.\n\t4) Credits.\n\t5) Quit.");
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        {
                            gb = Game.Create_new(ref ships, ref dim);
                            break;
                        }
                    case "2":
                        {
                            Game.Play(gb, ships, dim);
                            break;
                        }
                    case "3":
                        {
                            Game.Show_gameboard(gb, dim);
                            break;
                        }
                    case "4":
                        {
                            Credits();
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            Console.WriteLine("\tBye!!");
                            Thread.Sleep(800);
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid option. Try again!");
                            break;
                        }
                }
            } while (opt != "5");
        }

        static void Credits()
        {
            Console.WriteLine("\n\t\t- - - Made by: Brian Velázquez. - - -");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}