using MauiApp1.Interfase;
using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class TreeBuilderServices : ITreeBuilderServices
    {
        public IEnumerable<TreeNode> BuildTree(IEnumerable<Response> responses)
        {
            if (responses == null)
                return new List<TreeNode>();

            var lookup = responses.ToLookup(r => (int.TryParse(r.Parent_ID, out int parentId) ? parentId : -1), r => new TreeNode
            {
                Id = r.Id,
                ParentId = r.Parent_ID,
                Name = r.Name
            });

            var rootNodes = lookup[-1];

            foreach (var rootNode in rootNodes)
            {
                BuildTreeRecursive(rootNode, lookup);
            }

            return rootNodes;
        }

        private void BuildTreeRecursive(TreeNode node, ILookup<int, TreeNode> lookup)
        {
            if (lookup.Contains(node.Id))
            {
                var children = lookup[node.Id];
                foreach (var child in children)
                {
                    node.Children.Add(child);
                    BuildTreeRecursive(child, lookup);
                }
            }
        }
    }
}
