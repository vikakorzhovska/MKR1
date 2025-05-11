using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.TemplateMethod
{
    public class SimpleListRenderer : ListRendererTemplate
    {
        protected override string RenderHeader() => "<ul>";
        protected override string RenderItem(string item) => $"<li>{item}</li>";
        protected override string RenderFooter(int count) => $"</ul><!-- {count} items uploaded -->";
    }

}
