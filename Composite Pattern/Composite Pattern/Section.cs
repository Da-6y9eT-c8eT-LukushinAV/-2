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
            components.Add(component);
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

        // Поиск: проверяет заголовок или ищет в дочерних компонентах
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

        // Подсчет параграфов: суммирует количество параграфов в дочерних компонентах
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
