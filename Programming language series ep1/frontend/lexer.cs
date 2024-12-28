using System;
using System.Collections.Generic;
using errors;

namespace lexer
{
    public struct TokenType
    {
        public string TT;
        public TokenType(string type)
        {
            TT = type;
        }
    }

    public struct Token
    {
        public TokenType TT;
        public string Value;
        public Token(TokenType type, string value)
        {
            TT = type;
            Value = value;
        }
    }

    public static class Lexer
    {
        public static RuntimeResult tokenize(string src)
        {
            const string DIGITS = "0123456789.";
            char[] characters = src.ToCharArray();
            int index = 0;
            List<Token> tokens = new List<Token>();
            while (index < characters.Length)
            {
                switch (characters[index])
                {
                    case ' ':
                        index++;
                        break;
                    case '+':
                        tokens.Add(new Token(new TokenType("+"), "+"));
                        index++;
                        break;
                    case '-':
                        tokens.Add(new Token(new TokenType("-"), "-"));
                        index++;
                        break;
                    case '*':
                        tokens.Add(new Token(new TokenType("*"), "*"));
                        index++;
                        break;
                    case '/':
                        tokens.Add(new Token(new TokenType("/"), "/"));
                        index++;
                        break;
                    case '(':
                        tokens.Add(new Token(new TokenType("("), "("));
                        index++;
                        break;
                    case ')':
                        tokens.Add(new Token(new TokenType(")"), ")"));
                        index++;
                        break;
                    default:
                        if (DIGITS.Contains(characters[index]))
                        {
                            string number = "";
                            int dot_count = 0;
                            while (index < characters.Length)
                            {
                                if (characters[index] == '.')
                                {
                                    dot_count++;
                                }

                                number += characters[index];
                                index++;
                                if (index >= characters.Length)
                                {
                                    break;
                                }

                                if (!DIGITS.Contains(characters[index]))
                                {
                                    break;
                                }
                            }

                            if (dot_count > 1)
                            {
                                return new RuntimeResult(null, new SyntaxError($"Expected only 0 or 1 '.' in number, got {dot_count}/1"));
                            }

                            tokens.Add(new Token(new TokenType("number"), number));
                            continue;
                        }

                        return new RuntimeResult(null, new SyntaxError($"Unexpected character '{characters[index]}'"));
                }
            }

            return new RuntimeResult(tokens, null);
        }
    }
}