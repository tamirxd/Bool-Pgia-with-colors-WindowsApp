using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace B17Ex05
{
    public class ResultButton : Button
    {
	public ResultButton(int i_Top, int i_ButtonIndex)
	{
	    this.Enabled = false;
	    this.Width = GuessButton.k_GuessButtonWidth / 3;
	    this.Height = GuessButton.k_GuessButtonHeight / 3;
	    setResultsButtonsLocation(i_Top, i_ButtonIndex);
	}

	private void setResultsButtonsLocation(int i_Top, int i_ButtonIndex)
	{
	    this.Left = FormBoolPgiaMainGame.k_ButtonsSpacing + ((GuessButton.k_GuessButtonWidth + FormBoolPgiaMainGame.k_ButtonsSpacing) * 4) + ArrowButton.k_ArrowWidth + FormBoolPgiaMainGame.k_ButtonsSpacing;
	    this.Top = i_Top + 4;

	    switch (i_ButtonIndex)
	    {
		case 1:
		    this.Left += this.Width + FormBoolPgiaMainGame.k_ButtonsSpacing;
		    break;
		case 2:
		    this.Top += FormBoolPgiaMainGame.k_ButtonsSpacing + this.Height;
		    this.Left += this.Width + FormBoolPgiaMainGame.k_ButtonsSpacing;
		    break;
		case 3:
		    this.Top += FormBoolPgiaMainGame.k_ButtonsSpacing + this.Height;
		    break;
	    }
	}
    }
}
