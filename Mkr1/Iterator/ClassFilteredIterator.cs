using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.Iterator
{
    public class ClassFilteredIterator : ILightNodeIterator
    {
        private readonly List<LightElementNode> _elements;
        private readonly string _className;
        private int _currentIndex = -1;

        public ClassFilteredIterator(LightElementNode root, string className)
        {
            _className = className;
            _elements = new List<LightElementNode>();
            Traverse(root);
        }

        private void Traverse(LightElementNode node)
        {
            if (node.CssClasses.Contains(_className))
                _elements.Add(node);

            foreach (var child in node.Children)
            {
                if (child is LightElementNode childElement)
                    Traverse(childElement);
            }
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _elements.Count;
        }

        public LightElementNode Current => _elements[_currentIndex];
        public void Reset() => _currentIndex = -1;
    }

}
