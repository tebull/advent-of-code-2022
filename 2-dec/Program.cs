using System;

namespace _2_dec;

class Move
{
    // Doubles up as the move score.
    private int move_id = 0;
    private string move_type = "";
    public Move(string move)
    {
        switch (move)
        {
            case "A":
                // Rock
                move_type = "Rock";
                move_id = 1;
                break;
            case "B":
                // Paper
                move_type = "Paper";
                move_id = 2;
                break;
            case "C":
                // Scissors
                move_type = "Scissors";
                move_id = 3;
                break;
            case "X":
                // Rock
                move_type = "Rock";
                move_id = 1;
                break;
            case "Y":
                // Paper
                move_type = "Paper";
                move_id = 2;
                break;
            case "Z":
                // Scissors
                move_type = "Scissors";
                move_id = 3;
                break;
            default:
                Console.WriteLine("ERROR: Unexpected move = " + move);
                break;
        }
        //Console.WriteLine("DEBUG: move type = " + move_type);
    }

    public int Score()
    {
        return move_id;
    }

    public override bool Equals(Object? obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else {
            return this == (Move)obj;
        }
    }

    public static bool operator ==(Move x, Move y)
    {
        return x.move_id == y.move_id;
    }

    public static bool operator !=(Move x, Move y)
    {
        return x.move_id != y.move_id;
    }

    public override int GetHashCode()
    {
        Console.WriteLine("EQ H");
        return move_id;
    }

    public bool Draws(Move rh_move)
    {
        if (move_id == rh_move.move_id)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Beats(Move rh_move)
    {
        if (move_id != rh_move.move_id)
        {
            switch (move_type)
            {
                case "Rock":
                    if (rh_move.move_type == "Scissors")
                    {
                        return true;
                    }
                    break;
                case "Paper":
                    if (rh_move.move_type == "Rock")
                    {
                        return true;
                    }
                    break;
                case "Scissors":
                    if (rh_move.move_type == "Paper")
                    {
                        return true;
                    }
                    break;
                default:
                    Console.WriteLine("ERROR: Unexpected move = " + move_type);
                    break;
            }
        }
        return false;
    }
}

class Program
{
    static int ResultScore(Move elf_move, Move my_move)
    {
        int score = 0;
        if (elf_move == my_move)
        //if (elf_move.Draws(my_move))
        {
            Console.WriteLine("Draw");
            score = 3;
        }
        else if (my_move.Beats(elf_move))
        {
            score = 6;
        }
        return score;
    }

    static int CalcScore(string round)
    {
        int score = 0;
        string[] moves = round.Split(' ');
        Move elf_move = new Move(moves[0]);
        Move my_move = new Move(moves[1]);
        score += my_move.Score();
        score += ResultScore(elf_move, my_move);
        return score;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("2-dec");
        string[] lines = System.IO.File.ReadAllLines(@"2dec.txt");
        //string[] lines = System.IO.File.ReadAllLines(@"test.txt");
        int total_score = 0;

        foreach (string line in lines)
        {
            total_score += CalcScore(line);
        }
        Console.WriteLine("Total score = " + total_score);
    }
}
