using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            //Declaração de VARIAVEIS
            String prato, ingredientes, categoria, sugestao;
            double preco;

            //Entrada de DADOS
            prato = txt_nome.Text;
            ingredientes = txt_ingredientes.Text;
            categoria = cb_categoria.Text;
            sugestao = txt_sugestao.Text;
            preco = Double.Parse(txt_preco.Text);

            /*MessageBox.Show(
                prato + 
                "\n" + 
                ingredientes + 
                "\n" + 
                categoria + 
                "\n" + 
                sugestao + 
                "\n" + 
                preco
            );
            */

            // Caminho para a criação do arquivo
            String path = System.Environment.GetEnvironmentVariable("USERPROFILE");

            //objeto responsável por gravar no arquivo criado acima, true mantém tds os registros, colocando um abaixo sempre do outro
            StreamWriter io = new StreamWriter(path + "\\desktop\\cardapio.txt", true);

            //escreve no arquivo
            //io.WriteLine(prato + "; " + ingredientes + "; " + categoria + "; " + sugestao + "; " + preco);
            string valores = string.Join(";", prato, ingredientes, categoria, sugestao, preco);
            io.WriteLine(valores);
            io.Close();
            MessageBox.Show("Registro cadastrado com sucesso", "Gravando...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            //txt_nome.Clear();
            //txt_ingredientes.Clear();
            //txt_preco.Clear();
            //txt_sugestao.Clear();
            cb_categoria.Text = "Escolha uma opção";

            //define cursor no primeiro campo
            txt_nome.Focus();

            //Outra maneira + smart
            foreach (Control c in this.Controls) 
            {  
                if(c is TextBox)
                {
                    (c as TextBox).Clear();
                }
                if(c is ComboBox)
                {
                    (c as ComboBox).Text = "Escolha uma opção";
                }
            }
        }

    }
}
