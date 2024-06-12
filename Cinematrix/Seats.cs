using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cinematrix
{
    public partial class Seats : Form
    {
        public Seats(string MovieName)
        {
            InitializeComponent();
            lbTitle.Text = MovieName;
        }

        private void Seats_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "Haikyu.txt");
                string[] files = File.ReadAllLines(filePath);
                int count = 0;
                foreach (string i in files)
                {
                    if (i == "7")
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("This seat is already taken!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.BackColor = Color.Red;
                }
                else
                {
                    button1.BackColor = Color.Green;
                    List<string> filess = File.ReadAllLines(filePath).ToList();
                    filess.Add("7");
                    File.WriteAllLines(filePath, filess);
                    MessageBox.Show("Reserved Successfully! Thank you.");
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("The file 'Haikyu.txt' is missing. Please ensure it exists in the correct location.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void proceedReceipt_Click(object sender, EventArgs e)
        {

        }
    }
}
