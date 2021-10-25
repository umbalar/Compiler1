using System;

namespace Compiler
{
    abstract class Node {
        public Token token;
        public Token Token
        {
            get => token;
            set
            {
                token = value;
            }
        }
        public dynamic GetValue()
        {
            return token.meaning;
        }
        public abstract string OutputTree(Token Er, int priority = 0);
    }
    class NumNode : Node
    {
        public NumNode(Token token)
        {
            Token = token;
        }
        public new dynamic GetValue()
        {
            return token.meaning;
        }
        public override string OutputTree(Token Er, int priority = 0) {
            return "asd2123";
        }
    }
    class BinOpNode : Node
    {
        private Token operation;
        private Node leftOperand;
        private Node rightOperand;
        public Token Operation
        {
            get => operation;
            set
            {
                operation = value;
            }
        }
        public Node LeftOperand
        {
            get => leftOperand;
            set
            {
                leftOperand = value;
            }
        }
        public Node RightOperand
        {
            get => rightOperand;
            set
            {
                rightOperand = value;
            }
        }
        public BinOpNode(Token operation, dynamic leftOperand, dynamic rightOperand)
        {
            Operation = operation;
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }
        public BinOpNode(Token operation)
        {
            Operation = operation;
        }
        public override string OutputTree(Token Er, int priority = 0)
        {
            string tree = "";

            if (Er != null)
            {
                return tree += Er.lineNumber + "\t" + Er.charNumber + "\t" + Er.lexType + "\t" + Er.sourceCode;
            }
            
            tree += Operation.meaning + "\n";
            for (int i = 0; i < (priority + 1); i++) tree += "\t";

            if (Convert.ToString(LeftOperand.GetType()).Contains("BinOpNode"))
            {
                tree += LeftOperand.OutputTree(Er, priority + 1) + "\n";
            }
            else
            {
                tree += LeftOperand.Token.sourceCode + "\n";
            }
            for (int i = 0; i < (priority + 1); i++) tree += "\t";

            if (Convert.ToString(RightOperand.GetType()).Contains("BinOpNode"))
            {
                tree += RightOperand.OutputTree(Er, priority + 1) + "\n";
            }
            else
            {
                tree += RightOperand.Token.sourceCode + "\n";
            }
            for (int i = 0; i < (priority + 1); i++) tree += "\t";

            return tree;
        }
    }
}