using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.Command
{
    public class UpperCaseTextCommand : ICommand
    {
        private readonly LightElementNode _root;
        private readonly List<(LightTextNode node, string originalText)> _backup = new();

        public UpperCaseTextCommand(LightElementNode root)
        {
            _root = root;
        }

        public void Execute()
        {
            Traverse(_root);
        }

        public void Undo()
        {
            foreach (var (node, originalText) in _backup)
            {
                node.Text = originalText;
            }
        }

        private void Traverse(LightElementNode node)
        {
            foreach (var child in node.Children)
            {
                if (child is LightTextNode textNode)
                {
                    _backup.Add((textNode, textNode.Text));
                    textNode.Text = textNode.Text.ToUpper();
                }
                else if (child is LightElementNode element)
                {
                    Traverse(element);
                }
            }
        }
    }

}
