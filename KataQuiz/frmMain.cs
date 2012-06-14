using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KataQuiz
{
    public partial class frmMain : Form
    {
        private Kana mCurrentKana;
        private bool mIsAnswerRomanji;
        private readonly List<Kana> mAllKana;
        private readonly Random ran = new Random();

        public frmMain()
        {
            mAllKana = Kana.GetAll();
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            loadNewQuestion();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string answer = mIsAnswerRomanji ? mCurrentKana.Romaji : mCurrentKana.Hiragana;
            if (!txtAnswer.Text.Equals(answer))
            {
                MessageBox.Show("Nope");
                return;
            }
            loadNewQuestion();
        }

        private void loadNewQuestion()
        {
            mCurrentKana = mAllKana[ran.Next(mAllKana.Count)];
            mIsAnswerRomanji = ran.NextDouble() > 0.5;

            lblPrompt.Text = mIsAnswerRomanji ? mCurrentKana.Hiragana : mCurrentKana.Romaji;
            txtAnswer.Clear();
            txtAnswer.Focus();
        }
    }
}
