using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Pattern
{


    public class Proxy : ISubject
    {
        private RealSubject _realSubject;
        private readonly Dictionary<string, (string Response, DateTime CacheTime)> _cache;
        private readonly TimeSpan _cacheDuration;

        // Список пользователей с правами
        private readonly List<string> _allowedUsers;
        private string _currentUser;

        public Proxy(string currentUser)
        {
            _realSubject = new RealSubject();
            _cache = new Dictionary<string, (string Response, DateTime CacheTime)>();
            _cacheDuration = TimeSpan.FromMinutes(5); // Длительность жизни кэша
            _allowedUsers = new List<string> { "admin", "manager" }; // Пример списка пользователей с доступом
            _currentUser = currentUser; // Текущий пользователь
        }

        public string Request(string request)
        {
            Console.WriteLine($"[Proxy]: Получен запрос '{request}'");

            // Проверка доступа
            if (!HasAccess())
            {
                Console.WriteLine("[Proxy]: Доступ запрещен.");
                return "Ошибка: доступ запрещен.";
            }

            // Проверка кэша
            if (_cache.TryGetValue(request, out var cacheEntry))
            {
                if (DateTime.Now - cacheEntry.CacheTime < _cacheDuration)
                {
                    Console.WriteLine("[Proxy]: Результат взят из кэша.");
                    return cacheEntry.Response;
                }
                else
                {
                    Console.WriteLine("[Proxy]: Кэш устарел, удаляю запись.");
                    _cache.Remove(request);
                }
            }

            // Запрос к реальному объекту
            string response = _realSubject.Request(request);

            // Сохранение в кэш
            _cache[request] = (response, DateTime.Now);
            return response;
        }

        private bool HasAccess()
        {
            // Проверка прав доступа для текущего пользователя
            if (_allowedUsers.Contains(_currentUser))
            {
                Console.WriteLine($"[Proxy]: Доступ разрешен пользователю '{_currentUser}'.");
                return true;
            }
            else
            {
                Console.WriteLine($"[Proxy]: Доступ запрещен пользователю '{_currentUser}'.");
                return false;
            }
        }
    }

}
