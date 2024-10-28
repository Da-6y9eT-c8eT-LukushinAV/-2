namespace Composite_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();

            Section section1 = new Section("Раздел 1");
            Section subsection11 = new Section("Подраздел 1.1");
            Paragraph para1 = new Paragraph("Параграф 1.");
            Paragraph para2 = new Paragraph("Параграф 2.");
            Section subsection12 = new Section("Подраздел 1.2");
            Paragraph para3 = new Paragraph("Параграф 3.");
            Section section2 = new Section("Раздел 2");
            Section subsection21 = new Section("Подраздел 2.1");
            Paragraph para4 = new Paragraph("Параграф 4.");


            section1.Add(subsection11);
            section1.Add(subsection12);
            section2.Add(subsection21);
            subsection11.Add(para1);
            subsection11.Add(para2);
            subsection12.Add(para3);
            document.Add(section1);
            document.Add(section2);
            subsection21.Add(para4);

            document.Display();

            // Подсчет параграфов
            Console.WriteLine($"\nОбщее количество параграфов: {document.CountParagraphs()}");

            // Поиск по названию
            Console.WriteLine("\nВведите название раздела или параграфа для поиска:");
            string searchTitle = Console.ReadLine();

            IDocumentComponent foundComponent = document.Find(searchTitle);
            if (foundComponent != null)
            {
                Console.WriteLine("\nНайденный компонент:");
                foundComponent.Display(0);
            }
            else
            {
                Console.WriteLine("Компонент с таким названием не найден.");
            }

            Console.ReadLine();
        }
    }

}
