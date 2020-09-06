using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace GCad
{
    internal sealed partial class Settings : Form
    {
        public GCodeConfig config;
        public bool Modify = false;
        private readonly static Machines.Machine[] machines = { new Machines.WireCuttingMachine() };
        public Settings(GCodeConfig startConfig)
        {
            config = startConfig;
            InitializeComponent();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }


        private void MachineTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Machine = machines[MachineTypeComboBox.SelectedIndex];
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            foreach (Machines.Machine machine in machines)
            {
                MachineTypeComboBox.Items.Add(machine.data.name);
            }
            // Load data from current GCodeConfig
            ToleranceTextBox.Text = config.Tolerance.ToString();
            DecimalsTextBox.Text = config.Formatter.Decimals.ToString();
            MachineTypeComboBox.SelectedItem = config.Machine.data.name;
            foreach (string argument in config.AdditionalArguments.ToList<string>())
            {
                AdditionalArgumentsTextBox.Text += argument + " ";
            }
        }

        private void ToleranceTextBox_TextChanged(object sender, EventArgs e)
        {
            double tolerance = config.Tolerance;
            NumberFormatInfo nfi = new NumberFormatInfo();


            nfi.NumberDecimalSeparator = ".";
            try
            {
                tolerance = double.Parse(ToleranceTextBox.Text, nfi);
            }catch(FormatException)
            {
                nfi.NumberDecimalSeparator = ",";
                try
                {
                    tolerance = double.Parse(ToleranceTextBox.Text, nfi);
                }
                catch(FormatException)
                {
                    MessageBox.Show("Invalid tolerance");
                }
            }
            config.Tolerance = tolerance;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Modify = true;
            this.Hide();
        }

        private void DecimalsTextBox_TextChanged(object sender, EventArgs e)
        {
            int decimals = config.Formatter.Decimals;
            try
            {
                decimals = int.Parse(DecimalsTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid decimals");
            }
            config.Formatter = new Formatter(decimals);
        }

        private void AdditionalArgumentsTextBox_TextChanged(object sender, EventArgs e)
        {
            config.AdditionalArguments.Clear();
            foreach (string argument in AdditionalArgumentsTextBox.Text.Split(' '))
                config.AdditionalArguments.Add(argument);
        }

        private void MachineHelpButton_Click(object sender, EventArgs e)
        {
            AboutMachine form = new AboutMachine(config.Machine.data);
            form.ShowDialog();
        }
    }
}
