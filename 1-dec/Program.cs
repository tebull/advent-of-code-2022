namespace _1_dec;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1 Dec");
        string[] lines = System.IO.File.ReadAllLines(@"input.txt");

        int num_elves = 3; 
        int[] elf_max_total = {0, 0, 0};
        int[] elf_max_number = {-1, -1, -1};
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
                for(int elf_index = 0; elf_index < num_elves; elf_index++)
                {
                    if (elf_total > elf_max_total[elf_index])
                    {
                        elf_max_number[elf_index] = elf_number;
                        elf_max_total[elf_index] = elf_total;
                        break;
                    }
                }
                elf_number += 1;
                elf_total = 0;
            }
        }
        Console.WriteLine("Elf Number = " + elf_max_number[0] + " " + elf_max_number[1] + " " + elf_max_number[2]);
        Console.WriteLine("Elf calories = " + elf_max_total[0] + " " + elf_max_total[1] + " " + elf_max_total[2]);

        int elf_max_total_sum = 0;
        foreach (int elf_total_sum in elf_max_total)
        {
            elf_max_total_sum += elf_total_sum;
        }
        Console.WriteLine("TOTAL = " + elf_max_total_sum);
        
    }
}
