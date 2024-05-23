using kutyak_infojegyzet_eredeti.Data;
using System;

namespace kutyak_infojegyzet_eredeti
{
    internal static class ApplicationWorker
    {
        public readonly static DataContext dataContext;
        public static event EventHandler ApplicationReady;
        static ApplicationWorker()
        {
            dataContext = new DataContext();
        }

        public static void Start()
        {
            ApplicationReady?.Invoke(null, null);
        }
    }
}
