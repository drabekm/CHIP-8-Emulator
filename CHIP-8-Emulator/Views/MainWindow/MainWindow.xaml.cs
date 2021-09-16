using CHIP_8_Emulator.Emulator;
using CHIP_8_Emulator.Helpers;
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
using System.Windows.Threading;

namespace CHIP_8_Emulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CPU cpu;
        InputHelper inputHelper;
        DispatcherTimer CPUTimerClock;
        CurrentSettingsDTO currentSettings;

        public MainWindow()
        {
            InitializeComponent();
            cpu = new CPU(CvsDisplay);
            inputHelper = new InputHelper(cpu);
            currentSettings = new CurrentSettingsDTO("Nothing is loaded", false);
            CPUTimerClock = SetUpCPUClockTimer();
        }

        #region Events

        private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog().Value)
            {
                cpu.ResetEverything();
                SetProgramName(fileDialog.SafeFileName);
                FileHandler fileHandler = new FileHandler();
                fileHandler.LoadFile(fileDialog.FileName, cpu.Memory);

                btnStart.IsEnabled = true;
                btnStep.IsEnabled = true;
            }
        }

        private void BtnStepClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                cpu.ExecuteSingleCycle();
            }
        }

        private void BtnStartClick(object sender, RoutedEventArgs e)
        {
            
            var isCPURunning = CPUTimerClock.IsEnabled;
            if (isCPURunning)
            {
                CPUTimerClock.Stop();
                btnStart.Content = "Start program";
                btnLoad.IsEnabled = true;
                btnStep.IsEnabled = true;
            }
            else
            {
                CPUTimerClock.Start();
                btnStart.Content = "Stop program";
                btnLoad.IsEnabled = false;
                btnStep.IsEnabled = false;
            }
            
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            SetUpKeyPressEvents();
        }

        private void CPUClockTimerTick(object sender, EventArgs e)
        {
            cpu.ExecuteSingleCycle();
        }

        #endregion

        private void SetProgramName(string filename)
        {
            currentSettings.ProgramName = filename;
            txtCurrentProgram.Text = filename;
        }

        private void SetUpKeyPressEvents()
        {
            var window = Window.GetWindow(this);
            window.KeyDown += inputHelper.HandleKeyPress;
            window.KeyUp += inputHelper.HendleKeyReleased;
        }

        private DispatcherTimer SetUpCPUClockTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(CPUClockTimerTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 2); // should be 500Hz
            return dispatcherTimer;
        }
    }
}
