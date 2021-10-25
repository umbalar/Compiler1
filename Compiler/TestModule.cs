using System;
using System.IO;

namespace Compiler
{
    class TestModule
    {
        public void LexerAutoTest()
        {
            for (int i = 1; i <= Directory.GetFiles("LexerTests/").Length; i++)
            {
                string lexerExpectation;
                string fileName = "LexerTests/" + i + ".txt";
                Console.WriteLine(fileName);
                Lexer testLexer = new Lexer(fileName);
                Token testToken = testLexer.GetNextToken();
                string lexerOut = "lN=" + testToken.lineNumber + "   cN=" + testToken.charNumber + "    lT=" + testToken.lexType + "    sC=" + testToken.sourceCode + "     m=" + testToken.meaning;
                Console.WriteLine(lexerOut);
                while (testToken.lexType != "end_of_file")
                {
                    testToken = testLexer.GetNextToken();
                    string lexema = "lN=" + testToken.lineNumber + "   cN=" + testToken.charNumber + "    lT=" + testToken.lexType + "    sC=" + testToken.sourceCode + "     m=" + testToken.meaning;
                    lexerOut += lexema;
                    Console.WriteLine(lexema);
                }
                //using (StreamWriter sw = new StreamWriter("LexerTestsExpectations/" + i + ".txt"))
                //{
                //    sw.Write(lexerOut);
                //}

                using (StreamReader sr = new StreamReader("LexerTestsExpectations/" + i + ".txt"))
                {
                    lexerExpectation = sr.ReadToEnd();
                }
                if (lexerOut.Equals(lexerExpectation))
                {
                    Console.WriteLine("correct result");
                }
                else
                {
                    Console.WriteLine("wrong result");
                }

            }
        }
        public void LexerManualTest()
        {
            Console.WriteLine("Print your code");
            string fileName1 = "manualLexerTest.txt";
            using (StreamWriter sw = new StreamWriter(fileName1))
            {
                sw.Write(Console.ReadLine());
            }
            Lexer testLexer1 = new Lexer(fileName1);
            Token testToken1 = testLexer1.GetNextToken();
            string lexerOut1 = "lN=" + testToken1.lineNumber + "   cN=" + testToken1.charNumber + "    lT=" + testToken1.lexType + "    sC=" + testToken1.sourceCode + "     m=" + testToken1.meaning;
            Console.WriteLine(lexerOut1);
            while (testToken1.lexType != "end_of_file")
            {
                testToken1 = testLexer1.GetNextToken();
                string lexema = "lN=" + testToken1.lineNumber + "   cN=" + testToken1.charNumber + "    lT=" + testToken1.lexType + "    sC=" + testToken1.sourceCode + "     m=" + testToken1.meaning;
                lexerOut1 += lexema;
                Console.WriteLine(lexema);
            }
        }
        public void ParserAutoTest()
        {
            for (int i = 1; i <= Directory.GetFiles("ParserTests/").Length; i++)
            {

                string ParserExpectation;
                string fileName = "ParserTests/" + i + ".txt";
                Console.WriteLine(fileName);
                Parser testParser = new Parser(new Lexer(fileName));
                string parserOut = testParser.GetTree();
                Console.WriteLine(parserOut);
                //using (StreamWriter sw = new StreamWriter("ParserTestsExpectations/" + i + ".txt"))
                //{
                //    sw.Write(parserOut);
                //}

                using (StreamReader sr = new StreamReader("ParserTestsExpectations/" + i + ".txt"))
                {
                    ParserExpectation = sr.ReadToEnd();
                }
                if (parserOut.Equals(ParserExpectation))
                {
                    Console.WriteLine("correct result");
                }
                else
                {
                    Console.WriteLine("wrong result");
                }

            }
        }
        public void ParserManualTest()
        {
            Console.WriteLine("Print your code");
            string fileName1 = "manualParserTest.txt";
            using (StreamWriter sw = new StreamWriter(fileName1))
            {
                sw.Write(Console.ReadLine());
            }
            Console.WriteLine(new Parser(new Lexer(fileName1)).GetTree());
        }
    }
}
