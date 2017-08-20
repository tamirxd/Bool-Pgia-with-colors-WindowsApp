using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02
{
    public class Data
    {
	private readonly StringBuilder[] r_Guesses;
	private readonly StringBuilder[] r_Results;
	private int m_CurrentResSize;
        private int m_CurrentGuessSize;

        public Data(int i_NumOfGuesses)
        {
            m_CurrentResSize = 0;
            m_CurrentGuessSize = 0;
            r_Guesses = new StringBuilder[i_NumOfGuesses];
            r_Results = new StringBuilder[i_NumOfGuesses];

            for (int i = 0; i < i_NumOfGuesses; i++)
            {
                r_Results[i] = new StringBuilder("    ");
                r_Guesses[i] = new StringBuilder("    ");
            }
        }

        public StringBuilder[] Guesses
        {
            get
            {
                return r_Guesses;
            }
        }

        public StringBuilder[] Results
        {
            get
            {
                return r_Results;
            }
        }

        public void AddGuess(StringBuilder i_CurrentGuess)
        {
            r_Guesses[m_CurrentGuessSize].Insert(0, i_CurrentGuess);
            m_CurrentGuessSize++;
        }

        public void AddResult(StringBuilder i_CurrentResult)
        {
            r_Results[m_CurrentResSize].Insert(0, i_CurrentResult);
            m_CurrentResSize++;
        }
    }
}
