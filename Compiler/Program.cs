using System;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1)Lexer\n2)Parser");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Auto Test?(1-yes, 2-no)");
                    switch ((Console.ReadLine()))
                    {
                        case "1":
                            TestModule LexerAutoTM = new TestModule();
                            LexerAutoTM.LexerAutoTest();
                            break;
                        case "2":
                            TestModule LexerManualTM = new TestModule();
                            LexerManualTM.LexerManualTest();
                            break;
                        default:
                            Console.WriteLine("Incorrect input");
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Auto Test?(1-yes, 2-no)");
                    switch ((Console.ReadLine()))
                    {
                        case "1":
                            TestModule ParserAutoTM = new TestModule();
                            ParserAutoTM.ParserAutoTest();
                            break;
                        case "2":
                            TestModule ParserManualTM = new TestModule();
                            ParserManualTM.ParserManualTest();
                            break;
                        default:
                            Console.WriteLine("Incorrect input");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }
        }
    }
}
