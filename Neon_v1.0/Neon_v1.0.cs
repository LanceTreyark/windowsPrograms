using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeonClock
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new Form();
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.Black;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(200, 120);
            form.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, 20, 20));
            
            var button = new Button();
            button.Text = "Display Time";
            button.BackColor = Color.Black;
            button.ForeColor = Color.LimeGreen;
            button.FlatAppearance.BorderColor = Color.LimeGreen;
            button.FlatAppearance.BorderSize = 2;
            button.Size = new Size(100, 30);
            button.Location = new Point(form.Width / 2 - button.Width / 2, form.Height / 2 - button.Height / 2);
            button.Click += (sender, e) => {
                MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Current Date and Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            form.Controls.Add(button);
            
            Application.Run(form);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);
    }
}
