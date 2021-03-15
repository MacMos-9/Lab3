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
    public partial class Form2 : Form
    {
        List list = new List();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Propietarios propietario = new Propietarios();
            propietario.Dpi = Convert.ToInt32(textBox1.Text);
            propietario.Nombre = textBox2.Text;
            propietario.Apellido = textBox3.Text;

            list.Propietarios.Add(propietario);

            Guardar();

            this.Dispose();
        }

        private void Guardar()
        {
            FileStream stream = new FileStream(@"..\..\propietarios.txt", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            foreach (var propietario in list.Propietarios)
            {
                writer.WriteLine(propietario.Dpi);
                writer.WriteLine(propietario.Nombre);
                writer.WriteLine(propietario.Apellido);

            }

            writer.Close();
        }

    }
}
