using ConsoleApp1;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Security.Policy;

namespace Alpha_s_Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await dependencies.validate_dependencies(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            default_quality_combobox.DataSource = (new List<string> { "mp3", "144p", "240p", "360p", "480p", "720p", "1080p", "1440p", "2160p", "4320p" });
            default_quality_combobox.SelectedIndex = 5;

        }


        BindingList<VideoDetails> list = new BindingList<VideoDetails>();
        private async void search_btn_Click(object sender, EventArgs e)
        {
            try
            {

                search_button.Enabled = false;
                dowload_btn.Enabled = false;
                var url = URL_Box.Text;

                dataGridView1.DataSource = null;       // Clear old DataSource
                dataGridView1.Rows.Clear();            // Clear any existing rows
                dataGridView1.Columns.Clear();         // Clear any existing columns      // Clear any existing columns
                dataGridView1.AllowUserToAddRows = false;

                list.Clear();  // This will also clear the DataGridView


                wait_label.Text = "Searching... please wait";
                list = await Task.Run(() => loadprocess.load_playlist(url));
                wait_label.Text = "";
                if (list.Count == 0)
                {

                    search_button.Enabled = true;
                    dowload_btn.Enabled = true;
                    return;
                }


                dataGridView1.AutoGenerateColumns = false;

                // Create columns
                DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Title",
                    DataPropertyName = "title",
                    ReadOnly = true,
                    Width = 450
                };
                dataGridView1.Columns.Add(nameColumn);

                DataGridViewTextBoxColumn linkcolumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Video Link",
                    Name = "link",
                    DataPropertyName = "link",
                    ReadOnly = true,
                    Width = 450
                };
                dataGridView1.Columns.Add(linkcolumn);

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Download ?",
                    Name = "download",
                    DataPropertyName = "download",
                    Width = 100, // Adjust width as needed
                    TrueValue = true,
                    FalseValue = false,

                };
                dataGridView1.Columns.Add(checkBoxColumn);

                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Selected max quality to download",
                    Name = "quality",
                    DataPropertyName = "qualities",
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    DataSource = new List<string> { "mp3", "144p", "240p", "360p", "480p", "720p", "1080p", "1440p", "2160p", "4320p" }, // Define options

                };
                dataGridView1.Columns.Add(comboBoxColumn);

                dataGridView1.DataSource = list;

                for (int i = 0; i < list.Count; i++)
                {
                    //dataGridView1.Rows[i].Height = list[i].Image.Height;
                    dataGridView1.Rows[i].Height = 120;
                }

                search_button.Enabled = true;
                dowload_btn.Enabled = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void URL_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                search_button.PerformClick();
                e.SuppressKeyPress = true;  // Suppress the beep sound and the key event

                e.Handled = false; // Suppress the beep sound
            }

        }

        private async void dowload_btn_Click(object sender, EventArgs e)
        {
            try
            {


                search_button.Enabled = false;
                dowload_btn.Enabled = false;
                List<Task> tasks = new List<Task>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Skip the "new row" at the end, if it's enabled
                    if (row.IsNewRow) continue;

                    string url = row.Cells["link"].Value?.ToString(); // Assuming your DataGridView column is named "Name"
                    bool dowmload = Convert.ToBoolean(row.Cells["download"].Value ?? 0); // Convert to int, handling null values
                    string quality = row.Cells["quality"].Value?.ToString();
                    if (dowmload)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            await saveprocess.savefile(url, quality);
                        }));
                    }
                }
                if (tasks.Count != 0)
                {
                    wait_label.Text = "Downloading... please wait";
                    // Wait for all tasks to finish
                    await Task.WhenAll(tasks);

                    wait_label.Text = "";
                    MessageBox.Show("Download completed.");
                    dataGridView1.DataSource = null;       // Clear old DataSource
                    dataGridView1.Rows.Clear();            // Clear any existing rows
                    dataGridView1.Columns.Clear();         // Clear any existing columns      // Clear any existing columns
                    dataGridView1.AllowUserToAddRows = false;

                    list.Clear();  // This will also clear the DataGridView
                }
                else
                {
                    MessageBox.Show("Nothing to download search correctly first");
                }

                search_button.Enabled = true;
                dowload_btn.Enabled = true;
            }
            catch (Exception ex) { 
                    MessageBox.Show(ex.Message);
            }
        }
        public static bool is_youtubeplaylist = false;
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            is_youtubeplaylist = checkBox2.Checked;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            URL_Box.Focus();
        }

        private void default_quality_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadprocess.default_quality = default_quality_combobox.Text;
        }

        private void saved_location_btn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.ShowNewFolderButton = true;
                folderDialog.InitialDirectory = saveprocess.downloadPath;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    saveprocess.downloadPath = folderDialog.SelectedPath;
                }
            }
        }

        private void made_by_label_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/Ahmed-Hesham-F5",
                    UseShellExecute = true // This is important to open in the default browser
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as invalid URLs
                MessageBox.Show($"Failed to open URL: {ex.Message}");
            }
        }
    }
}
