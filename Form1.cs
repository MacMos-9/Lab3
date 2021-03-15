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

namespace Lab3
{
    public partial class Form1 : Form
    {
        List<Propietarios> propietarios1 = new List<Propietarios>();
        List<Propiedades> propiedades1 = new List<Propiedades>();
        List<Final> final1 = new List<Final>();
        public Form1()
        {
            InitializeComponent();
        }

        private void agregarPropietariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void agregarPropiedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nuevo();
            final();
        }

        private void nuevo()
        {
            if (File.Exists(@"..\..\propietarios.txt"))
            {
                FileStream stream = new FileStream(@"..\..\propietarios.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Propietarios propietario = new Propietarios();
                    propietario.Dpi = Convert.ToInt32(reader.ReadLine());
                    propietario.Nombre = reader.ReadLine();
                    propietario.Apellido = reader.ReadLine();

                    propietarios1.Add(propietario);
                }
                reader.Close();
            }

            if (File.Exists(@"..\..\propiedades.txt"))
            {
                FileStream stream1 = new FileStream(@"..\..\propiedades.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader1 = new StreamReader(stream1);

                while (reader1.Peek() > -1)
                {
                    Propiedades propiedad = new Propiedades();
                    propiedad.NumCasa = Convert.ToInt32(reader1.ReadLine());
                    propiedad.Dpi = Convert.ToInt32(reader1.ReadLine());
                    propiedad.CuotaMant = float.Parse(reader1.ReadLine());

                    propiedades1.Add(propiedad);
                }
                reader1.Close();
            }
        }

        private void final()
        {
            for(int i=0; i<propietarios1.Count; i++)
            {
                for(int j=0; j<propiedades1.Count; j++)
                {
                    if (propietarios1[i].Dpi == propiedades1[j].Dpi)
                    {
                        Final fin = new Final();
                        fin.Nombre = propietarios1[i].Nombre;
                        fin.Apellido = propietarios1[i].Apellido;
                        fin.NumCasa = propiedades1[j].NumCasa;
                        fin.CuotaMant = propiedades1[j].CuotaMant;

                        final1.Add(fin);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = final1;
            dataGridView1.Refresh();
        }
    }
}
