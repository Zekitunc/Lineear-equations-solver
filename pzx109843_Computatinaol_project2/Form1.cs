using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pzx109843_Computatinaol_project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void calculatebtn_Click(object sender, EventArgs e)
        {
            x1ans.Text = "";
            x2ans.Text = "";
            x3ans.Text = "";
            x4ans.Text = "";
            float a11 = 0, a12 = 0, a13 = 0, a14 = 0, c1 = 0;

            a11 = Convert.ToInt32(x11.Text);//Convert=> alınan sayı string şeklinde alınıyor tam sayıya çevirmeye yarıyor!
            a12 = Convert.ToInt32(x12.Text);
            a13 = Convert.ToInt32(x13.Text);
            a14 = Convert.ToInt32(x14.Text);
            c1 = Convert.ToInt32(xc1.Text);

            x11lbl.Text = x11.Text;
            x12lbl.Text = x12.Text;
            x13lbl.Text = x13.Text;
            x14lbl.Text = x14.Text;
            c1lbl.Text = xc1.Text;

            float a21 = 0, a22 = 0, a23 = 0, a24 = 0, c2 = 0;

            a21 = Convert.ToInt32(x21.Text);
            a22 = Convert.ToInt32(x22.Text);
            a23 = Convert.ToInt32(x23.Text);
            a24 = Convert.ToInt32(x24.Text);
            c2 = Convert.ToInt32(xc2.Text);

            x21lbl.Text = x21.Text;
            x22lbl.Text = x22.Text;
            x23lbl.Text = x23.Text;
            x24lbl.Text = x24.Text;
            c2lbl.Text = xc2.Text;
            float a31 = 0, a32 = 0, a33 = 0, a34 = 0, c3 = 0;

            a31 = Convert.ToInt32(x31.Text);
            a32 = Convert.ToInt32(x32.Text);
            a33 = Convert.ToInt32(x33.Text);
            a34 = Convert.ToInt32(x34.Text);
            c3 = Convert.ToInt32(xc3.Text);

            x31lbl.Text = x31.Text;
            x32lbl.Text = x32.Text;
            x33lbl.Text = x33.Text; ;
            x34lbl.Text = x34.Text;
            c3lbl.Text = xc3.Text;

            float a41 = 0, a42 = 0, a43 = 0, a44 = 0, c4 = 0;

            a41 = Convert.ToInt32(x41.Text);
            a42 = Convert.ToInt32(x42.Text);
            a43 = Convert.ToInt32(x43.Text);
            a44 = Convert.ToInt32(x44.Text);
            c4 = Convert.ToInt32(xc4.Text);

            x41lbl.Text = x41.Text;
            x42lbl.Text = x42.Text;
            x43lbl.Text = x43.Text;
            x44lbl.Text = x44.Text;
            c4lbl.Text = xc4.Text;

            float[,] A = { { a11, a12, a13, a14 }, { a21, a22, a23, a24 }, { a31, a32, a33, a34 }, { a41, a42, a43, a44 } };
            float[] B = { c1, c2, c3, c4 };

            int coefficantscount;
            if (x41.Text == "0" && x42.Text == "0" && x43.Text == "0" && x44.Text == "0" && xc4.Text == "0")
            {
                if (x31.Text == "0" && x32.Text == "0" && x33.Text == "0" && x34.Text == "0" && xc3.Text == "0")
                {
                    coefficantscount = 2;
                }
                else
                    coefficantscount = 3;
            }
            else
                coefficantscount = 4;

            float[,] matrix = A;
            float[] value = B;
            for (int i = 0; i < coefficantscount; i++)
            {

                float tempfirst = matrix[i, i];// köşegen matrisin seçilmesi             
                if (tempfirst == 0)
                {
                    float temp;
                    for (int z = 0; z < coefficantscount; z++)
                    {
                        temp = matrix[i, z];
                        matrix[i, z] = matrix[i + 1, z];
                        matrix[i + 1, z] = temp;
                    }
                    temp = value[i];
                    value[i] = value[i + 1];
                    value[i + 1] = temp;
                    tempfirst = matrix[i, i];
                }

                for (int k = 0; k < coefficantscount; k++)
                {
                    matrix[i, k] /= tempfirst;// mk1 
                }
                value[i] /= tempfirst; //mk1
                for (int j = i + 1; j < coefficantscount; j++)//geçici ilkten sonraki elemandan başlıyor!
                {
                    float carpim = matrix[j, i] / matrix[i, i]; //mk1

                    for (int l = 0; l < coefficantscount; l++)
                    {
                        matrix[j, l] = matrix[j, l] - (carpim * matrix[i, l]); // satır eşelon
                    }
                    value[j] = value[j] - (carpim * value[i]); //satır eşelon                    
                }
            }

            float[] results = new float[coefficantscount];
            results[coefficantscount - 1] = value[coefficantscount - 1];

            for (int i = coefficantscount - 2; i >= 0; i--)
            {
                float toplam = 0;
                for (int j = i + 1; j < coefficantscount; j++)
                {
                    toplam = toplam + matrix[i, j] * results[j];
                }
                results[i] = value[i] - toplam;
            }

            for (int i = 0; i < coefficantscount; i++)
            {
                string s = "";
                for (int j = 0; j < coefficantscount; j++)
                {
                    s = s + matrix[i, j] + " ";
                }
            }
            if(coefficantscount==4)
            {
                x1ans.Text = Convert.ToString(results[0]);
                x2ans.Text = Convert.ToString(results[1]);
                x3ans.Text = Convert.ToString(results[2]);
                x4ans.Text = Convert.ToString(results[3]);
            }
            else if(coefficantscount==3)
            {
                x1ans.Text = Convert.ToString(results[0]);
                x2ans.Text = Convert.ToString(results[1]);
                x3ans.Text = Convert.ToString(results[2]);
            }
            else if (coefficantscount == 2)
            {
                x1ans.Text = Convert.ToString(results[0]);
                x2ans.Text = Convert.ToString(results[1]);
            }
        }
    }
}
