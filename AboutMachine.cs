using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCad
{
    public partial class AboutMachine : Form
    {
        Machines.MachineData Data;
        internal AboutMachine(Machines.MachineData data)
        {
            Data = data;
            InitializeComponent();
        }

        private void AboutMachine_Load(object sender, EventArgs e)
        {
            TextBox.Text = $"{Data.name}\n\n\n{Data.description}\n\n\nAttributes:\n\n";
            foreach(var attribute in Data.attributes)
            {
                TextBox.Text += $"{attribute.Key} - {attribute.Value}\n\n";
            }
            TextBox.Text += $"\nAuthor: {Data.author}\n\n";
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
      
    }
}
