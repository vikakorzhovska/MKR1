using Mkr1;

var div = new LightElementNode("div", "block", false);
div.CssClasses.Add("container");

var h1 = new LightElementNode("h1", "block", false);
h1.AddChild(new LightTextNode("Welcome to LightHTML"));

var ul = new LightElementNode("ul", "block", false);

var li1 = new LightElementNode("li", "block", false);
li1.AddChild(new LightTextNode("Item 1"));
var li2 = new LightElementNode("li", "block", false);
li2.AddChild(new LightTextNode("Item 2"));
var li3 = new LightElementNode("li", "block", false);
li3.AddChild(new LightTextNode("Item 3"));

ul.AddChild(li1);
ul.AddChild(li2);
ul.AddChild(li3);

div.AddChild(h1);
div.AddChild(ul);

Console.WriteLine(div.OuterHTML());

Console.WriteLine("\n===Iterator===");

var errorTestDiv = new LightElementNode("div");
errorTestDiv.CssClasses.Add("container");

var errLi1 = new LightElementNode("li");
errLi1.CssClasses.Add("error");

var okLi = new LightElementNode("li");
okLi.CssClasses.Add("ok");

var errLi2 = new LightElementNode("li");
errLi2.CssClasses.Add("error");

errorTestDiv.AddChild(errLi1);
errorTestDiv.AddChild(okLi);
errorTestDiv.AddChild(errLi2);

var iterator = errorTestDiv.GetIterator("error");
while (iterator.MoveNext())
{
    Console.WriteLine($"Found: <{iterator.Current.TagName} class=\"{string.Join(" ", iterator.Current.CssClasses)}\">");
}