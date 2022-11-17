using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraNova
{
    public partial class Form1 : Form
    {
        //Variavel global boolena:
        bool vr;                

        public Form1()
        {
            InitializeComponent();
        }

        // Fecha o programa:
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Verifica o número clicado e o exibe na "txbTela":
        private void numeroPressionado(object sender, EventArgs e)
        {           
            vr = true;
            Button numero = (Button)sender;

            txbTela.Text += numero.Text;
        }       
        
        // Verifica qual operador está sendo clicado e o exibe na "txbTela":
        private void operacao(object sender, EventArgs e)
        {        
            Button operador = (Button)sender;             
                                        
                // Se a "txbTela" estiver vazia e "vr" for igual a "true" o operador clicado não é exibido:
                if (txbTela.Text != "" && vr)
                {
                    txbTela.Text += operador.Text;
                    vr = false;
                                       
                }

                // Substitui o operador escolhido caso outro seja clicado:
                else if (!vr && txbTela.Text != "")
                {
                    var t = txbTela.Text.ToArray();
                    t[t.Length - 1] = operador.Text.ToArray()[0];

                    txbTela.Text = new string(t);
                    
                    
                }                         
        }        

        // Realiza a operação quando clicado:
        private void btnIgual_Click(object sender, EventArgs e)
        {   
            // Verifica se haverá erros quando executado:
            try
            {
                DataTable dt = new DataTable();
                var resultado = dt.Compute(txbTela.Text, "");
                txbTela.Text = resultado.ToString().Replace(",",".");

                
            }
            catch
            {
                txbTela.Text = "ERRO";
            }
        }

        // Limpa a "txbTela":
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Text = null;
            this.vr = false;            
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {

        }
    }
}
