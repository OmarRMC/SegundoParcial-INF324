using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mainP2
{
    public partial class Form1 : Form
    {
        private ConexionBD conexion;
        Bitmap imagenActivo; 
        public Form1()
        {
            InitializeComponent();
            conexion = new ConexionBD();
            conexion.getConexion();
            conexion.getTexturas(dataGridViewTexturas);
            imagenActivo = new Bitmap(pictureBox1.Image);
        }
        public void Mensajes(Boolean estado, string texto)
        {
            if (estado)
            {
                labelMensajeOk.Text = texto;
                labelMensajeError.Text = "";

            }
            else
            {
                labelMensajeOk.Text = "";
                labelMensajeError.Text = texto;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos jpg | *.jpg";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
            imagenActivo = bmp; 


        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int sR, sG, sB;
            sB = 0;
            sG = 0;
            sR = 0;

            for (int i = e.X; i < e.X + 10 && i<bmp.Width; i++)

                for (int j = e.Y; j < e.Y + 10 && i < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    sR += c.R;
                    sG += c.G;
                    sB += c.B;
                }
            sR = sR / 100;
            sB = sB / 100;
            sG = sG / 100;

            textBoxRed.Text = sR.ToString();
            textBoxGreen.Text = sG.ToString();
            textBoxBlue.Text = sB.ToString();


        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Obtiene el color seleccionado
                Color selectedColor = colorDialog1.Color;
                labelColor.BackColor = selectedColor;
                // Convierte el color a un string hexadecimal
                string hexColor = ColorTranslator.ToHtml(selectedColor);
                // Asigna el valor hexadecimal al textBox
                labelColor.Text = hexColor;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (conexion.AgregarTextura(textBoxDescripcion.Text, int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text), labelColor.Text))
                {
                    dataGridViewTexturas.Rows.Clear();
                    conexion.getTexturas(dataGridViewTexturas);
                    Mensajes(true, "Se agredo  los datos ");
                    //ClearFormPersona();
                }
                else
                {
                    Mensajes(false, "No Se agredo  los datos ");
                }
            }
            catch{
                Mensajes(false, "Error en guardar  ");
            }
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            Mensajes(true, "Iniciando en proceso ...");
            List<List<string>>resultados = conexion.getTexturas(); 
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            foreach (List<string> sublist in resultados)
            {

                int red = int.Parse( sublist[1]);
                int green = int.Parse(sublist[2]);
                int blue = int.Parse(sublist[3]);
                string color = sublist[4]; 

                
                Color NuevoColor = ColorTranslator.FromHtml(color);

                Color c = new Color(); 
                int sR, sG, sB;
                sB = 0;
                sG = 0;
                sR = 0;

                for (int i = 0; i < bmp.Width; i++)

                    for (int j = 0; j < bmp.Height; j++)
                    {

                        sR = 0;
                        sG = 0;
                        sB = 0;
                        for (int ip = i; ip < i + 3 && ip<bmp.Width-1; ip++)
                            for (int jp = j; jp < j + 3 && jp < bmp.Height-1; jp++)
                            {
                                c = bmp.GetPixel(ip, jp);
                                sR += c.R;
                                sG += c.G;
                                sB += c.B;

                            }
                        sR = sR / 9;
                        sB = sB / 9;
                        sG = sG / 9; 
                        
                        if (
                            (red-20 <= sR && sR <= red+20) && 
                            (green-20 <= sG && sG <= green+20) && 
                            (blue-20 <= sB && sB <= blue+20)
                        )
                        {
                            bmp2.SetPixel(i, j, NuevoColor);
                        }
                        else
                        {
                            bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                        }
                    }
                bmp = bmp2; 


            }
            pictureBox1.Image = bmp2;
            // Liberar recursos
            //bmp2.Dispose();
            //bmp.Dispose(); 
            Mensajes(true, "Finalizo de manera adecuado");

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            if (conexion.borrarTexturas())
            {
                dataGridViewTexturas.Rows.Clear();
                Mensajes(true, "Ok ");
                //ClearFormPersona();
            }
            else
            {
                Mensajes(false, "No se pudo borrar los elementos ");
            }
        }

        private void buttonRestImg_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imagenActivo; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
