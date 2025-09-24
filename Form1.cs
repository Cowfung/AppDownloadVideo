using System.Diagnostics;
using System.IO;
using System.Net;
using WinFormsApp1.Properties;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "MyWinFormsApp");
            try
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true); // xóa cả folder
                }
            }
            catch
            {
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += button1_Click;
            comboBox1.Items.Add("mp4");
            comboBox1.Items.Add("mp3");
            comboBox1.SelectedIndex = 0; // mặc định chọn placeholder
            comboBox2.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

           

            button2.Click += buttonDownload_Click;
        }
        private string GetOrUpdateYtDlp()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "MyWinFormsApp");
            Directory.CreateDirectory(tempDir);
            string exePath = Path.Combine(tempDir, "yt-dlp.exe");

            bool needUpdate = false;

            if (!File.Exists(exePath))
            {
                needUpdate = true;
            }
            else
            {
                // Ví dụ: nếu bản yt-dlp cũ hơn 7 ngày thì update
                DateTime lastWrite = File.GetLastWriteTime(exePath);
                if ((DateTime.Now - lastWrite).TotalDays > 7)
                {
                    needUpdate = true;
                }
            }

            if (needUpdate)
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        wc.DownloadFile("https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe", exePath);
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể tải yt-dlp, sẽ dùng bản cũ nếu có.", "Cảnh báo");
                }
            }

            return exePath;
        }
        private string ExtractFfmpeg()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "MyWinFormsApp");
            Directory.CreateDirectory(tempDir);

            string exePath = Path.Combine(tempDir, "ffmpeg.exe");

            if (!File.Exists(exePath))
            {
                File.WriteAllBytes(exePath, Resources.ffmpeg);
            }

            return tempDir; // **trả về folder chứ không phải file**


        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = fbd.SelectedPath;
                }
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            string url = textBox2.Text.Trim();
            string outputDir = textBox3.Text.Trim();
            string format = comboBox1.SelectedItem.ToString();
            string quality = comboBox2.SelectedItem.ToString();

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(outputDir))
            {
                MessageBox.Show("Vui lòng nhập URL và chọn thư mục lưu!");
                return;
            }

            string arguments = BuildArguments(url, outputDir, format, quality);
            RunYtDlp(arguments);
        }

        private string BuildArguments(string url, string outputDir, string format, string quality)
        {
            string ffmpegFolder = ExtractFfmpeg();
            string args = "";

            if (format == "mp4")
            {
                switch (quality)
                {
                    case "Best":
                        args = $"-f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]\" --merge-output-format mp4 --ffmpeg-location \"{ffmpegFolder}\" -o \"{outputDir}\\%(title).50s.%(ext)s\" {url}";
                        break;
                    case "1080p":
                        args = $"-f \"bestvideo[height<=1080][ext=mp4]+bestaudio[ext=m4a]/best[height<=1080][ext=mp4]\" --merge-output-format mp4 --ffmpeg-location \"{ffmpegFolder}\" -o \"{outputDir}\\%(title).50s.%(ext)s\" {url}";
                        break;
                    case "720p":
                        args = $"-f \"bestvideo[height<=720][ext=mp4]+bestaudio[ext=m4a]/best[height<=720][ext=mp4]\" --merge-output-format mp4 --ffmpeg-location \"{ffmpegFolder}\" -o \"{outputDir}\\%(title).50s.%(ext)s\" {url}";
                        break;
                    case "480p":
                        args = $"-f \"bestvideo[height<=480][ext=mp4]+bestaudio[ext=m4a]/best[height<=480][ext=mp4]\" --merge-output-format mp4 --ffmpeg-location \"{ffmpegFolder}\" -o \"{outputDir}\\%(title).50s.%(ext)s\" {url}";
                        break;
                    case "360p":
                        args = $"-f \"bestvideo[height<=360][ext=mp4]+bestaudio[ext=m4a]/best[height<=360][ext=mp4]\" --merge-output-format mp4 --ffmpeg-location \"{ffmpegFolder}\" -o \"{outputDir}\\%(title).50s.%(ext)s\" {url}";
                        break;
                }
            }
            else if (format == "mp3")
            {
                switch (quality)
                {
                    case "Audio Best":
                    case "Audio MP3 320kbps":
                        args = $"-x --audio-format mp3 --audio-quality 0 -o \"{outputDir}\\%(title).50s.%(ext)s\" {url}";
                        break;
                    case "Audio MP3 128kbps":
                        args = $"-x --audio-format mp3 --audio-quality 5 -o \"{outputDir}\\%(title).50s.%(ext)s\" {url}";
                        break;
                }
            }

            return args;
        }


        private void RunYtDlp(string arguments)
        {
            textBoxLog.Clear(); // xóa log cũ

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = GetOrUpdateYtDlp(),
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            Process process = new Process { StartInfo = psi, EnableRaisingEvents = true };

            process.OutputDataReceived += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        textBoxLog.AppendText(e.Data + Environment.NewLine);
                        textBoxLog.SelectionStart = textBoxLog.Text.Length;
                        textBoxLog.ScrollToCaret();
                    }));
                }
            };

            process.ErrorDataReceived += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        textBoxLog.AppendText("[ERR] " + e.Data + Environment.NewLine);
                        textBoxLog.SelectionStart = textBoxLog.Text.Length;
                        textBoxLog.ScrollToCaret();
                    }));
                }
            };

            process.Exited += (s, e) =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    textBoxLog.AppendText("=== Quá trình yt-dlp kết thúc ===" + Environment.NewLine);
                }));
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem.ToString() == "mp4")
            {
                comboBox2.Items.Add("Best");
                comboBox2.Items.Add("1080p");
                comboBox2.Items.Add("720p");
                comboBox2.Items.Add("480p");
                comboBox2.Items.Add("360p");
            }
            else if (comboBox1.SelectedItem.ToString() == "mp3")
            {
                comboBox2.Items.Add("Audio Best");
                comboBox2.Items.Add("Audio MP3 320kbps");
                comboBox2.Items.Add("Audio MP3 128kbps");
            }

            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "Chọn chất lượng";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
