using CHIP_8_Emulator.Emulator;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CHIP_8_Emulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CPU cpu;

        public MainWindow()
        {
            InitializeComponent();
            cpu = new CPU(CvsDisplay);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog().Value)
            {
                FileHandler fileHandler = new FileHandler();
                fileHandler.LoadFile(fileDialog.FileName, cpu.Memory);

                //cpu.Memory.GetInstruction();
            }
        }

        private void LoadInstructions()
        {
            //var instruction = cpu.Memory.GetInstruction();
           // txtCurrentInstruction.Text = BitConverter.ToString(ba).Replace("-", "");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //for(int i = 0; i < 1000; i++)
           // {
                cpu.ExecuteSingleCycle();
           // }
        }
    }
}
