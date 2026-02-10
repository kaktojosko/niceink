using System;
using System.Drawing;
using System.Windows.Forms;

namespace niceink
{
    public partial class FormTextSize : Form
    {
        public Root Root;
        private Label lblSize;
        private Button btnUp;
        private Button btnDown;
        private Button btnOk;

        public FormTextSize(Root root)
        {
            Root = root;
            InitializeComponent();
            UpdateDisplay();
        }

        private void InitializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(100, 160);
            this.BackColor = Color.WhiteSmoke;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

            // Title label
            Label lblTitle = new Label();
            lblTitle.Text = "Size";
            lblTitle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(35, 5);
            this.Controls.Add(lblTitle);

            // Up button (+)
            btnUp = new Button();
            btnUp.Text = "+";
            btnUp.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            btnUp.Size = new Size(40, 35);
            btnUp.Location = new Point(25, 25);
            btnUp.FlatStyle = FlatStyle.Flat;
            btnUp.FlatAppearance.BorderSize = 1;
            btnUp.Click += BtnUp_Click;
            this.Controls.Add(btnUp);

            // Size display
            lblSize = new Label();
            lblSize.Text = Root.GlobalTextSize.ToString();
            lblSize.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            lblSize.Size = new Size(60, 25);
            lblSize.Location = new Point(20, 65);
            lblSize.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblSize);

            // Down button (-)
            btnDown = new Button();
            btnDown.Text = "−";
            btnDown.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            btnDown.Size = new Size(40, 35);
            btnDown.Location = new Point(25, 95);
            btnDown.FlatStyle = FlatStyle.Flat;
            btnDown.FlatAppearance.BorderSize = 1;
            btnDown.Click += BtnDown_Click;
            this.Controls.Add(btnDown);

            // OK button
            btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            btnOk.Size = new Size(50, 25);
            btnOk.Location = new Point(20, 135);
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Click += (s, e) => this.Close();
            this.Controls.Add(btnOk);
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (Root.GlobalTextSize < 72)
            {
                Root.GlobalTextSize += 2;
                UpdateDisplay();
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (Root.GlobalTextSize > 8)
            {
                Root.GlobalTextSize -= 2;
                UpdateDisplay();
            }
        }

        private void UpdateDisplay()
        {
            lblSize.Text = Root.GlobalTextSize.ToString();
        }
    }
}
