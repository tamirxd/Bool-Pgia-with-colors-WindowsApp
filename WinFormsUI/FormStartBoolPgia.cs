using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace B17Ex05
{
    public class FormStartBoolPgia : Form
    {
	private const short k_StartFormBaseHeight = 120;
	private const short k_StartFormBaseWidth = 250;
	private const string k_StartFormName = "Bulls Eye";
	private const string k_ChancesMsg = "Number of chances: ";
	private readonly Button r_NumberOfChancesButton;
	private readonly Button r_StartButton;
	private int m_NumOfChancesClicked;

	public FormStartBoolPgia()
	{
	    m_NumOfChancesClicked = 0;
	    this.Text = k_StartFormName;
	    this.StartPosition = FormStartPosition.CenterScreen;
	    r_StartButton = new Button();
	    r_NumberOfChancesButton = new Button();
	    InitializeComponents();
	}

	public void InitializeComponents()
	{
	    this.Width = k_StartFormBaseWidth;
	    this.Height = k_StartFormBaseHeight;
	    this.FormBorderStyle = FormBorderStyle.FixedSingle;
	    initializeChancesButtton();
	    initializeStartButton();
	    this.Controls.Add(r_NumberOfChancesButton);
	    this.Controls.Add(r_StartButton);
	}

	private void initializeChancesButtton()
	{
	    r_NumberOfChancesButton.Text = string.Format("{0}{1}", k_ChancesMsg, BullsEyeUI.k_MinChances + m_NumOfChancesClicked);
	    r_NumberOfChancesButton.Left = this.Left + FormBoolPgiaMainGame.k_ButtonsSpacing;
	    r_NumberOfChancesButton.SetBounds(FormBoolPgiaMainGame.k_ButtonsSpacing, this.Left + FormBoolPgiaMainGame.k_ButtonsSpacing, this.Width - 40, 25);
	    r_NumberOfChancesButton.Click += new EventHandler(NumberOfChancesButton_Click);
        }

	private void initializeStartButton()
	{
	    r_StartButton.Text = "Start";
	    r_StartButton.Width = this.Width - 140;
	    r_StartButton.Left = r_NumberOfChancesButton.Right - r_StartButton.Width;
	    r_StartButton.Top = r_NumberOfChancesButton.Top * 6;
	    r_StartButton.Height = 25;
	    r_StartButton.AutoSize = true;
	    this.r_StartButton.Click += new EventHandler(StartButton_Click);
	}

	private void StartButton_Click(object i_Sender, EventArgs i_Args)
	{
	    this.DialogResult = DialogResult.OK;
	    this.Close();
	}

	private void NumberOfChancesButton_Click(object i_Sender, EventArgs i_Args)
	{
	    if (m_NumOfChancesClicked < 6)
	    {
		m_NumOfChancesClicked++;
		r_NumberOfChancesButton.Text = string.Format("{0}{1}", k_ChancesMsg, BullsEyeUI.k_MinChances + m_NumOfChancesClicked);
	    }
	}

	public int ChancesClicks
	{
	    get { return m_NumOfChancesClicked; }
	}
    }
}
