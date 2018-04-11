using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalScoreCalculator
{
    public partial class FSCMainForm : Form
    {
        public FSCMainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // takes input from the user to find the values
            float currentGrade = 0f;
            float.TryParse(textBox1.Text, out currentGrade);

            currentGrade /= 100f;

            float finalWeight = 0f;
            float.TryParse(textBox2.Text, out finalWeight);

            finalWeight /= 100f;

            float targetGrade = 0f;
            float.TryParse(textBox3.Text, out targetGrade);
            targetGrade /= 100f;

            if (finalWeight == 0)
            {
                MessageBox.Show("Enter a valid weight...");
            }
            else
            {
                /** This is the algebraic derivation:
                 * 
                 * (currentGrade)(1-finalWeight) + (finalWeight)(needed) = targetGrade
                 * (currentGrade)(1-finalWeight) - targetGrade = (finalWeight)(neededScore)
                 * neededScore = ((currentGrade)(1-finalWeight) - targetGrade) / (finalWeight)
                **/
                float needed = -((currentGrade) * (1 - finalWeight) - targetGrade) / (finalWeight);
                string text = "You need to score at least a % " + needed * 100 + " to achieve a %" + targetGrade * 100f;
                if (needed > 1f)
                    text += "\nUnlucky...";
                MessageBox.Show(text);
            }
        }
    }
}
