using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MsCrmTools.ScriptsFinder.Forms
{
    public partial class OrderDialog : Form
    {
        private readonly List<Script> _items;

        public OrderDialog(List<Script> items)
        {
            InitializeComponent();

            _items = items;

            if (items.All(i => i.Type.Contains("Library")))
            {
                lblHeaderTitle.Text = @"Order libraries";
                lvItems.Columns.Add(new ColumnHeader { Text = @"Library", Width = 200 });
            }
            else
            {
                lblHeaderTitle.Text = $@"Order calls for event {items.First().Event}";
                lvItems.Columns.Add(new ColumnHeader { Text = @"Method", Width = 200 });
                lvItems.Columns.Add(new ColumnHeader { Text = @"Library", Width = 200 });
            }
        }

        private void btnSolutionPickerValidate_Click(object sender, System.EventArgs e)
        {
            var index = 0;
            foreach (ListViewItem item in lvItems.Items)
            {
                ((Script)item.Tag).NewOrder = index++;
            }
        }

        private void Move_Click(object sender, System.EventArgs e)
        {
            if (lvItems.SelectedItems.Count == 0) return;

            var currentIndex = lvItems.SelectedItems[0].Index;
            var item = lvItems.SelectedItems[0];

            if (sender == tsbMoveUp)
            {
                if (currentIndex == 0) return;
                lvItems.Items.Remove(item);
                lvItems.Items.Insert(currentIndex - 1, item);
            }
            else
            {
                if (currentIndex == lvItems.Items.Count - 1) return;
                lvItems.Items.Remove(item);
                lvItems.Items.Insert(currentIndex + 1, item);
            }
        }

        private void OrderDialog_Load(object sender, System.EventArgs e)
        {
            lvItems.Items.AddRange(_items
                .OrderBy(i => i.NewOrder ?? i.Order)
                .Select(i =>
                    i.Type.Contains("Library")
                        ? new ListViewItem(i.NewLibrary ?? i.Library) { Tag = i }
                        : new ListViewItem(i.NewMethodCalled ?? i.MethodCalled)
                        { Tag = i, SubItems = { i.NewLibrary ?? i.Library } })
                .ToArray());
        }
    }
}