namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиДіюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категоріїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.черговийІнститутуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свояДіяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиПідрозділToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActionPanel = new System.Windows.Forms.Panel();
            this.PropertiesPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SectionBox = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.PropertiesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1475, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиДіюToolStripMenuItem,
            this.додатиПідрозділToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.файлToolStripMenuItem.Text = "Додати";
            // 
            // додатиДіюToolStripMenuItem
            // 
            this.додатиДіюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.категоріїToolStripMenuItem,
            this.свояДіяToolStripMenuItem});
            this.додатиДіюToolStripMenuItem.Name = "додатиДіюToolStripMenuItem";
            this.додатиДіюToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.додатиДіюToolStripMenuItem.Text = "Додати дію";
            this.додатиДіюToolStripMenuItem.Click += new System.EventHandler(this.додатиДіюToolStripMenuItem_Click);
            // 
            // категоріїToolStripMenuItem
            // 
            this.категоріїToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.курсToolStripMenuItem,
            this.черговийІнститутуToolStripMenuItem});
            this.категоріїToolStripMenuItem.Name = "категоріїToolStripMenuItem";
            this.категоріїToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.категоріїToolStripMenuItem.Text = "Категорії";
            // 
            // курсToolStripMenuItem
            // 
            this.курсToolStripMenuItem.Name = "курсToolStripMenuItem";
            this.курсToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.курсToolStripMenuItem.Text = "Курс";
            this.курсToolStripMenuItem.Click += new System.EventHandler(this.курсToolStripMenuItem_Click);
            // 
            // черговийІнститутуToolStripMenuItem
            // 
            this.черговийІнститутуToolStripMenuItem.Name = "черговийІнститутуToolStripMenuItem";
            this.черговийІнститутуToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.черговийІнститутуToolStripMenuItem.Text = "Черговий інституту";
            this.черговийІнститутуToolStripMenuItem.Click += new System.EventHandler(this.черговийІнститутуToolStripMenuItem_Click);
            // 
            // свояДіяToolStripMenuItem
            // 
            this.свояДіяToolStripMenuItem.Name = "свояДіяToolStripMenuItem";
            this.свояДіяToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.свояДіяToolStripMenuItem.Text = "Своя дія";
            this.свояДіяToolStripMenuItem.Click += new System.EventHandler(this.свояДіяToolStripMenuItem_Click);
            // 
            // додатиПідрозділToolStripMenuItem
            // 
            this.додатиПідрозділToolStripMenuItem.Name = "додатиПідрозділToolStripMenuItem";
            this.додатиПідрозділToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.додатиПідрозділToolStripMenuItem.Text = "Додати підрозділ";
            this.додатиПідрозділToolStripMenuItem.Click += new System.EventHandler(this.додатиПідрозділToolStripMenuItem_Click);
            // 
            // ActionPanel
            // 
            this.ActionPanel.AutoScroll = true;
            this.ActionPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ActionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ActionPanel.Location = new System.Drawing.Point(0, 28);
            this.ActionPanel.Name = "ActionPanel";
            this.ActionPanel.Size = new System.Drawing.Size(300, 554);
            this.ActionPanel.TabIndex = 1;
            // 
            // PropertiesPanel
            // 
            this.PropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesPanel.AutoScroll = true;
            this.PropertiesPanel.AutoSize = true;
            this.PropertiesPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PropertiesPanel.Controls.Add(this.button1);
            this.PropertiesPanel.Controls.Add(this.propertyGrid1);
            this.PropertiesPanel.Location = new System.Drawing.Point(1169, 31);
            this.PropertiesPanel.Name = "PropertiesPanel";
            this.PropertiesPanel.Size = new System.Drawing.Size(306, 634);
            this.PropertiesPanel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoEllipsis = true;
            this.button1.Location = new System.Drawing.Point(5, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(297, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Відправити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(5, 0);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(5);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(297, 500);
            this.propertyGrid1.TabIndex = 0;
            // 
            // SectionBox
            // 
            this.SectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionBox.Location = new System.Drawing.Point(306, 31);
            this.SectionBox.Name = "SectionBox";
            this.SectionBox.SelectedIndex = 0;
            this.SectionBox.Size = new System.Drawing.Size(863, 539);
            this.SectionBox.TabIndex = 3;
            this.SectionBox.SelectedIndexChanged += new System.EventHandler(this.SectionBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1475, 582);
            this.Controls.Add(this.SectionBox);
            this.Controls.Add(this.PropertiesPanel);
            this.Controls.Add(this.ActionPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Комендант";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PropertiesPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додатиДіюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додатиПідрозділToolStripMenuItem;
        private System.Windows.Forms.Panel ActionPanel;
        private System.Windows.Forms.Panel PropertiesPanel;
        private System.Windows.Forms.TabControl SectionBox;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem категоріїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свояДіяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem курсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem черговийІнститутуToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

