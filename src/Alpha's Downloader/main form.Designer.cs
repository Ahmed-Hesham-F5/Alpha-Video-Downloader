namespace Alpha_s_Downloader
{
    partial class main_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            search_button = new Button();
            dataGridView1 = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            URL_Box = new TextBox();
            dowload_btn = new Button();
            checkBox2 = new CheckBox();
            saved_location_btn = new Button();
            default_quality_combobox = new ComboBox();
            Default_max_quality_label = new Label();
            url_label = new Label();
            wait_label = new Label();
            made_by_label = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // search_button
            // 
            search_button.Font = new Font("Segoe UI", 10F);
            search_button.Location = new Point(891, 7);
            search_button.Name = "search_button";
            search_button.Size = new Size(85, 37);
            search_button.TabIndex = 0;
            search_button.Text = "Search";
            search_button.Click += search_btn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1262, 572);
            dataGridView1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // URL_Box
            // 
            URL_Box.Location = new Point(79, 10);
            URL_Box.Name = "URL_Box";
            URL_Box.Size = new Size(525, 27);
            URL_Box.TabIndex = 3;
            URL_Box.KeyDown += URL_Box_KeyDown;
            // 
            // dowload_btn
            // 
            dowload_btn.Location = new Point(991, 7);
            dowload_btn.Name = "dowload_btn";
            dowload_btn.Size = new Size(113, 37);
            dowload_btn.TabIndex = 4;
            dowload_btn.Text = "Download All";
            dowload_btn.UseVisualStyleBackColor = true;
            dowload_btn.Click += dowload_btn_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(729, 14);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(147, 24);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "youtube playlist ?";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // saved_location_btn
            // 
            saved_location_btn.Location = new Point(622, -1);
            saved_location_btn.Name = "saved_location_btn";
            saved_location_btn.Size = new Size(101, 52);
            saved_location_btn.TabIndex = 7;
            saved_location_btn.Text = "save location";
            saved_location_btn.UseVisualStyleBackColor = true;
            saved_location_btn.Click += saved_location_btn_Click;
            // 
            // default_quality_combobox
            // 
            default_quality_combobox.FormattingEnabled = true;
            default_quality_combobox.Location = new Point(1126, 23);
            default_quality_combobox.Name = "default_quality_combobox";
            default_quality_combobox.Size = new Size(138, 28);
            default_quality_combobox.TabIndex = 8;
            default_quality_combobox.SelectedIndexChanged += default_quality_combobox_SelectedIndexChanged;
            // 
            // Default_max_quality_label
            // 
            Default_max_quality_label.AutoSize = true;
            Default_max_quality_label.Location = new Point(1125, -1);
            Default_max_quality_label.Name = "Default_max_quality_label";
            Default_max_quality_label.Size = new Size(139, 20);
            Default_max_quality_label.TabIndex = 9;
            Default_max_quality_label.Text = "Default max quality";
            // 
            // url_label
            // 
            url_label.AutoSize = true;
            url_label.Location = new Point(15, 14);
            url_label.Name = "url_label";
            url_label.Size = new Size(38, 20);
            url_label.TabIndex = 10;
            url_label.Text = "URL:";
            // 
            // wait_label
            // 
            wait_label.AutoSize = true;
            wait_label.Font = new Font("Segoe UI", 12F);
            wait_label.Location = new Point(214, 40);
            wait_label.Name = "wait_label";
            wait_label.Size = new Size(0, 28);
            wait_label.TabIndex = 11;
            // 
            // made_by_label
            // 
            made_by_label.AutoSize = true;
            made_by_label.Location = new Point(232, 656);
            made_by_label.Name = "made_by_label";
            made_by_label.Size = new Size(332, 20);
            made_by_label.TabIndex = 12;
            made_by_label.Text = "Made by: https://github.com/Ahmed-Hesham-F5";
            made_by_label.Click += made_by_label_Click;
            // 
            // main_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 683);
            Controls.Add(made_by_label);
            Controls.Add(wait_label);
            Controls.Add(url_label);
            Controls.Add(Default_max_quality_label);
            Controls.Add(default_quality_combobox);
            Controls.Add(saved_location_btn);
            Controls.Add(checkBox2);
            Controls.Add(dowload_btn);
            Controls.Add(URL_Box);
            Controls.Add(dataGridView1);
            Controls.Add(search_button);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "main_Form";
            Text = "Video downloader";
            Load += Form1_Load;
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button search_button;
        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox URL_Box;
        public Button dowload_btn;
        private CheckBox checkBox2;
        private Button saved_location_btn;
        private ComboBox default_quality_combobox;
        private Label Default_max_quality_label;
        private Label url_label;
        public Label wait_label;
        private Label made_by_label;
    }
}
