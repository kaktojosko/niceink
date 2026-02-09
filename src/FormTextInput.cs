using System;
using System.Drawing;
using System.Windows.Forms;

namespace gInk
{
	public class FormTextInput : Form
	{
		private TextBox txtInput;
		private Button btnOK;
		private Button btnCancel;
		private NumericUpDown nudFontSize;
		private Label lblFontSize;

		public string InputText { get { return txtInput.Text; } }
		public int FontSize { get { return (int)nudFontSize.Value; } }

		public FormTextInput()
		{
			this.Text = "Text";
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.TopMost = true;
			this.Width = 400;
			this.Height = 180;
			this.KeyPreview = true;

			txtInput = new TextBox();
			txtInput.Location = new Point(12, 12);
			txtInput.Width = 360;
			txtInput.Font = new Font("Arial", 14);
			txtInput.Height = 30;

			lblFontSize = new Label();
			lblFontSize.Text = "Size:";
			lblFontSize.Location = new Point(12, 55);
			lblFontSize.AutoSize = true;

			nudFontSize = new NumericUpDown();
			nudFontSize.Location = new Point(55, 52);
			nudFontSize.Width = 60;
			nudFontSize.Minimum = 8;
			nudFontSize.Maximum = 200;
			nudFontSize.Value = 28;

			btnOK = new Button();
			btnOK.Text = "OK";
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Location = new Point(216, 100);
			btnOK.Width = 75;

			btnCancel = new Button();
			btnCancel.Text = "Cancel";
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Location = new Point(297, 100);
			btnCancel.Width = 75;

			this.Controls.Add(txtInput);
			this.Controls.Add(lblFontSize);
			this.Controls.Add(nudFontSize);
			this.Controls.Add(btnOK);
			this.Controls.Add(btnCancel);
			this.AcceptButton = btnOK;
			this.CancelButton = btnCancel;
		}
	}
}
