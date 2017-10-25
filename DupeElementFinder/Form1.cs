using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DupeElementFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                textBox1.Enabled = false;
            else
                textBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 5;
            string[] delimiter = new string[] { };
            if (radioButton1.Checked) {
                delimiter = new[] { "\r\n", "\n", "\r" };
            } else {
                delimiter = new[] { textBox1.Text };
            }
            string[] entries = richTextBox1.Text.Split(delimiter , StringSplitOptions.None);
            List<string> uniquEntries = new List<string>();
            List<string> dupEntries = new List<string>();
            float percentperstep = 80 / entries.Length;
            float processedpercent = 0;
            foreach (String entry in entries) {
                if (uniquEntries.Contains(entry)) {
                    dupEntries.Add(entry);
                } else {
                    uniquEntries.Add(entry);
                }
                processedpercent += percentperstep;
                progressBar1.Value += (int)Math.Floor(processedpercent);
                processedpercent -= (float)Math.Floor(processedpercent);
            }
            richTextBox2.Text = String.Join(delimiter.First(), uniquEntries);
            progressBar1.Value += 10;
            richTextBox3.Text = String.Join(delimiter.First(), dupEntries);
            progressBar1.Value += 5;
            if (checkBox1.Checked) {
                MessageBox.Show(uniquEntries.Count + " unique entries found");
                MessageBox.Show(dupEntries.Count + " duplicate entries found");
            }
            progressBar1.Value = 0;
        }
    }
}
