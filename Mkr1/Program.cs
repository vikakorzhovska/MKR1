using Mkr1;
using Mkr1.Command;
using Mkr1.State.States;
using Mkr1.State;
using Mkr1.TemplateMethod;

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

Console.WriteLine("\n=== Iterator ===");

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

Console.WriteLine("\n=== Command ===");

var paragraph = new LightElementNode("p");
paragraph.AddChild(new LightTextNode("Hello, "));
paragraph.AddChild(new LightTextNode("world!"));

var command = new UpperCaseTextCommand(paragraph);
command.Execute();

foreach (var child in paragraph.Children.OfType<LightTextNode>())
{
    Console.WriteLine(child.Text);
}

Console.WriteLine("\n=== State ===");

var input = new LightElementNode("input");
input.CssClasses.Add("form-control");

var validator = new ValidationContext(new UncheckedState());

validator.SetState(new InvalidState());
validator.Apply(input);
Console.WriteLine(string.Join(" ", input.CssClasses));

validator.SetState(new ValidState());
validator.Apply(input);
Console.WriteLine(string.Join(" ", input.CssClasses));

Console.WriteLine("\n=== Template Method ===");

var items = new List<string> { "Apple", "Banana", "Cherry" };
var renderer = new SimpleListRenderer();
string renderedList = renderer.RenderList(items);
Console.WriteLine(renderedList);