namespace Batalla_Naval
{
    internal class Game
    {
        public static int[,] Create_new(ref int ships, ref int dim)
        {
            int[,] gb = Gameboard_dimensions(ref dim);
            ships = Ships_query();
            Ships_placement(ref gb, ships, dim);

            return gb;
        }

        public static int[,] Gameboard_dimensions(ref int dim)
        {
            Console.Clear();
            Console.WriteLine("Now, enter the dimension of the gameboard (5, 6, 10, etc): ");
            string aux = Console.ReadLine();

            // Pseudologic to make sure the dimension is an integer > 5 and < 15.
            while (!int.TryParse(aux, out dim))
            {
                Console.WriteLine("\nInvalid dimension. Try again!");
                Console.WriteLine("Dimension of the gameboard: "); aux = Console.ReadLine();
            }
            while (dim < 5 || dim > 15)
            {
                Console.WriteLine("\nThe dimension must be bigger than 5 and smaller than 15. Try again!");
                Console.WriteLine("Dimension of the gameboard: "); aux = Console.ReadLine();
                while (!int.TryParse(aux, out dim))
                {
                    Console.WriteLine("\nInvalid dimension. Try again!");
                    Console.WriteLine("Dimension of the gameboard: "); aux = Console.ReadLine();
                }
            }


            int[,] gameboard = new int[dim, dim];
            Show_gameboard_null(gameboard, dim);
            return gameboard;
        }

        public static void Show_gameboard_null(int[,] gb, int len)
        {
            Console.Clear();
            Console.WriteLine("\t\tThis is how the gameboard looks like:\n");
            for (int r = 0; r < len; r++)
            {
                Console.Write("\n");
                for (int c = 0; c < len; c++)
                {
                    Console.Write("[0]");
                }
            }
        }

        public static void Ships_placement(ref int[,] gb, int ships, int dim)
        {
            /*/Console.WriteLine("Ships positions manual or automatic? (M/A): ");
            string mode = Console.ReadLine();

            if(mode == "M") { Manual_ship_placement(); }
            else if(mode == "F") { Automatic_ship_placement(); }/*/

            Console.Clear();
            Random rnd = new Random();
            int p1, p2, p3, inf_loop;
            for (int i = 0; i < ships; i++)
            {
                p1 = rnd.Next(0, dim);
                p2 = rnd.Next(0, dim);
                gb[p1, p2] = 1;
                p3 = rnd.Next(1, 3);

                if (p3 == 1)
                {
                    inf_loop = Where_to_place(ref gb, p1, p2, "V", dim);
                }
                else
                {
                    inf_loop = Where_to_place(ref gb, p1, p2, "H", dim);
                }

                if (inf_loop == 1) { i--; }
            }
        }

        public static int Where_to_place(ref int[,] gb, int p1, int p2, string orientation, int dim)
        {
            int placed = 0;
            int flag = 0;
            int loops = 0;
            if (orientation == "H")
            {
                while (placed != 2 && loops < 4)
                {
                    if (inBounds(p1 - 1, p2, dim))
                    {
                        if (gb[p1 - 1, p2] == 0)
                        {
                            flag += 1;
                            gb[p1 - 1, p2] = 1;
                            placed += 1;
                        }
                    }
                    if (flag == 0)
                    {
                        if (inBounds(p1 + 1, p2, dim))
                        {
                            if (gb[p1 + 1, p2] == 0)
                            {
                                flag += 1;
                                gb[p1 + 1, p2] = 1;
                                placed += 1;
                            }
                        }
                    }
                    if (flag == 0)
                    {
                        if (inBounds(p1 - 2, p2, dim))
                        {
                            if (gb[p1 - 2, p2] == 0)
                            {
                                flag += 1;
                                gb[p1 - 2, p2] = 1;
                                placed += 1;
                            }
                        }
                    }
                    if (flag == 0)
                    {
                        if (inBounds(p1 + 2, p2, dim))
                        {
                            if (gb[p1 + 2, p2] == 0)
                            {
                                gb[p1 + 2, p2] = 1;
                                placed += 1;
                            }
                        }
                    }
                    flag = 0;
                    loops++;
                }
            }
            else
            {
                while (placed != 2 && loops < 4)
                {
                    if (inBounds(p1, p2 - 1, dim))
                    {
                        if (gb[p1, p2 - 1] == 0)
                        {
                            flag += 1;
                            gb[p1, p2 - 1] = 1;
                            placed += 1;
                        }
                    }
                    if (flag == 0)
                    {
                        if (inBounds(p1, p2 + 1, dim))
                        {
                            if (gb[p1, p2 + 1] == 0)
                            {
                                flag += 1;
                                gb[p1, p2 + 1] = 1;
                                placed += 1;
                            }
                        }
                    }
                    if (flag == 0)
                    {
                        if (inBounds(p1, p2 - 2, dim))
                        {
                            if (gb[p1, p2 - 2] == 0)
                            {
                                flag += 1;
                                gb[p1, p2 - 2] = 1;
                                placed += 1;
                            }
                        }
                    }
                    if (flag == 0)
                    {
                        if (inBounds(p1, p2 + 2, dim))
                        {
                            if (gb[p1, p2 + 2] == 0)
                            {
                                gb[p1, p2 + 2] = 1;
                                placed += 1;
                            }
                        }
                    }
                    flag = 0;
                    loops++;
                }
            }
            if (loops > 2) { return 1; }
            else { return 0; }
        }

        public static bool inBounds(int i1, int i2, int size)
        {
            return (i1 >= 0) && (i2 >= 0) && (i1 < size) && (i2 < size);
        }

        public static int Ships_query()
        {
            Console.WriteLine("\n\n\tEnter the amount of ships you want (1 to 5): ");
            int amo = int.Parse(Console.ReadLine());

            while (amo < 1 || amo > 5)
            {
                Console.WriteLine("Invalid amount of ships. Try again!");
                Console.WriteLine("\tEnter the amount of ships you want (1 to 5): ");
                amo = int.Parse(Console.ReadLine());
            }

            return amo;
        }

        public static void Show_gameboard(int[,] gb, int dim)
        {
            for (int r = 0; r < dim; r++)
            {
                Console.Write("\n");
                for (int c = 0; c < dim; c++)
                {
                    Console.Write($"[{gb[r, c]}]");
                }
            }
            Console.Write("\n");
            Console.WriteLine("References: 0 = Water. 1 = Ship. 2 = Water touched. 3 = Ship touched.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Play(int[,] gb, int ships, int dim)
        {
            int positions_covered = 0;
            do
            {
                Console.WriteLine("\tNow, enter the position where you want to test your luck: (0,5, etc): ");
                string pos = Console.ReadLine();

                int r = int.Parse(pos.Substring(0, 1));
                int c = int.Parse(pos.Substring(2, 1));

                outOfBounds:
                {
                    while (!inBounds(r, c, dim))
                    {
                        Console.WriteLine("Invalid position. Try again!");
                        Console.WriteLine("\tEnter the position where you want to test your luck: (0,5, etc): ");
                        pos = Console.ReadLine();
                        r = int.Parse(pos.Substring(0, 1));
                        c = int.Parse(pos.Substring(2, 1));
                        Console.Clear();
                    }
                }

                if (!inBounds(r, c, dim)) { goto outOfBounds; }
                else
                {
                    while (gb[r, c] != 1)
                    {
                        if (gb[r, c] == 0 || gb[r, c] == 2)
                        {
                            Console.WriteLine("Water!. Try again!\n");
                            Console.ReadKey();
                        }
                        else if (gb[r, c] == 3)
                        {
                            Console.WriteLine("There was a previous ship here. Try again!\n");
                            gb[r, c] = 2;
                        }
                        Console.WriteLine("\n\tEnter the position where you want to test your luck: (0,5, etc): ");
                        pos = Console.ReadLine();
                        r = int.Parse(pos.Substring(0, 1));
                        c = int.Parse(pos.Substring(2, 1));
                        if (!inBounds(r, c, dim)) { goto outOfBounds; }
                    }
                }

                MarkPosition(ref gb, r, c);
                // ONCE THE POSITION IS VALIDATED, WE MARK IT ON THE GAMEBOARD.
                positions_covered += 1;
            } while (positions_covered != (ships * 3));

            Console.Clear();
            Console.WriteLine("\n\tCongratulations, you won!!");
            Thread.Sleep(1000);
            Console.WriteLine("\n\tHere's how the gameboard ended upt looking like\n\n:");
            Show_gameboard(gb, dim);
        }

        public static void MarkPosition(ref int[,] gb, int r, int c)
        {
            gb[r, c] = 3;
        }
    }
}
