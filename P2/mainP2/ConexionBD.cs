using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainP2
{
    internal class ConexionBD
    {
        private MySqlConnection connect;
        private string server = "localhost";
        private string database = "texturas_bd";
        private string user = "root";
        private string passwd = "";

        private string cadenaConexion;



        public ConexionBD()
        {
            cadenaConexion = "Database=" + database +
                  "; DataSource=" + server +
                  "; User Id=" + user +
                  "; Password=" + passwd;
        }

        public void CloseConection()
        {
            if (connect != null)
            {
                connect.Close();
            }
        }
        public void getConexion()
        {
            try
            {

                if (cadenaConexion != null)
                {
                    connect = new MySqlConnection(cadenaConexion);
                    connect.Open();
                    //MessageBox.Show("Ok");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Errro en la conexion");
            }

        }

        public List<string> getTexturas(DataGridView dataGridView)
        {
            List<string> resultados = new List<string>();

            try
            {
                MySqlDataReader mySqlDataReader;
                getConexion();
                if (connect != null)
                {
                    string consulta = "Select * from texturas";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                    mySqlCommand.Connection = connect;
                    mySqlDataReader = mySqlCommand.ExecuteReader();


                    while (mySqlDataReader.Read())
                    {
                        //resultados.Add(mySqlDataReader["ci"].ToString());
                        int rowIndex=dataGridView.Rows.Add(
                            mySqlDataReader["descripcion"].ToString(), mySqlDataReader["red"].ToString(), mySqlDataReader["green"].ToString(),
                            mySqlDataReader["blue"].ToString(), mySqlDataReader["color"].ToString()
                        );

                        Color color = ColorTranslator.FromHtml(mySqlDataReader["color"].ToString());

                        dataGridView.Rows[rowIndex].Cells[4].Style.BackColor = color;
                        dataGridView.Rows[rowIndex].Cells[4].Style.ForeColor = Color.White;

                    }
                    Console.WriteLine(resultados);
                }
                else
                {
                    MessageBox.Show("Error en conexion");
                }
            }
            catch (MySqlException exe)
            {
                MessageBox.Show("Error en la consulta" + exe.Message);
            }
            finally
            {
                CloseConection();
            }

            return resultados;
        }

        public List<List<string>> getTexturas()
        {
            List<List<string>> resultados = new List<List<string>>();

            try
            {
                MySqlDataReader mySqlDataReader;
                getConexion();
                if (connect != null)
                {
                    string consulta = "Select * from texturas";
                    MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                    mySqlCommand.Connection = connect;
                    mySqlDataReader = mySqlCommand.ExecuteReader();

                    List<string> sublist1; 
                    while (mySqlDataReader.Read())
                    {
                        sublist1 = new List<string>(); 
                        sublist1.Add(mySqlDataReader["descripcion"].ToString());
                        sublist1.Add(mySqlDataReader["red"].ToString());
                        sublist1.Add(mySqlDataReader["green"].ToString());
                        sublist1.Add(mySqlDataReader["blue"].ToString());
                        sublist1.Add(mySqlDataReader["color"].ToString());
                        resultados.Add(sublist1); 
                    }
                    Console.WriteLine(resultados);
                }
                else
                {
                    MessageBox.Show("Error en conexion");
                }
            }
            catch (MySqlException exe)
            {
                MessageBox.Show("Error en la consulta" + exe.Message);
            }
            finally
            {
                CloseConection();
            }

            return resultados;
        }

        public Boolean AgregarTextura(string descripcion, int red, int green , int blue , string color)
        {
            try
            {
                getConexion();
                string consulta = "INSERT INTO texturas  (descripcion, red, green ,blue, color) VALUES (@descripcion, @red, @green,@blue, @color) ";
                MySqlCommand comando = new MySqlCommand(consulta, connect);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@red", red);
                comando.Parameters.AddWithValue("@green", green);
                comando.Parameters.AddWithValue("@blue", blue);
                comando.Parameters.AddWithValue("@color", color);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al agregar persona: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConection();
            }

            return true;
        }
    
        public Boolean borrarTexturas()
        {
            try
            {
                getConexion();
                string consulta = "DELETE FROM  texturas";
                MySqlCommand comando = new MySqlCommand(consulta, connect);                
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al agregar persona: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConection();
            }

            return true;
        }
    
    
    }
}
