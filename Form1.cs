using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLFile;

namespace CalculatorNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Elev")
                {
                    var elev1 = new Elev(textBox7.Text, int.Parse(textBox1.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox2.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox8.Text), int.Parse(textBox9.Text));

                    Boolean validare = true;
                    double[] note = { int.Parse(textBox1.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox2.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox8.Text), int.Parse(textBox9.Text) };
                    foreach (int i in note)
                    {
                        if (i < 0 || i > 10) validare = false;
                    }
                    if (validare)
                    {
                        label11.Text = elev1.TotalulPunctelor().ToString();
                        label12.Text = elev1.MediaObtinuta().ToString("#.##");
                        label13.Text = elev1.AfisareStatus().ToString();
                        label16.Text = elev1.NotaMin().ToString();
                        label17.Text = elev1.NotaMax().ToString();
                    }
                    else MessageBox.Show("Introduceti numere cuprinse intre 0 si 10 in fiecare din cele 6 textbox-uri!");
                }

                if (comboBox1.Text == "Licenta")
                {
                    var student1 = new StudentLicenta(textBox7.Text, int.Parse(textBox1.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox2.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text));

                    Boolean validare = true;
                    double[] note = { int.Parse(textBox1.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox2.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text) };
                    foreach (int i in note)
                    {
                        if (i < 0 || i > 10) validare = false;
                    }
                    if (validare)
                    {
                        label11.Text = student1.TotalulPunctelor().ToString();
                        label12.Text = student1.MediaObtinuta().ToString("#.##");
                        label13.Text = student1.AfisareStatus().ToString();
                        label16.Text = student1.NotaMin().ToString();
                        label17.Text = student1.NotaMax().ToString();
                    }
                    else MessageBox.Show("Introduceti numere cuprinse intre 0 si 10 in fiecare din cele 6 textbox-uri!");
                }
                if (comboBox1.Text == "Master")
                {
                    var studentMaster1 = new StudentMaster(textBox7.Text, int.Parse(textBox1.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox2.Text), int.Parse(textBox5.Text));

                    Boolean validare = true;
                    double[] note = { int.Parse(textBox1.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox2.Text), int.Parse(textBox5.Text) };
                    foreach (int i in note)
                    {
                        if (i < 0 || i > 10) validare = false;
                    }
                    if (validare)
                    {
                        label11.Text = studentMaster1.TotalulPunctelor().ToString();
                        label12.Text = studentMaster1.MediaObtinuta().ToString("#.##");
                        label13.Text = studentMaster1.AfisareStatus().ToString();
                        label16.Text = studentMaster1.NotaMin().ToString();
                        label17.Text = studentMaster1.NotaMax().ToString();
                    }
                    else MessageBox.Show("Introduceti numere cuprinse intre 0 si 10 in fiecare din cele 6 textbox-uri!");
                }

            }

            catch
            {
                MessageBox.Show("Introduceti numere, nu litere sau caractere!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            label11.Text = "?";
            label12.Text = "?";
            label13.Text = "?";
            label16.Text = "?";
            label17.Text = "?";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label13.Text.Equals("Promovat"))
            {
                string caleFisier = @"D:\MyDDrive\Anul 2\Semestrul 2\Limbaje de Programare II\Sesiunea de Comunicari Stiintifice\CalculatorNote\CalculatorNote\EleviPromovati.txt";

                var citireFisier = File.ReadAllText(caleFisier);
                string situatie = $"\nElevul {textBox7.Text} a obtinut media {label12.Text}, totalul punctelor acumulate fiind {label11.Text}, din asta rezulta ca statusul" +
                    $" studentului este: {label13.Text}.";

                File.WriteAllText(caleFisier, citireFisier + situatie);
                MessageBox.Show("Ati salvat datele cu succes!");
            }
            else if (label13.Text.Equals("Promovat Licenta"))
            {
                string caleFisier = @"D:\MyDDrive\Anul 2\Semestrul 2\Limbaje de Programare II\Sesiunea de Comunicari Stiintifice\CalculatorNote\CalculatorNote\StudentiPromovatiLicenta.txt";

                var citireFisier = File.ReadAllText(caleFisier);
                string situatie = $"\nStudentul {textBox7.Text} a obtinut media {label12.Text}, totalul punctelor acumulate fiind {label11.Text}, din asta rezulta ca statusul" +
                    $" studentului este: {label13.Text}.";

                File.WriteAllText(caleFisier, citireFisier + situatie);
                MessageBox.Show("Ati salvat datele cu succes!");
            }
            else if (label13.Text.Equals("Nepromovat Licenta"))
            {
                string caleFisier = @"D:\MyDDrive\Anul 2\Semestrul 2\Limbaje de Programare II\Sesiunea de Comunicari Stiintifice\CalculatorNote\CalculatorNote\StudentiNepromovatiLicenta.txt";

                var citireFisier = File.ReadAllText(caleFisier);
                string situatie = $"\nStudentul {textBox7.Text} a obtinut media {label12.Text}, totalul punctelor acumulate fiind {label11.Text}, din asta rezulta ca statusul" +
                    $" studentului este: {label13.Text}.";

                File.WriteAllText(caleFisier, citireFisier + situatie);
                MessageBox.Show("Ati salvat datele cu succes!");
            }
            else if (label13.Text.Equals("Promovat Master"))
            {
                string caleFisier = @"D:\MyDDrive\Anul 2\Semestrul 2\Limbaje de Programare II\Sesiunea de Comunicari Stiintifice\CalculatorNote\CalculatorNote\StudentiPromovatiMaster.txt";

                var citireFisier = File.ReadAllText(caleFisier);
                string situatie = $"\nStudentul {textBox7.Text} a obtinut media {label12.Text}, totalul punctelor acumulate fiind {label11.Text}, din asta rezulta ca statusul" +
                    $" studentului este: {label13.Text}.";

                File.WriteAllText(caleFisier, citireFisier + situatie);
                MessageBox.Show("Ati salvat datele cu succes!");
            }
            else if (label13.Text.Equals("Nepromovat Master"))
            {
                string caleFisier = @"D:\MyDDrive\Anul 2\Semestrul 2\Limbaje de Programare II\Sesiunea de Comunicari Stiintifice\CalculatorNote\CalculatorNote\StudentiNepromovatiMaster.txt";

                var citireFisier = File.ReadAllText(caleFisier);
                string situatie = $"\nStudentul {textBox7.Text} a obtinut media {label12.Text}, totalul punctelor acumulate fiind {label11.Text}, din asta rezulta ca statusul" +
                    $" studentului este: {label13.Text}.";

                File.WriteAllText(caleFisier, citireFisier + situatie);
                MessageBox.Show("Ati salvat datele cu succes!");
            }
            else
            {
                string caleFisier = @"D:\MyDDrive\Anul 2\Semestrul 2\Limbaje de Programare II\Sesiunea de Comunicari Stiintifice\CalculatorNote\CalculatorNote\Corigenti.txt";

                var citireFisier = File.ReadAllText(caleFisier);
                string situatie = $"\nElevul {textBox7.Text} a obtinut media {label12.Text}, totalul punctelor acumulate fiind {label11.Text}, din asta rezulta ca statusul" +
                    $" studentului este: {label13.Text}.";

                File.WriteAllText(caleFisier, citireFisier + situatie);
                MessageBox.Show("Ati salvat datele cu succes!");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Master")
            {
                textBox6.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                label6.Visible = false;
                label19.Visible=false;
                label20.Visible = false;
            }
            else if (comboBox1.Text == "Licenta")
            {
                textBox6.Visible = true;
                textBox8.Visible = false;
                textBox9.Visible = false;
                label6.Visible = true;
                label19.Visible = false;
                label20.Visible = false;
            }
            else
            {
                textBox6.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                label6.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
            }
        }
    }
}
