using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    public class Section : IDocumentComponent
    {
        public string Title { get; private set; }
        private List<IDocumentComponent> components = new List<IDocumentComponent>();

        public Section(string title)
        {
            Title = title;
        }

        public void Add(IDocumentComponent component)
        {
            // Проверка на допустимые типы
            if (component is Section || component is Paragraph)
            {
                components.Add(component);
            }
            else
            {
                throw new InvalidOperationException("В раздел можно добавлять только параграфы или подразделы.");
            }
        }

        public void Remove(IDocumentComponent component)
        {
            components.Remove(component);
        }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " " + Title);
            foreach (var component in components)
            {
                component.Display(depth + 2);
            }
        }

        public IDocumentComponent Find(string title)
        {
            if (Title == title)
                return this;

            foreach (var component in components)
            {
                var found = component.Find(title);
                if (found != null)
                    return found;
            }
            return null;
        }

        public int CountParagraphs()
        {
            int count = 0;
            foreach (var component in components)
            {
                count += component.CountParagraphs();
            }
            return count;
        }
    }

}
