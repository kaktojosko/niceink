using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace niceink
{
    // Message filter to detect clicks outside the form
    public class OutsideClickFilter : IMessageFilter
    {
        private Form form;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;
        
        public event EventHandler ClickOutside;
        
        public OutsideClickFilter(Form targetForm)
        {
            form = targetForm;
        }
        
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_RBUTTONDOWN)
            {
                // Get cursor position
                Point screenPos = Cursor.Position;
                // Check if click is outside the form
                if (!form.Bounds.Contains(screenPos))
                {
                    ClickOutside?.Invoke(this, EventArgs.Empty);
                }
            }
            return false; // Don't block the message
        }
    }

    public partial class FormTextSize : Form
    {
        public Root Root;
        private Label lblSize;
        private OutsideClickFilter clickFilter;

        public FormTextSize(Root root)
        {
            Root = root;
            InitializeComponent();
            UpdateDisplay();
        }

        // http://www.csharp411.com/hide-form-from-alttab/
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void InitializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(100, 140);
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.ShowInTaskbar = false;
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
            btnPlus.TabStop = false;
            btnPlus.Click += (s, e) => { 
                if (Root.GlobalTextSize < 72) {
                    Root.GlobalTextSize += 2;
                    UpdateDisplay();
                }
            };
            // Also handle MouseDown to ensure it works
            btnPlus.MouseDown += (s, e) => {
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
            btnMinus.TabStop = false;
            btnMinus.Click += (s, e) => { 
                if (Root.GlobalTextSize > 8) {
                    Root.GlobalTextSize -= 2;
                    UpdateDisplay();
                }
            };
            // Also handle MouseDown to ensure it works
            btnMinus.MouseDown += (s, e) => {
                if (Root.GlobalTextSize > 8) {
                    Root.GlobalTextSize -= 2;
                    UpdateDisplay();
                }
            };
            this.Controls.Add(btnMinus);

            // Setup message filter for outside clicks
            this.Load += (s, e) => {
                clickFilter = new OutsideClickFilter(this);
                clickFilter.ClickOutside += (sender, args) => {
                    this.Close();
                };
                Application.AddMessageFilter(clickFilter);
                this.Activate();
            };
            
            this.FormClosing += (s, e) => {
                if (clickFilter != null)
                {
                    Application.RemoveMessageFilter(clickFilter);
                    clickFilter = null;
                }
            };
        }

        private void UpdateDisplay()
        {
            lblSize.Text = Root.GlobalTextSize.ToString();
        }
    }
}
