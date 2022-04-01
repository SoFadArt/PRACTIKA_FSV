using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2Variant32
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float[,] matrix = new float[50, 50];
        int lenght=0;
        #region Подготовка
        void ConvertSLAY()
        {
            int i = 0;
            int x = 0;
            int y = 0;
            while (true)
            {
                if (textBox1.Text.Length <= i)
                    break;
                string str = "";
                if (textBox1.Text[i] == '-')
                {
                    str += textBox1.Text[i];
                    i++;
                }
                while (true) {
                    if (textBox1.Text[i] == '\r')
                        i++;
                    if (textBox1.Text[i] == '-' || textBox1.Text[i] == '+' || textBox1.Text[i] == '=' || textBox1.Text[i] == '\n')
                        break;
                    str += textBox1.Text[i];
                    i++;
                }
                if (float.TryParse(str, out float fl))
                {
                    matrix[y, x] = fl;
                    x++;
                }
                else
                {
                    textBox1.Text += "\nЧто-то не то";
                    break;
                }
                if (textBox1.Text[i] == '\n')
                {
                    y++;
                    x = 0;
                }
                if (y == 0)
                    lenght++;
                if (x > lenght + 1)
                {
                    textBox1.Text += "\nЧто-то не то";
                    break;
                }
                if (textBox1.Text[i] != '-')
                    i++;
            }
        }
        #endregion
        #region Крамер
        void Kramer()
        {
            textBox2.Text = " ";
            float De = Det(lenght, matrix);
            for (int i = 0; i < lenght; i++)
            {
                float De2 = podstanovka(i, matrix);
                textBox2.Text += "x"+(i+1)+" = "+(De2/De)+"    ";
            }

        }
        float Det(int G, float [,] M)
        {
            if (G == 1)
                return M[0,0];
            else
            {
                float [,] M1= new float[lenght,lenght];
                int i, x, X, Y;
                float Res = 0;
                for (i = 0; i < G; i++)
                {
                    for (Y = 1; Y < G; Y++)
                    {
                        x = 0;
                        for (X = 0; X < G; X++)
                            if (X != i)
                                M1[Y - 1,x++] = M[Y,X];
                    }
                    if (i % 2 == 0)
                        Res += M[0,i] * Det(G - 1, M1);
                    else
                        Res -= M[0,i] * Det(G - 1, M1);
                }
                return Res;
            }
        }
        float podstanovka(int k, float [,] A)
        {
            float[,] M = new float[lenght,lenght];
            int i, j;
            for (i = 0; i < lenght; i++)
                for (j = 0; j < lenght; j++)
                {
                    M[i,j] = matrix[i,j];
                }
            for (i = 0; i < lenght; i++)
            {
                M[i,k] = matrix[i,lenght];   
            }
            float Opr = Det(lenght, M);
            return Opr;
        }
        #endregion
        #region Жордан-Гаусс
        void JordanGays()
        {
            float[,] M = matrix;
            float[]x= new float[lenght];
            for (int k = 0; k <= lenght-1; k++) // прямой ход
            {
                float d = 0;
                for (int j = k+1; j <= lenght-1; j++)
                {
                    d = M[j,k] / M[k,k]; // формула (1)
                    for (int i = k; i <= lenght-1; i++)
                    {
                        M[j,i] = M[j,i] - d * M[k,i]; // формула (2)
                    }
                    M[j, lenght] = M[j, lenght] - d * M[k, lenght]; // формула (3)
                }
            }
            for (int k = lenght - 1; k >= 0; k--) // обратный ход
            {
                float d = 0;
                for (int j = k+1; j <= lenght-1; j++)
                {
                    float s = M[k, j] * x[j]; // формула (4)
                    d = d + s; // формула (4)
                }
                x[k] = (M[k,lenght] - d) / M[k, k]; // формула (4)
            }
            textBox2.Text = " ";
            for (int i = 0; i < lenght; i++)
                textBox2.Text += "x" + (i + 1) + " = " + x[i] + "    ";
        }
        #endregion
        #region Гаусс
        void Gays()
        {
            float[] x = new float[lenght];
            float tmp;
            int k;

            for (int i = 0; i < lenght; i++)
            {
                tmp = matrix[i,i];
                for (int j = lenght; j >= i; j--)
                    matrix[i,j] /= tmp;
                for (int j  = i + 1; j < lenght; j++)
                {
                    tmp = matrix[j,i];
                    for (k = lenght; k >= i; k--)
                        matrix[j,k] -= tmp * matrix[i,k];
                }
            }
            x[lenght - 1] = matrix[lenght - 1,lenght];
            for (int i = lenght - 2; i >= 0; i--)
            {
                x[i] = matrix[i,lenght];
                for (int j = i + 1; j < lenght; j++) 
                    x[i] -= matrix[i,j] * x[j];
            }
            textBox2.Text = " ";
            for (int i = 0; i < lenght; i++)
                textBox2.Text += "x" + (i + 1) + " = " + x[i] + "   ";
        }
        #endregion
        #region Простая итерация
        void EasyInteration()
        {
            //Преобразование матрицы: домножение на транспонированную
            float ets = 0.000000000001f;
            float[] x = new float[lenght];
            for(int i = 0;i<lenght;i++)
                x[i] = matrix[i, lenght] / matrix[i, i];//d1
            float[] xN = new float[lenght];
            for (int i = 0; i < lenght; i++) {
                xN[i] = matrix[i, lenght];
                for (int j = 0; j < lenght; j++)
                    if (i != j)
                        xN[i] -= matrix[i, j] * x[j];
                xN[i] = xN[i] / matrix[i, i];
            }
            int count = 0;
            bool NotEnd = true;
            while (NotEnd)
            {
                count++;
                for (int i = 0; i < lenght; i++)
                {
                    xN[i] = matrix[i, lenght];
                    for (int j = 0; j < lenght; j++)
                        if (i != j)
                            xN[i] -= matrix[i, j]*x[j];
                    xN[i] = xN[i]/ matrix[i, i];
                }
                for (int i = 0; i < lenght; i++)
                {
                    if (Math.Abs(xN[i] - x[i]) >= ets)
                        break;
                    if (i == lenght - 1)
                        NotEnd = false;
                }
                for (int i = 0; i < lenght; i++)
                    x[i] = xN[i];
            }
            textBox2.Text = " ";
            for (int i = 0; i < lenght; i++)
                textBox2.Text += "x" + (i + 1) + " = " + xN[i] + "  ";
        }
        #endregion
        #region Зейдель
        void Zeidel()
        {
            float[] x = new float[lenght];
            float sum;
            int idk=0;
            for (int counter1 = 0; counter1 < lenght; counter1++)
                x[counter1] = matrix[counter1, lenght] / matrix[counter1,counter1];
            while (idk < 10)
            {

                for (int counter1 = 0; counter1 < lenght; counter1++)
                {
                    sum = matrix[counter1, lenght] + matrix[counter1,counter1] * x[counter1];
                    for (int counter2 = 0; counter2 < lenght; counter2++)
                    {
                        sum = sum - matrix[counter1,counter2] * x[counter2];
                    }

                    sum = sum / matrix[counter1,counter1];
                    x[counter1] = (sum);
                }
                idk++;
            }
            textBox2.Text = " ";
            for (int i = 0; i < lenght; i++)
                textBox2.Text += "x" + (i + 1) + " = " + x[i] + "  ";
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            ConvertSLAY();
            Kramer();
            matrix = new float[3, 3];
            lenght = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConvertSLAY();
            JordanGays();
            matrix = new float[3, 3];
            lenght = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConvertSLAY();
            Gays();
            matrix = new float[3, 3];
            lenght = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConvertSLAY();
            EasyInteration();
            matrix = new float[3, 3];
            lenght = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConvertSLAY();
            Zeidel();
            matrix = new float[3, 3];
            lenght = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
