using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace B17Ex05
{
    public class GuessButton : Button	
    {
	public const int k_GuessButtonWidth = 40;
	public const int k_GuessButtonHeight = 40;
	private bool m_IsClicked;

	public GuessButton(int i_Top, int i_ButtonIndex)
	{
	    m_IsClicked = false;
	    this.Width = k_GuessButtonHeight;
	    this.Height = k_GuessButtonHeight;
	    this.Top = i_Top;
	    this.Left = FormBoolPgiaMainGame.k_ButtonsSpacing + ((k_GuessButtonWidth + FormBoolPgiaMainGame.k_ButtonsSpacing) * i_ButtonIndex);
	    this.Enabled = false;
	}

	public bool Clicked
	{
	    get { return m_IsClicked; }
	    set { m_IsClicked = value; }
	}
    }
}
