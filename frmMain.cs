using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace Euler
{
    public partial class frmMain : Form
    {
        delegate void SetTextCallback(string text);

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            answerBaseClass latest = GetHighestProblem();

            txtResults.Text = "Latest Problem: " + latest.Name + Environment.NewLine + latest.ToString();
        }
        

        private answerBaseClass GetHighestProblem()
        {
            List<answerBaseClass> answers = GetAllImplementedAnswers();
            return answers.OrderBy(a => a.Name).Last();
        }

        private List<answerBaseClass> GetAllImplementedAnswers()
        {
            return ReflectionHelper.ReflectionHelper.GetAllNonabstractClassesOf<answerBaseClass>();
        }

        private void btnDoAll_Click(object sender, EventArgs e)
        {
            Task t = new Task(DoAll);
            t.Start();
        }


        private void DoAll()
        {
            List<answerBaseClass> answers = GetAllImplementedAnswers().OrderBy(a => a.Name).ToList();

            string contents = "";
            foreach (answerBaseClass answer in answers)
            {
                contents += answer.ToString() + Environment.NewLine;

                SetResults(contents);
            }

            
        }

        private void SetResults(string newContents)
        {
            if (txtResults.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetResults);
                txtResults.Invoke(d, new object[] { newContents });
            }
            else
                txtResults.Text = newContents;
        }
    }
    

}
