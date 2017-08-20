using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace B17Ex05
{
    public class ArrowButton : Button
    {
	public const int k_ArrowWidth = GuessButton.k_GuessButtonWidth;
	private const string k_ArrowButtonText = "-->>";

	public ArrowButton(int i_TopOfTheLine)
	{
	    this.Text = k_ArrowButtonText;
	    this.Enabled = false;
	    this.Width = GuessButton.k_GuessButtonWidth;
	    this.Height = GuessButton.k_GuessButtonWidth / 2;
	    this.Left = (GuessButton.k_GuessButtonWidth * 4) + (FormBoolPgiaMainGame.k_ButtonsSpacing * 5); // 4 guess buttons width and 5 eights of distance from the left
	    this.Top = i_TopOfTheLine + (GuessButton.k_GuessButtonHeight / 4);
	}
    }
}
