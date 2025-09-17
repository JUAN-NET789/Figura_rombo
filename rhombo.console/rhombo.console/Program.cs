class Program
{
    public class RomboDrawer
    {
        public static string DrawerRombo(int size)
        {
            if (size < 1)
                throw new ArgumentException("The size must be an integer greater than zero.");

            var sb = new System.Text.StringBuilder();
            int half = size / 2;

            for (int i = 0; i < size; i++)
            {
                int spaces = Math.Abs(half - i);
                int inside = size - 2 * spaces - 2;

                sb.Append(' ', spaces);

                if (inside < 0)
                {
                    sb.Append('#');
                }
                else
                {
                    sb.Append('#');
                    sb.Append(' ', inside);
                    sb.Append('#');
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter the size of the rhombus: ");
        if (int.TryParse(Console.ReadLine(), out int size))
        {
            try
            {
                string rombo = RomboDrawer.DrawerRombo(size);
                Console.WriteLine("\nRombo generado:\n");
                Console.WriteLine(rombo);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}




