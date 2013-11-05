using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnusedCode
{
	public partial class Plastic : Panel
	{
		Form form;

		public Plastic(Form form)
		{
			this.form = form;
			form.ClientSizeChanged += form_ClientSizeChanged;
		}

		void form_ClientSizeChanged(object sender, EventArgs e)
		{
			this.Size = form.ClientSize;
			Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle = 0x00000020; //WS_EX_TRANSPARENT
				return cp;
			}
		}

		protected override void OnMove(EventArgs e)
		{
			RecreateHandle();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			g.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.White)), new Rectangle(0, 0, this.Width, this.Height));
			g.Dispose();
		}
	}
}
