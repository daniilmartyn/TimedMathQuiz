using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        Random randomizer = new Random();

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int factor;

        int dividend;
        int divisor;

        int timeleft;

        public void StartTheQuiz()
        {
////////////////////////////////////////////////////////// sum
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;
////////////////////////////////////////////////////////// difference
            minuend = randomizer.Next(1,101);
            subtrahend = randomizer.Next(1,minuend);

            minusLabelLeft.Text = minuend.ToString();
            minusLabelRight.Text = subtrahend.ToString();

            difference.Value = 0;
////////////////////////////////////////////////////////// product
            multiplicand = randomizer.Next(0, 11);
            factor = randomizer.Next(0,11);

            timesLabelLeft.Text = multiplicand.ToString();
            timesLabelRight.Text = factor.ToString();

            product.Value = 0;
////////////////////////////////////////////////////////// quotient
            divisor = randomizer.Next(2,11);
            int tempQuo = randomizer.Next(2, 11);
            dividend = tempQuo * divisor;

            dividedLabelLeft.Text = dividend.ToString();
            dividedLabelRight.Text = divisor.ToString();

            quotient.Value = 0;


            timeleft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
        }
       
        private bool CheckAnswers()
        {
            if((addend1 + addend2 == sum.Value) &&
                (minuend - subtrahend == difference.Value) &&
                (multiplicand * factor == product.Value) &&
                (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckAnswers())
            {
                timer1.Stop();
                MessageBox.Show("Congrats! You got them all right!", "Winner!");
                startButton.Enabled = true;
            
            }
            else if (timeleft > 0)
            {
                timeleft -= 1;
                timeLabel.Text = timeleft + " Seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Times up!";
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * factor;
                quotient.Value = dividend / divisor;
                MessageBox.Show("You didn't finish in time!", "Sorry!");
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
