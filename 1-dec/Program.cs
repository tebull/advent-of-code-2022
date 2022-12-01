namespace _1_dec;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1 Dec");
        string[] lines = System.IO.File.ReadAllLines(@"input.txt");

        // Display the file contents by using a foreach loop.
        //System.Console.WriteLine("Contents of input.txt = ");
        int elf_max_total = 0;
        int elf_max_number = 1;
        int elf_total = 0;
        int elf_number = 1;
        foreach (string line in lines)
        {
            if (Int32.TryParse(line, out int line_calories))
            {
                elf_total += line_calories;
            }
            else
            {
                if (elf_total > elf_max_total)
                {
                    elf_max_number = elf_number;
                    elf_max_total = elf_total;
                }
                elf_number += 1;
                elf_total = 0;
            }
        }
        Console.WriteLine("Elf Number = " + elf_max_number);
        Console.WriteLine("Elf calories = " + elf_max_total);
    }
}
