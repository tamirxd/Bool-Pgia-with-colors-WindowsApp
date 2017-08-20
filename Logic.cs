using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    public class Logic
    {
	private const string k_BullsEyeGuess = "V";
	private const string k_NotBullsEyeGuess = "X";
	private const int k_NumOfLetters = 8;
	public const int k_NumLettersGuess = 4;
	private int m_CurrentLetterIndex = 0;
	private char[] m_UsedLetters = new char[k_NumLettersGuess];

	public char[] UsedLetters
	{
	    get { return m_UsedLetters; }
	}

	public enum eGameStatus
	{
	    Lose, KeepPlay, Win
	}

	private Data m_GameData;
	private Random makeRandom = new Random();

	private void createRadomSeries()
	{
	    for (int i = 0; i < k_NumLettersGuess; i++)
	    {
		createNewRandom();
	    }
	}

	private void createNewRandom()
	{
	    char currentRandomChar;
	    currentRandomChar = (char)(makeRandom.Next(0, k_NumOfLetters) + 'A');

	    while (m_UsedLetters.Contains(currentRandomChar))
	    {
		currentRandomChar = (char)(makeRandom.Next(0, k_NumOfLetters) + 'A');
	    }

	    m_UsedLetters[m_CurrentLetterIndex] = currentRandomChar;
	    m_CurrentLetterIndex++;
	}

	public Logic(int i_NumOfGuess)
	{
	    m_GameData = new Data(i_NumOfGuess);
	    createRadomSeries();
	}

	public eGameStatus IsGuessCorrect(StringBuilder i_CurrentGuessInput)
	{
	    int xCounter = 0;   // Correct letter but not on the same index
	    int vCounter = 0;   // Bulls Eye guess
	    eGameStatus resGameStatus = eGameStatus.KeepPlay;

	    for (int i = 0; i < k_NumLettersGuess; i++)
	    {
		if (m_UsedLetters.Contains(i_CurrentGuessInput[i]))
		{
		    if (m_UsedLetters[i] == i_CurrentGuessInput[i])
		    {
			vCounter++;
		    }
		    else
		    {
			xCounter++;
		    }
		}
	    }

	    addResultToData(vCounter, xCounter);
	    if (vCounter == k_NumLettersGuess)
	    {
		resGameStatus = eGameStatus.Win;
	    }

	    return resGameStatus;
	}

	private void addResultToData(int i_VCount, int i_XCount)
	{
	    StringBuilder resultString = new StringBuilder();
	    resultString.Insert(0, k_BullsEyeGuess, i_VCount);
	    resultString.Insert(resultString.Length, k_NotBullsEyeGuess, i_XCount);
	    m_GameData.AddResult(resultString);
	}

	public Data GameData
	{
	    get
	    {
		return m_GameData;
	    }
	}

	public bool CurrentGuessLogicValidation(string i_InputString)
	{
	    bool isValid = true;

	    for (int i = 0; i < k_NumLettersGuess; i++)
	    {
		if ((i_InputString[2 * i] < 'A') || (i_InputString[2 * i] > 'H'))
		{
		    isValid = !true;
		}
	    }

	    return isValid;
	}
    }
}
