using ContextLibrary.Entities;

namespace ContextLibrary
{
    public class ApplicationContext : IDisposable
    {
        private bool _isDisposed = false;
        private static readonly List<Request> requests = new();
        private static readonly List<Mechanic> mechanics = new();
        private static readonly List<MechanicRequests> mechanicRequests = new();

        public List<Request> Requests { get => requests; }
        public List<Mechanic> Mechanics { get => mechanics; }
        public List<MechanicRequests> MechanicRequests { get => mechanicRequests; }

        // Генерация номера заявки
        public int GenerateRequestNumber()
        {
            return requests.Count + 1; // Просто инкрементируем на основе количества заявок
        }

        // Генерация уникального номера для механика
        public int GenerateMechanicId()
        {
            return mechanics.Count + 1; // Аналогично, инкрементируем ID для механиков
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
