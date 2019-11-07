using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDeseni
{
    class Program
    {
        static void Main(string[] args)
        {
            UrunManager urunManager = new UrunManager(new Fabrika1());
            urunManager.GetALL();
            Console.ReadLine();
        }

        public abstract class Logging
        {
            public abstract void Log(string mesaj);
        }

        public class Logger : Logging
        {
            public override void Log(string mesaj)
            {
                Console.WriteLine("loglandı");
            }
        }

        public class NLogger : Logging
        {
            public override void Log(string mesaj)
            {
                Console.WriteLine("NLOGGER ile loglandı");
            }
        }
        public abstract class Caching
        {
            public abstract void Cache(string data);
        }
        public class MemCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Memory cache ike cachelendi");
            }
        }
        public class Radis : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("radis cache ike cachelendi");
            }
        }
        public abstract class UretimFabrikalari
        {
            public abstract Logging LogOlustuLogging();
            public abstract Caching CacheOlusturCaching();

        }

        public class Fabrika1 : UretimFabrikalari
        {
            public override Logging LogOlustuLogging()
            {
                return new Logger();
            }

            public override Caching CacheOlusturCaching()
            {
                return new Radis();
            }
        }
        public class Fabrika2 : UretimFabrikalari
        {
            public override Logging LogOlustuLogging()
            {
                return new NLogger();
            }

            public override Caching CacheOlusturCaching()
            {
                return new MemCache();
            }

        }
        public class UrunManager
        {
            private UretimFabrikalari _uretimFabrikalari;
            private Logging _logging;
            private Caching _caching;
            public UrunManager(UretimFabrikalari uretimFabrikalari)
            {
                _uretimFabrikalari = uretimFabrikalari;
                _logging = _uretimFabrikalari.LogOlustuLogging();
                _caching = _uretimFabrikalari.CacheOlusturCaching();
            }

            public void GetALL()
            {
                _logging.Log("Loglandı");
                _caching.Cache("Data");

                Console.WriteLine("Ürinler Listelendi");
            }
        }
    }
}


