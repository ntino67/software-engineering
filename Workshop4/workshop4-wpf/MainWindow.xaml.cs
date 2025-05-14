using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProcessManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            var processes = Process.GetProcesses()
                .Select(p =>
                {
                    try
                    {
                        return new
                        {
                            p.Id,
                            p.ProcessName,
                            Priority = p.BasePriority,
                            MemoryMB = p.VirtualMemorySize64 / (1024 * 1024),
                            p.Responding
                        };
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(p => p != null)
                .ToList();

            ProcessGrid.ItemsSource = processes;
        }

        private void KillProcess_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = ProcessGrid.SelectedItem;
            if (selected == null) return;

            try
            {
                var process = Process.GetProcessById(selected.Id);
                if (IsCriticalProcess(process)) throw new Exception("Refused: system-critical process.");
                process.Kill();
                MessageBox.Show($"Process {selected.ProcessName} stopped.");
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private bool IsCriticalProcess(Process p)
        {
            string[] critical = { "System", "wininit", "csrss", "lsass", "winlogon", "services", "smss" };
            return critical.Contains(p.ProcessName, StringComparer.OrdinalIgnoreCase);
        }

        private void LaunchProcess_Click(object sender, RoutedEventArgs e)
        {
            string input = ProcessInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Veuillez saisir un nom de processus.");
                return;
            }

            try
            {
                var process = Process.Start(input);
                MessageBox.Show($"Processus '{input}' lancé avec succès. (PID: {process?.Id})");
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du lancement : {ex.Message}");
            }
        }
    }
}
