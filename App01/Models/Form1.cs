using App01.Algoritmos;
using System.Drawing.Drawing2D;
//using App01.Models;

namespace App01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Paso 0: Condicíon de vacío
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") || 
                textBox3.Text.Equals("") ||
                textBox4.Text.Equals(""))
            {
                MessageBox.Show("Los números tienen que ser  NO VACÍOS");
                return;
            }

            int n = Convert.ToInt32(textBox1.Text);
            int tamx = Convert.ToInt32(textBox2.Text);
            int limSu = Convert.ToInt32(textBox3.Text);
            int limIn = Convert.ToInt32(textBox4.Text);
            //int pend = Convert.ToInt32(textBox5.Text);

            // Paso 0: Condicíon de vacío
            if (n <= 0 ||
                tamx <= 0 || limSu <= 0 ||
                limIn <= 0 )
            {
                MessageBox.Show("Los números deben ser mayor que CERO");
                return;

            }
            AlgoritmoGenerador algoritmo = new AlgoritmoGenerador();
            List<List<int>>  listaValores = algoritmo.
                Montecarlo(n,tamx,limIn,limSu);
            llenarGrid(listaValores);
        }

        public void llenarGrid(List<List<int>> matriz)
        {
            int tamx = matriz[0].Count;
            int n = matriz.Count;
            double xtestada = 0;
            double vtestada = 0;
            dataGridView1.Columns.Clear(); // Borra todas las columnas existentes

            for (int i = 1; i < tamx+1; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
            }

            int lastIndex = dataGridView1.Columns.Count-1;
            dataGridView1.Columns[lastIndex].HeaderText = "x(i)";

            dataGridView1.Rows.Clear(); 
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < tamx; j++)
                {
                    if (j == tamx - 1)
                    {
                        xtestada = xtestada + matriz[i][j];
                        int val = matriz[i][j];
                        vtestada = vtestada + (val*val);
                    }
                    dataGridView1.Rows[i].Cells[j].Value = matriz[i][j].ToString();
                }
            }
            xtestada = xtestada / n;
            vtestada = ((vtestada)/(n*(n-1))) - ((xtestada * xtestada) / (n - 1));
            labelXtestada.Text = "xtestada: " + xtestada.ToString();
            labelVtestada.Text = "vtestada: " + vtestada.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}