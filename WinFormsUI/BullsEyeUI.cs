using System;
using System.Collections.Generic;
using System.Text;

namespace B17Ex05
{
    public class BullsEyeUI
    {
	public const int k_MinChances = 4;
	private readonly FormStartBoolPgia r_FormStartBoolPgia;
	private int m_NumOfChances;
	private FormBoolPgiaMainGame m_FormBoolPgiaMainGame;

	public void Run()
	{
	    r_FormStartBoolPgia.ShowDialog();
	    m_NumOfChances += r_FormStartBoolPgia.ChancesClicks;

	    if (r_FormStartBoolPgia.DialogResult != System.Windows.Forms.DialogResult.Cancel)
	    {
		m_FormBoolPgiaMainGame = new FormBoolPgiaMainGame(m_NumOfChances);
		m_FormBoolPgiaMainGame.RunGameForm();
	    }
	}

	public BullsEyeUI()
	{
	    r_FormStartBoolPgia = new FormStartBoolPgia();
	    m_NumOfChances = 4;
	}
    }
}
