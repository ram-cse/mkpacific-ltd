using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P13_Composite
{
    class Commposite
    {
        public static void Main()
        {
            Composite root = new Composite("root");
            Leaf firstLeaf = new Leaf("Leaf A");
            root.Add(firstLeaf);
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));


            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            firstLeaf.SetName("First Leaf");

            root.Display(2);

        }
    }

    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    class Composite : Component
    {
        private List<Component> _children = new List<Component>();

        public Composite(string name)
            : base(name)
        { 
        }

        public override void Add(Component component)
        {
            this._children.Add(component);
        }
        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach(Component component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        { }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
