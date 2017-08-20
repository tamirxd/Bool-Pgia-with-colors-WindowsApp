using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using B17_Ex02;

namespace B17Ex05
{
    public class FormBoolPgiaMainGame : Form
    {
	public const short k_ButtonsSpacing = 8;
	private const string k_MainFormName = "Bulls Eye";
	public const int k_GuessesPerLine = 4;
	private readonly Button[] r_SolutionLineButtons;
	private readonly int r_MaxGuesses;
	private readonly GuessLine[] r_GuessLines;
	private readonly B17_Ex02.Logic m_GameLogic;
	private readonly ColorsForm m_ColorsForm;
	private int m_CurrentLineAvailable;
	private Logic.eGameStatus m_gameStatus;

	public FormBoolPgiaMainGame(int i_NumOfChances)
	{
	    this.FormBorderStyle = FormBorderStyle.FixedSingle;
	    this.Text = k_MainFormName;
	    this.StartPosition = FormStartPosition.CenterScreen;
	    r_MaxGuesses = i_NumOfChances;
	    m_CurrentLineAvailable = 0;
	    r_GuessLines = new GuessLine[i_NumOfChances];
	    m_ColorsForm = new ColorsForm();
	    r_SolutionLineButtons = new Button[k_GuessesPerLine];
	    m_gameStatus = Logic.eGameStatus.KeepPlay;
	    m_GameLogic = new B17_Ex02.Logic(i_NumOfChances);
	    initializeComponents(i_NumOfChances);
	}

	public void CheckSolutionOnArrowClick(object i_Sender, EventArgs i_Args) // Sender is an arrow
	{
	    // Arrow is sender
	    disablePreviousLine();
	    StringBuilder guessFromColors = createStringFromColors();
	    m_GameLogic.GameData.AddGuess(guessFromColors);
	    m_gameStatus = m_GameLogic.IsGuessCorrect(guessFromColors);
	    showResultButtons();

	    if (m_gameStatus == Logic.eGameStatus.Win || m_CurrentLineAvailable == r_MaxGuesses)
	    {
		presentSolutionOnFirstLine();
	    }
	    else if (m_gameStatus == Logic.eGameStatus.KeepPlay)
	    {
		if (m_CurrentLineAvailable <= r_MaxGuesses)
		{
		    enableNextLine();
		}
	    }
	}

	private void validateAndPresentSolutionButtons(Logic.eGameStatus i_GameStatus)
	{
	    bool isGameOver = true;

	    if (i_GameStatus == Logic.eGameStatus.Lose && m_CurrentLineAvailable < r_MaxGuesses)
	    {
		isGameOver = false;
		enableNextLine();
	    }

	    if (isGameOver)
	    {
		// MaxGuesses / Correct guess is achieved
		presentSolutionOnFirstLine();
	    }
	}

	private void presentSolutionOnFirstLine()
	{
	    for (int i = 0; i < k_GuessesPerLine; i++)
	    {
		r_SolutionLineButtons[i].BackColor = convertLetterToColor(m_GameLogic.UsedLetters[i]);
	    }
	}

	private void showResultButtons()
	{
	    StringBuilder resultString = m_GameLogic.GameData.Results[m_CurrentLineAvailable - 1];
	    Color resultButtonColor = Color.White;
	    resultString.Remove(k_GuessesPerLine, resultString.Length - k_GuessesPerLine);    // Remove unwanted spaces from ex02 logic

	    for (int i = 0; i < resultString.Length; i++)
	    {
		resultButtonColor = getColorFromAnswerChar(resultString[i]);
		r_GuessLines[m_CurrentLineAvailable - 1].SetResultButtonColor(i, resultButtonColor);
	    }
	}

	private Color getColorFromAnswerChar(char i_AnswerChar)
	{
	    Color colorOfChar = default(Color);
	    switch (i_AnswerChar)
	    {
		case 'V':
		    colorOfChar = Color.Black;
		    break;
		case 'X':
		    colorOfChar = Color.Yellow;
		    break;
	    }

	    return colorOfChar;             // Defualt is gray
	}

	private StringBuilder createStringFromColors()
	{
	    StringBuilder charsFromColors = new StringBuilder();

	    foreach (GuessButton guessButton in r_GuessLines[m_CurrentLineAvailable - 1].GuessButtons)
	    {
		charsFromColors.Append(convertColorsToLetters(guessButton.BackColor));
	    }

	    return charsFromColors;
	}

	private void initializeSolutionButtons()
	{
	    for (int i = 0; i < k_GuessesPerLine; i++)
	    {
		r_SolutionLineButtons[i] = new GuessButton(0, i);
		r_SolutionLineButtons[i].Top = k_ButtonsSpacing;
		r_SolutionLineButtons[i].Left = k_ButtonsSpacing + (i * (GuessButton.k_GuessButtonWidth + k_ButtonsSpacing));
		r_SolutionLineButtons[i].BackColor = Color.Black;
		this.Controls.Add(r_SolutionLineButtons[i]);
	    }
	}

	private void initializeComponents(int i_NumOfChances)
	{
	    this.AutoSize = true;
	    initializeSolutionButtons();

	    for (int i = 0; i < i_NumOfChances; i++)
	    {
		r_GuessLines[i] = new GuessLine(i, m_ColorsForm);
		r_GuessLines[i].ArrowButton.Click += new EventHandler(CheckSolutionOnArrowClick);
		this.addNewLineToControl(r_GuessLines[i]);
	    }
	}

	private void addNewLineToControl(GuessLine i_LineToAddToTheControl)
	{
	    this.Controls.Add(i_LineToAddToTheControl.ArrowButton);

	    for (int i = 0; i < k_GuessesPerLine; i++)
	    {
		this.Controls.Add(i_LineToAddToTheControl.GuessButtons[i]);
		this.Controls.Add(i_LineToAddToTheControl.ResultButtons[i]);
	    }
	}

	public void RunGameForm()
	{
	    enableNextLine();
	    this.ShowDialog();
	}

	private void enableNextLine()
	{
	    if (m_CurrentLineAvailable < r_MaxGuesses)
	    {
		r_GuessLines[m_CurrentLineAvailable].EnableLine();
		m_CurrentLineAvailable++;
	    }
	}

	private void disablePreviousLine()
	{
	    r_GuessLines[m_CurrentLineAvailable - 1].DisableLine();
	}

	private char convertColorsToLetters(System.Drawing.Color i_Colour)
	{
	    System.Drawing.KnownColor inputColor = i_Colour.ToKnownColor();
	    char colorChar;

	    switch (inputColor)
	    {
		case KnownColor.HotPink:
		    colorChar = 'A';
		    break;
		case KnownColor.Red:
		    colorChar = 'B';
		    break;
		case KnownColor.LawnGreen:
		    colorChar = 'C';
		    break;
		case KnownColor.LightSkyBlue:
		    colorChar = 'D';
		    break;
		case KnownColor.Blue:
		    colorChar = 'E';
		    break;
		case KnownColor.Yellow:
		    colorChar = 'F';
		    break;
		case KnownColor.DarkRed:
		    colorChar = 'G';
		    break;
		case KnownColor.White:
		    colorChar = 'H';
		    break;
		default:
		    colorChar = 'A';
		    break;
	    }

	    return colorChar;
	}

	public Color convertLetterToColor(char i_Letter)
	{
	    System.Drawing.Color letterColor;

	    switch (i_Letter)
	    {
		case 'A':
		    letterColor = Color.HotPink;
		    break;
		case 'B':
		    letterColor = Color.Red;
		    break;
		case 'C':
		    letterColor = Color.LawnGreen;
		    break;
		case 'D':
		    letterColor = Color.LightSkyBlue;
		    break;
		case 'E':
		    letterColor = Color.Blue;
		    break;
		case 'F':
		    letterColor = Color.Yellow;
		    break;
		case 'G':
		    letterColor = Color.DarkRed;
		    break;
		case 'H':
		    letterColor = Color.White;
		    break;
		default:
		    letterColor = Color.Black;
		    break;
	    }

	    return letterColor;
	}
    }
}
