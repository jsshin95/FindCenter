using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindCenterofCircle
{
    public partial class Form1 : Form
    {
        public PointF P1, P2, P3;
        public PointF Q1, Q2, Q3;

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P C = new P();
            float Cx,Cy,r;
            float top, left, right, bottom;
            float MaxLen, ratio;
            float Cxr, Cyr, rr;
            
            if (textBox1.Text == "")
            {
                P1.X = 0;
                textBox1.Text = "0";
            }
            else P1.X = Convert.ToSingle(textBox1.Text);
            if (textBox2.Text == "")
            {
                P1.Y = 0;
                textBox2.Text = "0";
            }
            else P1.Y = Convert.ToSingle(textBox2.Text);
            if (textBox3.Text == "")
            {
                P2.X = 0;
                textBox3.Text = "0";
            }
            else P2.X = Convert.ToSingle(textBox3.Text);
            if (textBox4.Text == "")
            {
                P2.Y = 0;
                textBox4.Text = "0";
            }
            else P2.Y = Convert.ToSingle(textBox4.Text);
            if (textBox5.Text == "")
            {
                P3.X = 0;
                textBox5.Text = "0";
            }
            else P3.X = Convert.ToSingle(textBox5.Text);
            if (textBox6.Text == "")
            {
                P3.Y = 0;
                textBox6.Text = "0";
            }
            else P3.Y = Convert.ToSingle(textBox6.Text);

            if (((P1.X == P2.X) && (P1.Y == P2.Y)) || ((P1.X == P3.X) && (P1.Y == P3.Y)) || ((P3.X == P2.X) && (P3.Y == P2.Y)))
            {
                textBox7.Text = "NULL";
                MessageBox.Show("서로 다른 세 점을 입력해주십시오.");
            }
            else
            {
                C.X = FindCenter(P1, P2, P3).X;
                C.Y = FindCenter(P1, P2, P3).Y;

                if ((C.X == null) || (C.Y == null))
                {
                    textBox7.Text = "NULL";
                    MessageBox.Show("P1, P2, P3가 일직선 상에 있습니다.");
                }
                else
                {
                    Cx = (float)C.X;
                    Cy = (float)C.Y;
                    textBox7.Text = "(" + Cx.ToString("F2") + ", " + Cy.ToString("F2") + ")";

                    r = (float)Math.Sqrt((P1.X - Cx)* (P1.X - Cx)+ (P1.Y - Cy) * (P1.Y - Cy));
                    top = Cy + r;
                    bottom = Cy - r;
                    left = Cx - r;
                    right = Cx + r;

                    if (Math.Abs(Cx) >= Math.Abs(Cy))
                    {
                        if (Math.Abs(right) >= Math.Abs(left)) MaxLen = Math.Abs(right);
                        else MaxLen = Math.Abs(left);
                    }
                    else
                    {
                        if (Math.Abs(top) >= Math.Abs(bottom)) MaxLen = Math.Abs(top);
                        else MaxLen = Math.Abs(bottom);
                    }

                    MaxLen = MaxLen * 1.1f;
                    ratio = 200f / MaxLen;
                    
                    Q1.X = P1.X * ratio;
                    Q1.Y = P1.Y * ratio;
                    Q2.X = P2.X * ratio;
                    Q2.Y = P2.Y * ratio;
                    Q3.X = P3.X * ratio;
                    Q3.Y = P3.Y * ratio;
                    Cxr = Cx * ratio;
                    Cyr = Cy * ratio;
                    rr = r * ratio;

                    Q1.Y = 200f - Q1.Y;
                    Q2.Y = 200f - Q2.Y;
                    Q3.Y = 200f - Q3.Y;
                    Cyr = 200f - Cyr;
                    Q1.X += 200f;
                    Q2.X += 200f;
                    Q3.X += 200f;
                    Cxr += 200f;

                    Graphics g = panel1.CreateGraphics();
                    g.Clear(Color.White);
                    g.DrawLine(Pens.Black, 200, 0, 200, 400);
                    g.DrawLine(Pens.Black, 0, 200, 400, 200);
                    g.DrawLine(Pens.Aqua, Q1, Q2);
                    g.DrawLine(Pens.Aqua, Q1, Q3);
                    g.DrawLine(Pens.Aqua, Q3, Q2);
                    g.DrawEllipse(Pens.DarkGray, Cxr - rr, Cyr - rr, 2f * rr, 2f * rr);
                    g.FillEllipse(Brushes.Red, Cxr-2f, Cyr-2f, 4f, 4f);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && Convert.ToChar(Keys.Back) != e.KeyChar && e.KeyChar!= '.' && e.KeyChar != '-') e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && Convert.ToChar(Keys.Back) != e.KeyChar && e.KeyChar != '.' && e.KeyChar != '-') e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && Convert.ToChar(Keys.Back) != e.KeyChar && e.KeyChar != '.' && e.KeyChar != '-') e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && Convert.ToChar(Keys.Back) != e.KeyChar && e.KeyChar != '.' && e.KeyChar != '-') e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && Convert.ToChar(Keys.Back) != e.KeyChar && e.KeyChar != '.' && e.KeyChar != '-') e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && Convert.ToChar(Keys.Back) != e.KeyChar && e.KeyChar != '.' && e.KeyChar != '-') e.Handled = true;
        }

        private P FindCenter(PointF P1, PointF P2, PointF P3)
        {
            P Result = new P();
            float a, b, c, d;

            if (P1.Y == P2.Y)
            {
                Result.X = (P1.X + P2.X) * 0.5f;
                if (P1.Y == P3.Y) Result.Y = null;
                else
                {
                    c = (P1.X - P3.X) / (P3.Y - P1.Y);
                    d = (P1.Y + P3.Y) * 0.5f - c * (P1.X + P3.X) * 0.5f;
                    Result.Y = c * Result.X + d;
                }
            }
            else if (P1.Y == P3.Y)
            {
                Result.X = (P1.X + P3.X) * 0.5f;
                a = (P1.X - P2.X) / (P2.Y - P1.Y);
                b = (P1.Y + P2.Y) * 0.5f - a * (P1.X + P2.X) * 0.5f;
                Result.Y = a * Result.X + b;
            }
            else
            {
                a = (P1.X - P2.X) / (P2.Y - P1.Y);
                b = (P1.Y + P2.Y) * 0.5f - a * (P1.X + P2.X) * 0.5f;

                c = (P1.X - P3.X) / (P3.Y - P1.Y);
                d = (P1.Y + P3.Y) * 0.5f - c * (P1.X + P3.X) * 0.5f;

                if (a == c)
                {
                    Result.X = null;
                    Result.Y = null;
                }
                else
                {
                    Result.X = (d - b) / (a - c);
                    Result.Y = (a * d - b * c) / (a - c);
                }
            }

            return Result;
        }

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }

    public class P
    {
        public float? X;
        public float? Y;
    }
}
