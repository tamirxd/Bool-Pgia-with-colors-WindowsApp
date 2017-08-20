using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace B17Ex05
{
    public class ColorsForm : Form
    {
	private const short k_ColorOptions = 8;
	private const short k_ColorButtonsPerLine = 4;
	private const short k_BaseColorFormHeight = 38;
	private readonly Button[] r_ColorButtonsArr;
	private string k_ColorsFormName = "Pick a Color";
	private System.Drawing.Color m_ChosenColour;

	public ColorsForm()
	{
	    this.ShowInTaskbar = false;
	    this.FormBorderStyle = FormBorderStyle.FixedSingle;
	    this.Text = k_ColorsFormName;
	    this.StartPosition = FormStartPosition.CenterScreen;
	    r_ColorButtonsArr = new Button[k_ColorOptions];
	    setColorButtons();
	}

	private void setColorButtons()
	{
	    for (int i = 0; i < k_ColorOptions; i++)
	    {
		r_ColorButtonsArr[i] = new Button();
		r_ColorButtonsArr[i].Width = GuessButton.k_GuessButtonWidth;
		r_ColorButtonsArr[i].Height = GuessButton.k_GuessButtonHeight;
		r_ColorButtonsArr[i].Click += new EventHandler(returnColorOnClick);
		this.Controls.Add(r_ColorButtonsArr[i]);
	    }

	    this.Height = k_BaseColorFormHeight + (3 * FormBoolPgiaMainGame.k_ButtonsSpacing) + (2 * GuessButton.k_GuessButtonHeight);
	    initializeColorButtons();
	}

	private void initializeColorButtons()
	{
	    r_ColorButtonsArr[0].Top += FormBoolPgiaMainGame.k_ButtonsSpacing;
	    r_ColorButtonsArr[0].Left += FormBoolPgiaMainGame.k_ButtonsSpacing;
	    r_ColorButtonsArr[4].Top += r_ColorButtonsArr[0].Bottom + FormBoolPgiaMainGame.k_ButtonsSpacing;
	    r_ColorButtonsArr[4].Left += r_ColorButtonsArr[0].Left;

	    for (int i = 1; i < k_ColorButtonsPerLine; i++)
	    {
		r_ColorButtonsArr[i].Top = r_ColorButtonsArr[i - 1].Top;
		r_ColorButtonsArr[i].Left = r_ColorButtonsArr[i - 1].Left + r_ColorButtonsArr[i - 1].Width + FormBoolPgiaMainGame.k_ButtonsSpacing;
		r_ColorButtonsArr[i + k_ColorButtonsPerLine].Top = r_ColorButtonsArr[i + 3].Top;
		r_ColorButtonsArr[i + k_ColorButtonsPerLine].Left = r_ColorButtonsArr[i + 3].Left + r_ColorButtonsArr[i - 1].Width + FormBoolPgiaMainGame.k_ButtonsSpacing;
	    }

	    setColorsToButtons();
	}

	private void setColorsToButtons()
	{
	    r_ColorButtonsArr[0].BackColor = System.Drawing.Color.HotPink;
	    r_ColorButtonsArr[1].BackColor = System.Drawing.Color.Red;
	    r_ColorButtonsArr[2].BackColor = System.Drawing.Color.LawnGreen;
	    r_ColorButtonsArr[3].BackColor = System.Drawing.Color.LightSkyBlue;
	    r_ColorButtonsArr[4].BackColor = System.Drawing.Color.Blue;
	    r_ColorButtonsArr[5].BackColor = System.Drawing.Color.Yellow;
	    r_ColorButtonsArr[6].BackColor = System.Drawing.Color.DarkRed;
	    r_ColorButtonsArr[7].BackColor = System.Drawing.Color.White;
	}

	public System.Drawing.Color ChosenColor
	{
	    get { return m_ChosenColour; }
	}

	private void returnColorOnClick(object sender, EventArgs e)
	{
	    m_ChosenColour = (sender as Button).BackColor;
	    this.DialogResult = DialogResult.OK;
	    this.Close();
	}
    }
}
