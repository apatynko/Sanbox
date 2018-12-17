using System;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace ListViewOwnerDrawSample
{
    partial class ListViewOwnerDraw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                contextMenu1.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Initialize the ListView control.
            listView1.BackColor = Color.Black;
            listView1.ForeColor = Color.White;
            listView1.Dock = DockStyle.Fill;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            // Add columns to the ListView control.
            listView1.Columns.Add("Name", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("First", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Second", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Third", 100, HorizontalAlignment.Center);

            // Create items and add them to the ListView control.
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "One", "20", "30", "-40" }, -1);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "Two", "-250", "145", "37" }, -1);
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "Three", "200", "800", "-1,001" }, -1);
            ListViewItem listViewItem4 = new ListViewItem(new string[] { "Four", "not available", "-2", "100" }, -1);
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4 });

            // Initialize the shortcut menu and 
            // assign it to the ListView control.
            contextMenu1.MenuItems.Add("List",
                new EventHandler(menuItemList_Click));
            contextMenu1.MenuItems.Add("Details",
                new EventHandler(menuItemDetails_Click));
            listView1.ContextMenu = contextMenu1;

            // Configure the ListView control for owner-draw and add 
            // handlers for the owner-draw events.
            listView1.OwnerDraw = true;
            listView1.DrawItem += new
                DrawListViewItemEventHandler(listView1_DrawItem);
            listView1.DrawSubItem += new
                DrawListViewSubItemEventHandler(listView1_DrawSubItem);
            listView1.DrawColumnHeader += new
                DrawListViewColumnHeaderEventHandler(listView1_DrawColumnHeader);

            // Add a handler for the MouseUp event so an item can be 
            // selected by clicking anywhere along its width.
            listView1.MouseUp += new MouseEventHandler(listView1_MouseUp);

            // Add handlers for various events to compensate for an 
            // extra DrawItem event that occurs the first time the mouse 
            // moves over each row. 
            listView1.MouseMove += new MouseEventHandler(listView1_MouseMove);
            listView1.ColumnWidthChanged += new ColumnWidthChangedEventHandler(listView1_ColumnWidthChanged);
            listView1.Invalidated += new InvalidateEventHandler(listView1_Invalidated);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(listView1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ClientSize = new System.Drawing.Size(450, 150);
            this.Text = "ListView OwnerDraw Example";
        }

        #endregion

        private ListView listView1 = new ListView();
        private ContextMenu contextMenu1 = new ContextMenu();
    }
}

