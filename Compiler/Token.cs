namespace Compiler
{
    class Token
    {
        public int lineNumber;
        public int charNumber;
        public string lexType;
        public string sourceCode;
        public dynamic meaning;
        public Token(int lN, int cN, string lT, string sC, dynamic m)
        {
            lineNumber = lN;
            charNumber = cN;
            lexType = lT;
            sourceCode = sC;
            meaning = m;
        }
    }
}
