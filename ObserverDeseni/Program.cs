using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDeseni
{
    class Program
    {
        static void Main(string[] args)
        {
            var musteriObserver=new MusteriObserver();
            UrunYonetimi urunYonetimi=new UrunYonetimi();

            
            urunYonetimi.Ekle(musteriObserver);
            urunYonetimi.Ekle(new Calısan());
           // urunYonetimi.Bildir();
            urunYonetimi.Ayır(musteriObserver);
            urunYonetimi.FiyatGuncelle();

            Console.ReadLine();
        }

    }

    class UrunYonetimi
    {
        List<Observer> observers=new List<Observer>();
        public void FiyatGuncelle()
        {
            Console.WriteLine("ürün fiyatı güncellendi");
            Console.WriteLine("--------------------------");
            Bildir();
        }

        public void Ekle(Observer observer)
        {
            observers.Add(observer);
        }

        public void Ayır(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Bildir()
        {
            foreach (var observer in observers)
            {
                observer.Guncelle();
            }
        }
    }

     abstract class Observer
     {
         public abstract void Guncelle();
     }

     class MusteriObserver:Observer
     {
         public override void Guncelle()
         {
             Console.WriteLine("ÜRÜNÜN FİYATI DEĞİŞTİ VE MÜŞTERİLER BİLGİLENDİRİLDİ");
             Console.WriteLine("--------------------------");
        }
         
     }

     class Calısan:Observer
     {
         public override void Guncelle()
         {
             Console.WriteLine("ÜRÜNÜN FİYATI DEĞİŞT VE ÇALIŞANLAR BİLGİLENDİRİLDİ");
             Console.WriteLine("--------------------------");
        }
     }
}
