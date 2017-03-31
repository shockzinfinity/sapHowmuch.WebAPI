using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sapHowmuch.Api.TestConsole
{
	public partial class frmTestConsole : Form
	{
		private const string _apiBaseAddress = "http://192.168.1.229:9091/";

		public frmTestConsole()
		{
			InitializeComponent();
		}
	}
}
