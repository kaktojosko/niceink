using System;
using System.Drawing;
using System.Windows.Forms;

namespace niceink
{
    public partial class FormTextSize : Form
    {
        public Root Root;
        private Label lblSize;

        public FormTextSize(Root root)
        {
            Root = root;
            InitializeComponent();
            UpdateDisplay();
        }

        private void InitializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(100, 140);
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.TopMost = true;

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Text Size";
            lblTitle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 5);
            this.Controls.Add(lblTitle);

            // Plus button
            Button btnPlus = new Button();
            btnPlus.Text = "▲";
            btnPlus.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            btnPlus.Size = new Size(50, 30);
            btnPlus.Location = new Point(25, 28);
            btnPlus.FlatStyle = FlatStyle.Flat;
            btnPlus.BackColor = Color.White;
            btnPlus.Click += (s, e) => { 
                if (Root.GlobalTextSize < 72) {
                    Root.GlobalTextSize += 2;
                    UpdateDisplay();
                }
            };
            this.Controls.Add(btnPlus);

            // Size display
            lblSize = new Label();
            lblSize.Text = Root.GlobalTextSize.ToString();
            lblSize.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            lblSize.Size = new Size(80, 30);
            lblSize.Location = new Point(10, 62);
            lblSize.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblSize);

            // Minus button
            Button btnMinus = new Button();
            btnMinus.Text = "▼";
            btnMinus.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            btnMinus.Size = new Size(50, 30);
            btnMinus.Location = new Point(25, 95);
            btnMinus.FlatStyle = FlatStyle.Flat;
            btnMinus.BackColor = Color.White;
            btnMinus.Click += (s, e) => { 
                if (Root.GlobalTextSize > 8) {
                    Root.GlobalTextSize -= 2;
                    UpdateDisplay();
                }
            };
            this.Controls.Add(btnMinus);

            // Close when clicking outside
            this.Deactivate += (s, e) => { this.Close(); };
        }

        private void UpdateDisplay()
        {
            lblSize.Text = Root.GlobalTextSize.ToString();
        }
    }
}
