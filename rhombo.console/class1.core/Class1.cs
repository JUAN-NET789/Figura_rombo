namespace class1.core;

public class RomboDrawer
{
    public static string DrawerRombo(int size)
    {
        if (size < 1 || size % 2 == 0)
            throw new ArgumentException("The size must be an odd number greater than 0.");

        var rombo = new System.Text.StringBuilder();
        int half = size / 2;

        for (int i = 0; i < size; i++)
        {
            int spaces = Math.Abs(half - i);
            int characters = size - 2 * spaces;

            rombo.Append(' ', spaces);

            for (int j = 0; j < characters; j++)
            {
                if (j == 0 || j == characters - 1)
                    rombo.Append('#');
                else
                    rombo.Append(' ');
            }
            rombo.AppendLine();
        }
        return rombo.ToString();
    }
}

