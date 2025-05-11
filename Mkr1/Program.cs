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