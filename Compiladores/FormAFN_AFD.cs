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

namespace Compiladores
{
    public partial class FormAFN_AFD : Form
    {
        public int[,] tablaEdos;
        public FormAFN_AFD()
        {
            InitializeComponent();
        }

        public void Mostrar()
        {
            dataGridView1.ColumnCount = 258;
            dataGridView1.RowCount = AFD.edosAFD + 1;
            dataGridView1[0, 0].Value = "Estados/Caracter";
            dataGridView1[257, 0].Value = "TOKEN";

            for (int i = 1; i < AFD.edosAFD; i++)
            {
                dataGridView1[0, i].Value = i;
            }
            for (int i = 0; i < 256; i++)
            {
                dataGridView1[i+1, 0].Value = (char)i;
            }
            for (int c = 0; c <= 256; c++)
            {
                for(int f=0; f< AFD.edosAFD; f++)
                {
                    dataGridView1[c+1, f+1].Value = AFD.tablaAFD[f, c];
                }
            }
            Console.WriteLine("Se obtuvo la tabla");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
            btnGuardar.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Especificar la ruta del archivo de texto
            string rutaArchivo = @"C:\Users\gocc_\Desktop\archivo.txt";

            // Abrir el archivo de texto para escritura
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                for (int i = 0; i < AFD.tablaAFD.GetLength(0); i++)
                {
                    for (int j = 0; j < AFD.tablaAFD.GetLength(1); j++)
                    {
                        writer.Write(AFD.tablaAFD[i, j]);

                        if (j < AFD.tablaAFD.GetLength(1) - 1)
                        {
                            writer.Write(",");
                        }
                    }

                    writer.Write("\n");
                }
            }
            Console.WriteLine("Matriz guardada en el archivo de texto.");

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Ruta del archivo de texto
            string rutaArchivo = @"C:\Users\gocc_\Desktop\archivo.txt";

            // Leer todas las líneas del archivo
            string[] lines = File.ReadAllLines(rutaArchivo);

            // Obtener el número de filas y columnas de la matriz
            int numRows = lines.Length;
            int numCols = lines[0].Split(',').Length;

            // Crear la matriz
            int[,] matrix = new int[numRows, numCols];

            // Iterar sobre cada línea y asignar los valores a la matriz
            for (int i = 0; i < numRows; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < numCols; j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }

            // Imprimir la matriz para verificar que se ha cargado correctamente
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            AFD.tablaAFD = matrix;
            AFD.edosAFD = numRows;
        }
    }
}
