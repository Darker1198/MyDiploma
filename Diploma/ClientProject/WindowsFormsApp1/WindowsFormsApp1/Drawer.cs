using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Drawer
    {
        public static void DrawTimeLine(object sender1, PaintEventArgs e)
        {
            /*
             * 5 минут = 30п
             * 1 час по 5 минут = 12 раз по 30 п = 360 п
             * 24 часа по 5 минут = 24 по 360 п = 8640п +- отступ по 5 пикселей верх низ
             * подпись справа формат хх:хх
             * отступ справа 20
             */
            Panel sender = sender1 as Panel;
            sender.Height = 8660;
            int x = 0;
            int xw = sender.Width;
            int y1 = 5;
            int y2 = 8650;
            Pen grad = new Pen(Color.Black);
            Graphics MyFormPaint = sender.CreateGraphics();
            MyFormPaint.DrawLine(grad, x, y1, x, y2);

            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 8);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            int hours = 19;
            int mins = 0;
            for (int i = 0; i <= 288; i++)
            {

                int small = 10;
                int big = 20;
                int kurrent = small;

                if (i == 0 || i - 12 == 0 || i % 12 == 0)
                {
                    kurrent = big;
                }
                int y = i * 30 + 5;

                string drawString = String.Format("{0:d2}:{1:d2}", hours, mins);
                mins += 5;
                if (mins == 60)
                {
                    mins = 0;
                    hours++;
                    if (hours == 24)
                        hours = 0;
                }



                MyFormPaint.DrawLine(grad, x, y, x + kurrent, y);
                StringFormat drawFormat = new StringFormat();
                MyFormPaint.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

            }
            drawFont.Dispose();
            drawBrush.Dispose();
            grad.Dispose();
            MyFormPaint.Dispose();
            foreach (var a in sender.Parent.Controls)
            {
                if (a is Button == true)
                {
                    (a as Button).Width = sender.Parent.Width - 40;
                }
            }
        }
    }
}
