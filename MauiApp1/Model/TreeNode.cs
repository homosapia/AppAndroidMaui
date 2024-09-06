using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class TreeNode
    {
        public int Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public List<TreeNode> Children { get; set; } = new List<TreeNode>();
    }
}
