using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculdade___Linguagens_Formais_e_Autômatos
{
    public partial class Janela : Form
    {

        Tape tape;
        MT mt;

        public Janela()
        {

            InitializeComponent();
            DesabilitarCampos();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void DesabilitarCampos()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            button1.Enabled = false;
        }
        public void HabilitarCampos()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            button1.Enabled = true;
            buttonfita.Enabled = true;
        }
        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }
        /* FITA */
        private void button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(tape.FillOutTape(), "FITA");
            
            MessageBox.Show(tape.BinaryTape() + "\n" + tape.BinaryTape().Length, "FITA EM BINÁRIO");

        }
        /* VALIDAÇÃO */
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(tape.validateInput() == true ? "Válido" : "Inválido", "Validação");
                MessageBox.Show(tape.processing, "Processamento");
                MessageBox.Show(tape.FillOutTape(), "FITA COM OUTPUT");
            }
            catch (TuringExcpetion f)
            {
            }

            mt = null;
            DesabilitarCampos();
        }
        /* NOVA MÁQUINA */
        private void button2_Click(object sender, EventArgs e)
        {
            mt = new MT();
            textBox1.Enabled = true;
            LimparCampos();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
                return;

            mt.Alphabet = textBox1.Text;
            textBox2.Enabled = true;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
                return;
            try
            {
                mt.AlphabetTape = textBox2.Text;
                textBox3.Enabled = true;
            }
            catch (TuringExcpetion te)
            {
                MessageBox.Show("Preencha novamente as tuplas :)");
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            // se ele não haver nada, eu saio da função e aguardo um valor.
            if (textBox3.Text == "")
                return;

            try
            {
                mt.States = textBox3.Text;
                textBox4.Enabled = true;

            }
            catch (TuringExcpetion f)
            {
                // MessageBox.Show("Preencha novamente as tuplas :)");
                textBox3.Text = "";
                //  DesabilitarCampos();
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                return;


            try
            {
                mt.InitialState = int.Parse(textBox4.Text);
                textBox5.Enabled = true;
            }
            catch (TuringExcpetion te)
            {
                MessageBox.Show("Preencha novamente as tuplas :)");
                LimparCampos();
                DesabilitarCampos();
            }

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (textBox5.Text == "")
                return;

            try
            {
                mt.FinalState = textBox5.Text;
                textBox7.Enabled = true;
            }
            catch (TuringExcpetion te)
            {
                MessageBox.Show("Preencha novamente as tuplas :)");
                LimparCampos();
                DesabilitarCampos();
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
                return;

            try
            {
                tape.Input = textBox6.Text;
            }
            catch (TuringExcpetion tf)
            {
                MessageBox.Show("Preencha novamente as tuplas :)");
                LimparCampos();
                DesabilitarCampos();
            }

            HabilitarCampos();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            if (textBox7.Text == "")
                return;

            try
            {
                mt.setFuctionOfTransisiton(textBox7.Text);
                textBox6.Enabled = true;
            }
            catch (TuringExcpetion te)
            {
                MessageBox.Show("Preencha novamente as tuplas :)");
                textBox7.Text = "";
            }

            textBox8.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            HabilitarCampos();
        }
        // simbolo branco
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            tape = new Tape(mt);

            if (textBox8.Text == "")
                return;

            if (textBox8.Text.Length > 1)
                return;
            else
                tape.Delimiter = Char.Parse(textBox8.Text);

        }
    }
}

