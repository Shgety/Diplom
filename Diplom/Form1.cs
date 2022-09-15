using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Win32;
using System.Management;

namespace Diplom
{
    public partial class Form1 : Form
    {

        List<string> hash_before = new List<string>();
        List<string> hash_after = new List<string>();
        List<string> processes_before = new List<string>();
        List<string> processes_after = new List<string>();
        List<string> paths = new List<string>();
        List<string> files = new List<string>();
        List<string> reg_before = new List<string>();
        List<string> reg_after = new List<string>();
        private bool hash_checked = false;
        private bool reg_changed = false;
        private Thread th;
        private Thread cpuThread;
        private Thread memoryThread;
        private string result;
        private string[] c = { "C:\\temp" };
        private static List<string> RegScan = new List<string>()
        {
            @"SOFTWARE\Classes\.exe",
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
            //@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WindowsNT\CurrentVersion\Winlogon",
        };
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private double[] cpuArray = new double[10];
        private double[] memoryArray = new double[10];
        private bool cost = true;

        public Form1()
        {
            InitializeComponent();
        }

        private string ComputeMD5Checksum(string path)
        {
            try
            {
                using (FileStream fs = System.IO.File.OpenRead(path))
                using (MD5 md5 = new MD5CryptoServiceProvider())
                {
                    byte[] checkSum = md5.ComputeHash(fs);
                    result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (DirectoryNotFoundException) { }
            catch (OverflowException) { }
            catch (IOException) { }
            return result;
        }

        private void get_all_directories(string[] path)
        {
            string[] allpath;
            for (int i = 0; i < path.Length; i++)
            {
                try
                {
                    if (path[i].Contains("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\") ||
                        path[i].Contains("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Microsoft\\") ||
                        path[i].Contains("C:\\Windows\\Logs\\") || path[i].Contains("Logs") ||
                        path[i].Contains("C:\\Windows\\SoftwareDistribution\\DataStore\\Logs") ||
                        path[i].Contains("C:\\Users\\" + Environment.UserName + "\\AppData\\LocalLow\\Microsoft\\"))
                        continue;
                    allpath = Directory.GetDirectories(path[i]);
                    paths.Add(path[i]);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                };
                get_all_directories(allpath);
            }
        }

        private void get_all_files(List<string> paths)
        {
            foreach (string path in paths)
            {
                try
                {
                    string[] files_ = Directory.GetFiles(path);
                    foreach (string file in files_)
                    {
                        files.Add(file);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                };
            }
        }

        private List<string> compare_processes()
        {
            List<string> new_processes = new List<string>();
            if (processes_after.Count != 0)
            {
                foreach (string p_aft in processes_after)
                {
                    bool p_compared = false;
                    foreach (string p_bef in processes_before)
                        if (p_bef == p_aft)
                        {
                            p_compared = true;
                            break;
                        }
                    if (!p_compared)
                        new_processes.Add(p_aft);
                }
            }
            return new_processes;
        }

        private List<string> register_scan()
        {
            List<string> tmp_reg_keys = new List<string>();
            foreach (string reg_scan in RegScan)
            {
                RegistryKey key = Registry.LocalMachine;
                key = key.OpenSubKey(reg_scan);
                foreach (string keyname in key.GetValueNames())
                    tmp_reg_keys.Add(key.GetValue(keyname).ToString() + "." + key.Name);
            }
            return tmp_reg_keys;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                Filepath_tb.Text = openFileDialog.FileName;
        }

        private void Check_hash_Click(object sender, EventArgs e)
        {
            paths.Clear();
            files.Clear();
            this.get_all_directories(c);
            this.get_all_files(paths);
            Check_hash_btn.Enabled = false;
            if (hash_checked)
            {
                Hash_check_pb.Maximum = files.Count();
                Hash_check_pb.Value = 0;
                hash_after.Clear();
                reg_after = register_scan();
                th = new Thread(new ThreadStart(delegate
                {
                    th.Priority = ThreadPriority.AboveNormal;
                    foreach (string file in files)
                    {
                        Invoke(new ThreadStart(delegate
                        {
                            Checking_File_Label.Text = "Текущий файл: " + file;
                            hash_after.Add(ComputeMD5Checksum(file) + "." + file);
                            try
                            {
                                Hash_check_pb.Value++;
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Hash_check_pb.Value = Hash_check_pb.Maximum;
                            };
                        }));
                    }
                }));
                th.Start();
                foreach (Process p in Process.GetProcesses())
                    processes_after.Add($"{p.Id}.{p.ProcessName}");
                this.Info_lb.Items.Add("Хэш после запуска проверяется...");
            }
            else
            {
                Hash_check_pb.Maximum = files.Count();
                Hash_check_pb.Value = 0;
                hash_before.Clear();
                reg_before = register_scan();
                th = new Thread(new ThreadStart(delegate
                {
                    th.Priority = ThreadPriority.AboveNormal;
                    foreach (string file in files)
                    {
                       Invoke(new ThreadStart(delegate
                       {
                           Checking_File_Label.Text = "Текущий файл: " + file;
                           hash_before.Add(ComputeMD5Checksum(file) + "." + file);
                           try
                           {
                               Hash_check_pb.Value++;
                           }
                           catch (ArgumentOutOfRangeException)
                           {
                               Hash_check_pb.Value = Hash_check_pb.Maximum;
                           };
                       }));
                    }
                }));
                th.Start();
                foreach (Process p in Process.GetProcesses())
                    processes_before.Add($"{p.Id}.{p.ProcessName}");
                hash_checked = true;
                Info_lb.Items.Add("Хэш до запуска проверяется...");

            }
            Check_hash_btn.Enabled = true;
        }

        private void Compare_hash_btn_Click(object sender, EventArgs e)
        {
            reg_changed = false;
            foreach (string r_aft in reg_after)
            {
                bool ok = false;
                foreach (string r_bef in reg_before)
                {
                    if (r_bef == r_aft)
                    {
                        ok = true;
                        break;
                    }
                }
                if (!ok)
                {
                    Registry_lb.Items.Add("В разделе реестра: " + r_aft.Substring(r_aft.IndexOf("HKEY_") + 1));
                    Registry_lb.Items.Add("произошли изменения!");
                    reg_changed = true;
                }
            }
            if (!reg_changed)
                Registry_lb.Items.Add("В разделах реестра не было выявлено изменений!");
            List<string> new_processes = compare_processes();
            foreach (string p in new_processes)
                Processes_lb.Items.Add(p);
            if (hash_after.Count != 0)
            {
                for (int i = 0; i < hash_before.Count; i++)
                {
                    if (hash_before[i] != hash_after[i])
                    {
                        Info_lb.Items.Add("Хэши не совпадают! Файл: " + hash_after[i].Substring(hash_after[i].IndexOf('.') + 1) + " был изменён!");
                        return;
                    }
                }
                Info_lb.Items.Add("Хэши совпадают!");
                return;
            }
            else
            {
                Info_lb.Items.Add("Хэш после запуска не был подсчитан! Подсчитайте хэш после запуска");
            }
        }

        private void Start_file_btn_Click(object sender, EventArgs e)
        {
            if (Filepath_tb.Text != "")
            {
                Process.Start(Filepath_tb.Text.ToString());
                Info_lb.Items.Add("Запуск файла...");
            }
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Network_cb.Items.AddRange(printNetworkCards());
        }
        public string[] printNetworkCards()
        {
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            string[] instancename = category.GetInstanceNames();
            return instancename;
        }

        public float[] getNetworkUtilization(string networkCard)
        {
            const int numberOfIterations = 10;
            PerformanceCounter bandwidthCounter = new PerformanceCounter("Network Interface", "Current Bandwidth", networkCard);
            float bandwidth = bandwidthCounter.NextValue();
            PerformanceCounter dataSentCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", networkCard);
            PerformanceCounter dataReceivedCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", networkCard);
            float sendSum = 0;
            float receiveSum = 0;
            for (int index = 0; index < numberOfIterations; index++)
            {
                sendSum += dataSentCounter.NextValue();
                receiveSum += dataReceivedCounter.NextValue();
            }
            float dataSent = sendSum;
            float dataReceived = receiveSum;
            dataSent /= 1024; dataSent /= 1024; dataReceived /= 1024; dataReceived /= 1024;
            float[] result = { dataSent, dataReceived };
            return result;
        }
        private void getPerformanceCounters()
        {
            var cpuPerfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            while (true)
            {
                cpuArray[cpuArray.Length - 1] = Math.Round(cpuPerfCounter.NextValue(), 0);
                Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);
                if (cost == true)
                {
                    if (CPU_chart.IsHandleCreated)
                    {
                        Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                    }
                    else { }

                    Thread.Sleep(1000);
                }
            }
        }
        private void UpdateCpuChart()
        {
            CPU_chart.Series["CPU"].ChartType = SeriesChartType.Spline;
            CPU_chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            CPU_chart.Series["CPU"].Points.Clear();
            if (cpuArray[cpuArray.Length - 1] > 90)
                Registry_lb.Items.Add("Загрузка процессора превышает 90%! Проверьте активные процессы!");
            for (int i = 0; i < cpuArray.Length - 1; ++i)
                CPU_chart.Series["CPU"].Points.AddY(cpuArray[i]);
        }
        private void getMemoryCounters()
        {
            var memoryPerfCounter = new PerformanceCounter("Memory", "Cache Bytes");
            while (true)
            {
                double value = memoryPerfCounter.NextValue() / 100000;
                memoryArray[memoryArray.Length - 1] = value;
                Array.Copy(memoryArray, 1, memoryArray, 0, memoryArray.Length - 1);
                if (cost == true)
                {
                    if (Memory_chart.IsHandleCreated)
                    {
                        try
                        {
                            Invoke((MethodInvoker)delegate { UpdateMemoryChart(); });
                        }
                        catch (ObjectDisposedException)
                        { }
                    }
                    else { }

                    Thread.Sleep(1000);
                }
            }
        }
        private void UpdateMemoryChart()
        {
            Memory_chart.Series["Memory"].ChartType = SeriesChartType.Spline;
            Memory_chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            Memory_chart.Series["Memory"].Points.Clear();
            for (int i = 0; i < memoryArray.Length - 1; ++i)
                Memory_chart.Series["Memory"].Points.AddY(memoryArray[i]);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            cpuThread = new Thread(new ThreadStart(getPerformanceCounters));
            cpuThread.IsBackground = true;
            cpuThread.Start();
            memoryThread = new Thread(new ThreadStart(getMemoryCounters));
            memoryThread.IsBackground = true;
            memoryThread.Start();
            if (Network_cb.SelectedItem != null)
            {
                float[] NetworkUsage = getNetworkUtilization(Network_cb.SelectedItem.ToString());
                Network_lb.Items.Add("Загрузка, Мб: " + NetworkUsage[1] + " Отдача, Мб: " + NetworkUsage[0]);
                Network_lb.TopIndex = Network_lb.Items.Count - 1;
                Registry_lb.TopIndex = Registry_lb.Items.Count - 1;
                Info_lb.TopIndex = Registry_lb.Items.Count - 1;
                if (NetworkUsage[1] > 80)
                    Registry_lb.Items.Add("Чрезмерное использование сетевого адаптера! Проверьте процессы, использующие сеть.");
            }
            return;      
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                cpuThread.Abort();
                memoryThread.Abort();
            }
            catch (NullReferenceException)
            { }
            catch (ObjectDisposedException)
            { }
        }
    }
}
