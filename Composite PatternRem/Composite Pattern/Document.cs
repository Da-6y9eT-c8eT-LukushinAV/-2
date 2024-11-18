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
            // Проверка на допустимый тип
            if (component is Section)
            {
                sections.Add(component);
            }
            else
            {
                throw new InvalidOperationException("В документ можно добавлять только разделы.");
            }
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
