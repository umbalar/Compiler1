using System;

namespace Compiler
{
    class Parser
    {
        private Lexer lexer;
        private Token currentToken;
        private Token Er;

        private enum Type_lex
        {
            identifier, integer_literal_int, real_literal_double
        };

        private readonly string tree;
        private Lexer Lexer
        {
            get => lexer;
            set
            {
                lexer = value;
            }
        }

        public Parser(Lexer lexer)
        {
            Lexer = lexer;
            currentToken = Lexer.GetNextToken();
            tree = ParseExpression().OutputTree(Er);
        }

        public string GetTree()
        {
            return tree;
        }

        private bool IsOperation(string str)
        {
            if ((str == "+") || (str == "-") || (str == "*") || (str == "/"))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        private void OutputER(Token token)
        {
            Er = new Token(token.lineNumber, token.charNumber, "Syntax error", "Expected Identificator or Number", "");
        }
        private BinOpNode ParseExpression()
        {
            dynamic left = ParseTerm();
            Token operation = currentToken;

            while ((Convert.ToString(operation.meaning) == "+") || (Convert.ToString(operation.meaning) == "-"))
            {
                currentToken = Lexer.GetNextToken();
                dynamic right = ParseTerm();

                left = new BinOpNode(operation, left, right);

                operation = currentToken;
            }
            if (Convert.ToString(left.GetType()).Contains("BinOpNode"))
            {
                return left;
            } 
            else
            {
                OutputER(operation);
                return new BinOpNode(operation);
            }
        }

        private dynamic ParseTerm()
        {
            dynamic left = ParseFactor();
            Token operation = currentToken;

            while ((Convert.ToString(operation.meaning) == "*") || (Convert.ToString(operation.meaning) == "/"))
            {
                currentToken = Lexer.GetNextToken();

                dynamic right = ParseFactor();

                left = new BinOpNode(operation, left, right);
                operation = currentToken;
            }

            return left;
        }

        private dynamic ParseFactor()
        {
            Token token = currentToken;
            currentToken = Lexer.GetNextToken();
            if (Enum.TryParse(typeof(Type_lex), token.lexType, out object _))
            {
                return new NumNode(token);
            } 
            else if (Convert.ToString(token.meaning) == "(")
            {
                dynamic left = ParseExpression();
                token = currentToken;

                currentToken = Lexer.GetNextToken();

                if (Convert.ToString(token.meaning) != ")")
                {
                    Er = new Token(token.lineNumber, token.charNumber + token.sourceCode.Length, "Syntax Error", "Expected \")\"", "");
                }
                return left;
            }
            else
            {
                OutputER(token);
                return 0;
            }
        }

    }
}
