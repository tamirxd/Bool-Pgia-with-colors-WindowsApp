using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B17Ex05
{
    public class GuessLine
    {
	private const short k_GuessLineBaseSpacing = 70;
	private readonly GuessButton[] r_GuessButtons;
	private readonly ResultButton[] r_ResultButtons;
	private readonly ColorsForm r_ColorsForm;
	private int m_GuessesTaken;
	private int m_TopOfTheLine;
	private ArrowButton m_ArrowButton;

	public GuessLine(int i_LineNumber, ColorsForm i_FormColours)
	{
	    r_ColorsForm = i_FormColours;
	    m_GuessesTaken = 0;
	    m_TopOfTheLine = k_GuessLineBaseSpacing + ((i_LineNumber * GuessButton.k_GuessButtonHeight) + (FormBoolPgiaMainGame.k_ButtonsSpacing * 2 * i_LineNumber));
	    r_GuessButtons = new GuessButton[FormBoolPgiaMainGame.k_GuessesPerLine];
	    r_ResultButtons = new ResultButton[FormBoolPgiaMainGame.k_GuessesPerLine];
	    m_ArrowButton = new ArrowButton(m_TopOfTheLine);
	    initializeButtons(i_LineNumber, i_FormColours);
	}

	public void SetResultButtonColor(int i_ResultButtonIndex, Color i_ResultButtonColor)
	{
	    r_ResultButtons[i_ResultButtonIndex].BackColor = i_ResultButtonColor;
	}

	private void initializeButtons(int i_LineNumber, ColorsForm i_FormColours)
	{
	    for (int i = 0; i < FormBoolPgiaMainGame.k_GuessesPerLine; i++)
	    {
		r_GuessButtons[i] = new GuessButton(m_TopOfTheLine, i);
		r_GuessButtons[i].Click += new EventHandler(GuessButton_Click);
		r_ResultButtons[i] = new ResultButton(m_TopOfTheLine, i);
	    }
	}

	public GuessButton[] GuessButtons
	{
	    get { return r_GuessButtons; }
	}

	public ResultButton[] ResultButtons
	{
	    get { return r_ResultButtons; }
	}

	public ArrowButton ArrowButton
	{
	    get { return m_ArrowButton; }
	}

	public int GuessesTaken
	{
	    get { return m_GuessesTaken; }
	}

	public void EnableLine()
	{
	    foreach (Button guessButton in r_GuessButtons)
	    {
		guessButton.Enabled = true;
	    }
	}

	public void GuessButton_Click(object i_Sender, EventArgs i_Args)
	{
	    r_ColorsForm.ShowDialog();

	    if (r_ColorsForm.DialogResult != DialogResult.Cancel)
	    {
		(i_Sender as GuessButton).BackColor = r_ColorsForm.ChosenColor;
		(i_Sender as GuessButton).Clicked = true;
	    }

	    if (m_GuessesTaken < FormBoolPgiaMainGame.k_GuessesPerLine)
	    {
		m_GuessesTaken++;
	    }

	    if (m_GuessesTaken == FormBoolPgiaMainGame.k_GuessesPerLine)
	    {
		if (allGuessButtonsClicked())
		{
		    this.m_ArrowButton.Enabled = true;
		}
	    }
	}

	public void DisableLine()
	{
	    foreach (GuessButton guessButton in r_GuessButtons)
	    {
		guessButton.Enabled = false;
	    }

	    m_ArrowButton.Enabled = false;
	}

	private bool allGuessButtonsClicked()
	{
	    bool isAllClicked = true;

	    foreach (GuessButton guessButton in r_GuessButtons)
	    {
		if (!guessButton.Clicked)
		{
		    isAllClicked = false;
		}
	    }

	    return isAllClicked;
	}
    }
}
