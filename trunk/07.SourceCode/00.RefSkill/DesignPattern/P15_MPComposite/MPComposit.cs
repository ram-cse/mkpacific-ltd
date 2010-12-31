using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P15_MPComposite
{
    class MPComposit
    {
        static void Main(string[] args)
        {
            Component root = new Composite();
            root.Add(new Leaf());
            root.Add(new Leaf());

            Component node = new Composite();
            node.ten = "abc";
            node.Add(new Leaf());

            root.Add(node);
            root.Display(2);

        }
    }

    abstract class Component
    {
        public string ten;
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public virtual void Display(int depth)
        {
            Console.WriteLine("Defining...");
        }

        public Component()
        {
            // TODO: Complete member initialization
        }
    }

    class Composite : Component
    {
        List<Component> lstComponent = new List<Component>();
        public override void Add(Component component)
        {
            this.lstComponent.Add(component);
        }
        public override void Remove(Component component)
        {
            this.lstComponent.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + this.ten);
            foreach (Component c in lstComponent)
            {
                c.Display(depth + 2);
            }
        }
    }

    class Leaf : Component
    {
        public override void Add(Component component)
        {
            Console.WriteLine("Leaf do not define Add()");
        }

        public override void Remove(Component component)
        {
            Console.WriteLine("Leaf do not define Remove()");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + "Left." + depth);
        }
    }
}
