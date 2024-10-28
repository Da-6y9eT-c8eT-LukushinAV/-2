using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    public class Document : IDocumentComponent
    {
        private List<IDocumentComponent> sections = new List<IDocumentComponent>();

        public void Add(IDocumentComponent component)
        {
            sections.Add(component);
        }

        public void Remove(IDocumentComponent component)
        {
            sections.Remove(component);
        }

        public void Display(int depth = 0)
        {
            Console.WriteLine("Документ:");
            foreach (var section in sections)
            {
                section.Display(depth + 2);
            }
        }

        // Поиск в документе
        public IDocumentComponent Find(string title)
        {
            foreach (var section in sections)
            {
                var found = section.Find(title);
                if (found != null)
                    return found;
            }
            return null;
        }

        // Подсчет параграфов в документе
        public int CountParagraphs()
        {
            int count = 0;
            foreach (var section in sections)
            {
                count += section.CountParagraphs();
            }
            return count;
        }
    }


}
