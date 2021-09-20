using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCvProject
{
    public static class ToastrService
    {
        private static readonly List<(DateTime Date, string sessionId, Toastr Toastr)> _toastrs =
            new List<(DateTime Date, string sessionId, Toastr Toastr)>();

        private static string GetSessionId()
        {
            return HttpContext.Current.Session.SessionID;
        }

        public static void AddToUserQueue(Toastr toastr)
        {
    
            _toastrs.Add((Date: DateTime.Now, SessionId: GetSessionId(), Toastr: toastr));
        }


        public static void AddToUserQueue(string message, string title, ToastrType type)
        {
            AddToUserQueue(new Toastr(message, title, type));
        }

        public static bool HasUserQueue()
        {
            string session = GetSessionId();
            return _toastrs.Any(x => x.sessionId == session);

            // linq'da bir fonksiyonun dönüşüne eşit olan ifadeleri linq içinde yazmaktansa
            // fonksiyondan dönen değeri başka bir değişkene atıp linq içinde sorgulamak dağa doğrudur çünkü
            // hande edememe(çevirememe) sorunu ile karşılaşılabilir. 
        }

        public static void RemoveUserQueue()
        {
            string session = GetSessionId();
            _toastrs.Any(x => x.sessionId == session);

        }

        public static void clearAll()
        {
            _toastrs.Clear();
        }

        // referans type oldukları için yeni bir listeye kopyalamadan silersek diğerinden de silinir bu nedenle
        // kopyalama işlemi için, yani kuyruğu okuyup başka bir yere atamak için bir metod yazıyoruz.
        public static List<(DateTime Date, string sessionId, Toastr Toastr)> ReadUserQueue()
        {
            string session = GetSessionId();
            return _toastrs.Where(x => x.sessionId == session).OrderBy(x => x.Date).ToList();
        }

        // mesajları okuyup ardından sileceğiz 
        
        public static List<(DateTime Date, string sessionId, Toastr Toastr)> ReadAndRemoveUserQueue()
        {
            var list = ReadUserQueue();
            RemoveUserQueue();

            return list; 
        }
    }
}