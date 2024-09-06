using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class TreeView : StackLayout
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<TreeNode>), typeof(TreeView), null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<TreeNode> ItemsSource
        {
            get => (IEnumerable<TreeNode>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var treeView = (TreeView)bindable;
            treeView.Children.Clear();
            if (newValue is IEnumerable<TreeNode> items)
            {
                foreach (var item in items)
                {
                    treeView.Children.Add(CreateTreeNodeView(item));
                }
            }
        }

        private static View CreateTreeNodeView(TreeNode node)
        {
            var stackLayout = new StackLayout();
            var label = new Label { Text = node.Name };
            stackLayout.Children.Add(label);

            if (node.Children.Any())
            {
                var expandButton = new Button { Text = "Expand" };
                expandButton.Clicked += (sender, args) =>
                {
                    if (expandButton.Text == "Expand")
                    {
                        foreach (var child in node.Children)
                        {
                            stackLayout.Children.Add(CreateTreeNodeView(child));
                        }
                        expandButton.Text = "Collapse";
                    }
                    else
                    {
                        for (int i = 0; i < node.Children.Count; i++)
                        {
                            stackLayout.Children.RemoveAt(2);
                        }
                        expandButton.Text = "Expand";
                    }
                };
                stackLayout.Children.Add(expandButton);
            }

            return stackLayout;
        }
    }
}
