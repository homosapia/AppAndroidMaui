using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Interfase
{
    public interface ITreeBuilderServices
    {
        public IEnumerable<TreeNode> BuildTree(IEnumerable<Response> responses);
    }
}
