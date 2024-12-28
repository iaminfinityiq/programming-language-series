using System;

using errors;
using lexer;

public static class Program
{
    public static void Main(string[] args)
    {
        const string code = @"69 * (420 - 5)";

        RuntimeResult rt = Lexer.tokenize(code);
        if (rt.Error != null)
        {
            Console.WriteLine($"{rt.Error.ET.ET}: {rt.Error.Reason}");
            Console.ReadKey();
            return;
        }

        foreach (Token token in rt.Result)
        {
            Console.WriteLine($"{token.TT.TT} {token.Value}");
        }

        Console.ReadKey();
    }
}