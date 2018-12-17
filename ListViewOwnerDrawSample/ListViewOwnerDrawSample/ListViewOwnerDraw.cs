using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewOwnerDrawSample
{
    public partial class ListViewOwnerDraw : Form
    {
        public ListViewOwnerDraw()
        {
            InitializeComponent();
        }

        // Sets the ListView control to the List view.
        private void menuItemList_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
            listView1.Invalidate();
        }

        // Sets the ListView control to the Details view.
        private void menuItemDetails_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            // Reset the tag on each item to re-enable the workaround in
            // the MouseMove event handler.
            foreach (ListViewItem item in listView1.Items)
            {
                item.Tag = null;
            }
        }

        // Selects and focuses an item when it is clicked anywhere along 
        // its width. The click must normally be on the parent item text.
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = listView1.GetItemAt(5, e.Y);
            if (clickedItem != null)
            {
                clickedItem.Selected = true;
                clickedItem.Focused = true;
            }
        }

        // Draws the backgrounds for entire ListView items.
        private void listView1_DrawItem(object sender,
            DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                // Draw the background for an unselected item.
                using (LinearGradientBrush brush =
                    new LinearGradientBrush(e.Bounds, Color.Orange,
                    Color.Maroon, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }

            // Draw the item text for views other than the Details view.
            if (listView1.View != View.Details)
            {
                e.DrawText();
            }
        }

        // Draws subitem text and applies content-based formatting.
        private void listView1_DrawSubItem(object sender,
            DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;

            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                // Draw the text and background for a subitem with a 
                // negative value. 
                double subItemValue;
                if (e.ColumnIndex > 0 && Double.TryParse(
                    e.SubItem.Text, NumberStyles.Currency,
                    NumberFormatInfo.CurrentInfo, out subItemValue) &&
                    subItemValue < 0)
                {
                    // Unless the item is selected, draw the standard 
                    // background to make it stand out from the gradient.
                    if ((e.ItemState & ListViewItemStates.Selected) == 0)
                    {
                        e.DrawBackground();
                    }

                    // Draw the subitem text in red to highlight it. 
                    e.Graphics.DrawString(e.SubItem.Text,
                        listView1.Font, Brushes.Red, e.Bounds, sf);

                    return;
                }

                // Draw normal text for a subitem with a nonnegative 
                // or nonnumerical value.
                e.DrawText(flags);
            }
        }

        // Draws column headers.
        private void listView1_DrawColumnHeader(object sender,
            DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont =
                            new Font("Helvetica", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }

        // Forces each row to repaint itself the first time the mouse moves over 
        // it, compensating for an extra DrawItem event sent by the wrapped 
        // Win32 control. This issue occurs each time the ListView is invalidated.
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item != null && item.Tag == null)
            {
                listView1.Invalidate(item.Bounds);
                item.Tag = "tagged";
            }
        }

        // Resets the item tags. 
        void listView1_Invalidated(object sender, InvalidateEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item == null) return;
                item.Tag = null;
            }
        }

        // Forces the entire control to repaint if a column width is changed.
        void listView1_ColumnWidthChanged(object sender,
            ColumnWidthChangedEventArgs e)
        {
            listView1.Invalidate();
        }
    }
}
