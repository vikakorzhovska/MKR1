using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.TemplateMethod
{
    public abstract class ListRendererTemplate
    {
        public string RenderList(List<string> items)
        {
            var sb = new StringBuilder();
            sb.Append(RenderHeader());
            foreach (var item in items)
            {
                sb.Append(RenderItem(item));
            }
            sb.Append(RenderFooter(items.Count));
            return sb.ToString();
        }

        protected abstract string RenderHeader();
        protected abstract string RenderItem(string item);
        protected abstract string RenderFooter(int count);
    }

}
