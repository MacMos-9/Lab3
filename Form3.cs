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
    public partial class Form3 : Form
    {
        List list = new List();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Propiedades propiedad = new Propiedades();
            propiedad.NumCasa = Convert.ToInt32(textBox1.Text);
            propiedad.Dpi = Convert.ToInt32(textBox2.Text);
            propiedad.CuotaMant = float.Parse(textBox3.Text);

            list.Propiedades.Add(propiedad);

            Guardar();

            this.Dispose();
        }

        private void Guardar()
        {
            FileStream stream = new FileStream(@"..\..\propiedades.txt", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            foreach (var propiedad in list.Propiedades)
            {
                writer.WriteLine(propiedad.NumCasa);
                writer.WriteLine(propiedad.Dpi);
                writer.WriteLine(propiedad.CuotaMant);

            }

            writer.Close();
        }
    }
}
