using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Computational_mathematics_LR_ONe
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                textBox2.Text = "0";
                label9.Text = "Внимание, полям без заданных параметров присвоено значение нуль!";
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
                label9.Text = "Внимание, полям без заданных параметров присвоено значение нуль!";
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
                label9.Text = "Внимание, полям без заданных параметров присвоено значение нуль!";
            }




            double  sumX = 0, sumY = 0, sumX2 = 0, sumX3 = 0, sumX4 = 0, sumXY = 0, sumX2Y = 0;

            double A, B, C;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                dataGridView2.Rows[j+1].Cells[1].Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                dataGridView2.Rows[j + 1].Cells[3].Value = (Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value));

                dataGridView3.Rows[j + 1].Cells[1].Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                dataGridView3.Rows[j + 1].Cells[3].Value = (Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value));
                dataGridView3.Rows[j + 1].Cells[5].Value = (Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value))* Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                dataGridView3.Rows[j + 1].Cells[6].Value = (Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value)) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) *Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);

            sumX += Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                sumX2 += (Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value));
                sumX3+= Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                sumX4+= Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value)* Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value)* Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value)* Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);

                dataGridView2.Rows[j + 1].Cells[2].Value = Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);
                dataGridView2.Rows[j + 1].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);

                dataGridView3.Rows[j + 1].Cells[2].Value = Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);
                dataGridView3.Rows[j + 1].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);
                dataGridView3.Rows[j + 1].Cells[7].Value = Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[1].Value) * Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[4].Value);

                sumY += Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);
                sumXY += Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);
                sumX2Y += Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value) * Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);
                if (checkBox1.Checked)
                    chart1.Series[2].Points.AddXY(Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value), Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value));
            }
            
            

            double[,] matrix = new double[2, 3];

            
                matrix[0, 0] = sumX2;
                matrix[0, 1] = sumX;
                matrix[0, 2] = sumXY;
                matrix[1, 0] = sumX;
                matrix[1, 1] = dataGridView1.ColumnCount;
                matrix[1, 2] = sumY;
            List<double> rootList1 = new List<double>(); 
           rootList1 = GayssMethod.calculate(matrix, 2);

            A = rootList1[0];
            B = rootList1[1];

            

            double sumQ = 0;

            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                dataGridView2.Rows[j + 1].Cells[5].Value = Convert.ToDouble(dataGridView2.Rows[j + 1].Cells[1].Value) * A + B;
                dataGridView2.Rows[j + 1].Cells[6].Value = Convert.ToDouble(dataGridView2.Rows[j + 1].Cells[2].Value) - Convert.ToDouble(dataGridView2.Rows[j + 1].Cells[5].Value);
                dataGridView2.Rows[j + 1].Cells[7].Value = Convert.ToDouble(dataGridView2.Rows[j + 1].Cells[6].Value) * Convert.ToDouble(dataGridView2.Rows[j + 1].Cells[6].Value);
                sumQ += Convert.ToDouble(dataGridView2.Rows[j + 1].Cells[7].Value);
                
            }

            dataGridView2.Rows[dataGridView2.RowCount-1].Cells[7].Value = sumQ;
            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[4].Value = sumXY;
            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[3].Value = sumX2;
            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[2].Value = sumY;
            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = sumX;

            label7.Text = ("Коэффициенты прямой:\n A = " + Convert.ToString(A) + "\n B = " + Convert.ToString(B) + "\n Погрешность Q = " + Convert.ToString(sumQ));

            double x, y, step, interval1, interval2;
            step = Convert.ToDouble(textBox2.Text);
            interval1 = Convert.ToDouble(textBox3.Text);
            interval2 = Convert.ToDouble(textBox4.Text);

            x = interval1;
            if (checkBox3.Checked)
                 while (x < interval2)
                 {
                y = A * x + B;
                chart1.Series[1].Points.AddXY(x,y);
                x += step;
                 }

          

            double[,] matrix1 = new double[3, 4];

            matrix1[0, 0] = sumX4;
            matrix1[0, 1] = sumX3;
            matrix1[0, 2] = sumX2;
            matrix1[0, 3] = sumX2Y;

            matrix1[1, 0] = sumX3;
            matrix1[1, 1] = sumX2;
            matrix1[1, 2] = sumX;
            matrix1[1, 3] = sumXY;

            matrix1[2, 0] = sumX2;
            matrix1[2, 1] = sumX;
            matrix1[2, 2] = dataGridView1.ColumnCount;
            matrix1[2, 3] = sumY;


            rootList1 = GayssMethod.calculate(matrix1, 3);

            A = rootList1[0];
            B = rootList1[1];
            C = rootList1[2];

            sumQ = 0;

            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                dataGridView3.Rows[j+1].Cells[8].Value = A * Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[3].Value) + B* Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[1].Value) + C;
                dataGridView3.Rows[j + 1].Cells[9].Value = Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[2].Value) - Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[8].Value);
                dataGridView3.Rows[j + 1].Cells[10].Value = Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[9].Value) + Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[9].Value);
                sumQ += Convert.ToDouble(dataGridView3.Rows[j + 1].Cells[10].Value);
            }

            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[1].Value = sumX;
            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[2].Value = sumY;
            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[3].Value = sumX2;
            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[4].Value = sumXY;
            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[5].Value = sumX3;
            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[6].Value = sumX4;
            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[7].Value = sumX2Y;
            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[10].Value = sumQ;

            label8.Text = ("Коэффициенты параболы:\n A = " + Convert.ToString(A) + "\n B = " + Convert.ToString(B) + "\n C = " + Convert.ToString(C) + "\n Погрешность Q = " + Convert.ToString(sumQ));

            x = interval1;
            if (checkBox2.Checked)
                while (x < interval2)
                 {
                y = (A * x*x) + (B*x)  + C;
                chart1.Series[0].Points.AddXY(x, y);
                x += step;
                 }

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
                label9.Text = "Внимание, полям без заданных параметров присвоено значение нуль!";
            }

            dataGridView2.RowCount = Convert.ToInt32(textBox1.Text) + 2;
            dataGridView2.ColumnCount = 8;

            dataGridView3.RowCount = Convert.ToInt32(textBox1.Text) + 2;
            dataGridView3.ColumnCount = 11;

            dataGridView2.Rows[0].Cells[1].Value = "X";
            dataGridView2.Rows[0].Cells[2].Value = "Y";
            dataGridView2.Rows[0].Cells[3].Value = "X^2";
            dataGridView2.Rows[0].Cells[4].Value = "X*Y";
            dataGridView2.Rows[0].Cells[5].Value = "Y лин.";
            dataGridView2.Rows[0].Cells[6].Value = "d";
            dataGridView2.Rows[0].Cells[7].Value = "d^2";

            dataGridView2.Rows[dataGridView2.RowCount-1].Cells[0].Value = "Сумма";
            dataGridView2.Rows[dataGridView2.RowCount-1].Cells[6].Value = "Невязка";


            dataGridView3.Rows[0].Cells[1].Value = "X";
            dataGridView3.Rows[0].Cells[2].Value = "Y";
            dataGridView3.Rows[0].Cells[3].Value = "X^2";
            dataGridView3.Rows[0].Cells[4].Value = "X*Y";
            dataGridView3.Rows[0].Cells[5].Value = "X^3";
            dataGridView3.Rows[0].Cells[6].Value = "X^4";
            dataGridView3.Rows[0].Cells[7].Value = "X^2*Y";
            dataGridView3.Rows[0].Cells[8].Value = "Y квадратич.";
            dataGridView3.Rows[0].Cells[9].Value = "d";
            dataGridView3.Rows[0].Cells[10].Value = "d^2";


            dataGridView3.Rows[dataGridView2.RowCount - 1].Cells[0].Value = "Сумма";
            dataGridView3.Rows[dataGridView2.RowCount - 1].Cells[9].Value = "Невязка";

            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = Convert.ToInt32(textBox1.Text);

            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    dataGridView1.Rows[i].Cells[j].Value = 0;
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            label7.Text = null;
            label8.Text = null;
            label9.Text = null;
            //label10.Text = null;

            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    dataGridView1.Rows[i].Cells[j].Value = 0;

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = null;
            label8.Text = null;
            label9.Text = null;
            //label10.Text = null;
           
        }

      

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "Кнопка <<Создать таблицу>> создаёт таблицу \n " +
               "по колличеству точек, число для которых Вы ввели.\n " +
               "Кнопка <<Ввести значения и построить график>> считывает значения введённые Вами в таблицу, \n " +
               "значения шага построения графика, верхней и нижней границ построения графика. Выполняет построение матриц со значиениями \n" +
               "всех данных, необходимых для использования МНК, решает систему уравнений методом Гаусса, выполняет построение графика \n " +
               "Кнопка <<Сбросить значения>> стирает построенный график и обнуляет значения точек. \n " +
               "Пожалуйста, вводите числа с плавающей запятой ТОЛЬКО с использованием символа << , >> во избежание ошибок!"



               );
        }
    }

    public  class GayssMethod
    {
        public static List <double> calculate(double [,]matrix, int n)
        {
            List<double> rootsList = new List<double>();
           
           // const int N = 20;
           
            double[] x = new double[n];
            int[] orderRoots = new int[n+1];
            int i, j, k;
           // Console.Clear();
          
           

            
            
            //Сначала все корни по порядку
            for (i = 0; i < n + 1; i++)
                orderRoots[i] = i;
            //Прямой ход метода Гаусса
            for (k = 0; k < n; k++)
            { //На какой позиции должен стоять главный элемент
                glavelem(k, matrix, n, orderRoots); //Установка главного элемента
                //if (Math.Abs(matrix[k, k]) < 0.0001)
                //{
                //    Console.Write("Система не имеет единственного решения");
                //    rootsList = null;
                //    return rootsList;
                //}
                for (j = n; j >= k; j--)
                    matrix[k, j] /= matrix[k, k];
                for (i = k + 1; i < n; i++)
                    for (j = n; j >= k; j--)
                        matrix[i, j] -= matrix[k, j] * matrix[i, k];
            }
            //Обратный ход
            for (i = 0; i < n; i++)
                x[i] = matrix[i, n];
            for (i = n - 2; i >= 0; i--)
                for (j = i + 1; j < n; j++)
                    x[i] -= x[j] * matrix[i, j];
            //Вывод результата

            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    if (i == orderRoots[j])
                    { //Расставляем корни по порядку
                        //Console.WriteLine(x[j]);
                        rootsList.Add(x[j]);
                        break;
                    }

            //Console.Read();
            return rootsList;
        }
        private static void glavelem(int k, double[,] mas, int n, int[] otv)
        {
            int i, j, i_max = k, j_max = k;
            double temp;
            //Ищем максимальный по модулю элемент
            for (i = k; i < n; i++)
                for (j = k; j < n; j++)
                    if (Math.Abs(mas[i_max, j_max]) < Math.Abs(mas[i, j]))
                    {
                        i_max = i;
                        j_max = j;
                    }
            //Переставляем строки
            for (j = k; j < n + 1; j++)
            {
                temp = mas[k, j];
                mas[k, j] = mas[i_max, j];
                mas[i_max, j] = temp;
            }
            //Переставляем столбцы
            for (i = 0; i < n; i++)
            {
                temp = mas[i, k];
                mas[i, k] = mas[i, j_max];
                mas[i, j_max] = temp;
            }
            //Учитываем изменение порядка корней
            i = otv[k];
            otv[k] = otv[j_max];
            otv[j_max] = i;
        }
    }

}
