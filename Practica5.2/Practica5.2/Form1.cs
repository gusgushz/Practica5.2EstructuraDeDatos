using Practica5._2.Entities;

namespace Practica5._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Enlistador gus = new();
        private void button1_Click(object sender, EventArgs e)
        {
            string palabra = textBox1.Text.Trim();
            gus.EnlistarPalabra(palabra);
            gus.CrearOrdenarDiccionario(palabra);

            listBox1.Items.Clear();
            foreach (var par in gus.palabrasTodas)
            {
                listBox1.Items.Add($"{par.p}");
            }

            listBox2.Items.Clear();
            int listaCount = 1; 
            foreach (List <Palabra> Diccionario in gus.Diccionario)
            {
                listBox2.Items.Add($"Lista {listaCount}:"); 
                listaCount++;
                foreach (Palabra pala in Diccionario)
                {
                    listBox2.Items.Add($"{pala.p}");
                }
            }
            textBox1.Clear();
        }
    }
}