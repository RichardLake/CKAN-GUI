using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CKAN
{
    public partial class ModInfoPanel : UserControl
    {
        public ModInfoPanel()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;


        /// <summary> 
        /// Clean up any resources being used.
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

        private TableLayoutPanel main_panel;
        private LabelledLabel version;
        private LabelledLabel status;
        private LabelledLabel license;
        private LabelledLabel author;
        private LabelledLinkLabel repo;
        private LabelledLinkLabel homepage;
        private Label mod_name;
        private RichTextBox description;

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            main_panel = new TableLayoutPanel();
            SuspendLayout();
            // 
            // main_panel
            // 
            main_panel.ColumnCount = 2;            
            main_panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            main_panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            main_panel.Location = new Point(0, 0);
            main_panel.Name = "main_panel";
            main_panel.TabIndex = 0;
            // 
            // ModInfoPanel
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(main_panel);
            Name = "ModInfoPanel";


            //Mod Name
            mod_name = new Label();
            main_panel.Controls.Add(mod_name, 0, 0);
            main_panel.SetColumnSpan(mod_name, 2);
            main_panel.SetRowSpan(mod_name, 2);
            mod_name.TextAlign = ContentAlignment.MiddleCenter;
            mod_name.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);

            //Mod Abstract
            description = new RichTextBox();
            main_panel.Controls.Add(description, 0 , 2);
            main_panel.SetColumnSpan(description, 2);
            main_panel.SetRowSpan(description, 2);




            //Mod Info
            version = new LabelledLabel("Version");
            license= new LabelledLabel("License");
            author= new LabelledLabel("Author");

            homepage = new LabelledLinkLabel("Homepage");
            repo = new LabelledLinkLabel("Repo");
            status = new LabelledLabel("Release status");

            AddAtRow(main_panel, version,3);
            AddAtRow(main_panel, license, 4);
            AddAtRow(main_panel, author, 5);
            AddAtRow(main_panel, homepage, 6);
            AddAtRow(main_panel, repo, 7);
            AddAtRow(main_panel, status, 8);

            ResumeLayout(false);
        }

        private static void AddAtRow(TableLayoutPanel panel, LabelledLabel label, int row)
        {
            panel.Controls.Add(label.Label, 0,row);
            panel.Controls.Add(label.item, 1, row);
        }

        private static void AddAtRow(TableLayoutPanel panel, LabelledLinkLabel label, int row)
        {
            panel.Controls.Add(label.Label, 0, row);
            panel.Controls.Add(label.item, 1, row);
        }


        private class LabelledLabel
        {
            internal Label item;
            internal Label Label;

            public LabelledLabel(string label_text)
            {
                item = new Label();
                Label = new Label {Text = label_text};
            }

            public void SetText(string text = null)
            {
                item.Text = text == null ? String.Empty : text;                
            }
        }

        private class LabelledLinkLabel
        {
            internal readonly LinkLabel item;
            internal readonly Label Label;

            public LabelledLinkLabel(string label_text)
            {
                item = new LinkLabel();
                Label = new Label { Text = label_text };
                item.LinkClicked += Clicked;
            }

            private void Clicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                if (item.Text == "N/A")
                {
                }
                //TODO Work this out. 
            }

            public void SetText(string text = null)
            {
                item.Links.Clear();                
                item.Text = text == null ? "N/A" : text;
            }
        }

        
    }
}