using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    public class Paragraph : IDocumentComponent
    {
        public string Text { get; private set; }

        public Paragraph(string text)
        {
            Text = text;
        }

        public void Add(IDocumentComponent component) { }
        public void Remove(IDocumentComponent component) { }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " " + Text);
        }

        // Поиск в параграфе: проверяет, совпадает ли текст
        public IDocumentComponent Find(string title)
        {
            return Text == title ? this : null;
        }

        // Подсчет параграфов: каждый параграф возвращает 1
        public int CountParagraphs()
        {
            return 1;
        }
    }


}
