using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDeseni
{
    class Program
    {
        static void Main(string[] args)
        {
            Madiator madiator= new Madiator();
            Ogretmen tahirHocaOgretmen = new Ogretmen (madiator);
            tahirHocaOgretmen.Isim = "Tahir Hoca";
            madiator.Ogretmen = tahirHocaOgretmen;
            
            Ogrenci hasanOgrenci=new Ogrenci(madiator);
            hasanOgrenci.Isim = "hasan";

            Ogrenci aliOgrenci = new Ogrenci(madiator);
            aliOgrenci.Isim = "ali";

            madiator.Ogrenciler=new List<Ogrenci>{hasanOgrenci,aliOgrenci};

            tahirHocaOgretmen.SlaytGonder("slayt.pdf");
            Console.WriteLine("--------------------------------");

            tahirHocaOgretmen.KarsilaSoru("doğru mu?",aliOgrenci);
            Console.WriteLine("--------------------------------");

            tahirHocaOgretmen.SoruCevabi("yanlış mı?",hasanOgrenci);
            Console.WriteLine("--------------------------------");

            aliOgrenci.KarsilaCevap("evet");
            Console.WriteLine("--------------------------------");

            hasanOgrenci.KarsilaImage("slayt.pdf");
            Console.WriteLine("--------------------------------");

            aliOgrenci.KarsilaImage("slayt.pdf");
            Console.WriteLine("--------------------------------");

            hasanOgrenci.KarsilaCevap("hayır");

            Console.ReadLine();

        }
    }

    abstract class  Kurs
    {
        protected Madiator Madiator;

        protected Kurs(Madiator  madiator)
        {
            Madiator = madiator;
        }
    } 

    class Ogretmen:Kurs
    {
        public Ogretmen(Madiator madiator) : base(madiator)
        {

        }

        public string Isim { get; set; }

        public void KarsilaSoru(string soru, Ogrenci ogrenci)
        {
           Console.WriteLine("Öğretmen soruyu aldı {0},{1}", soru, ogrenci.Isim);
        }

        public void SlaytGonder(string url)
        {
            Console.WriteLine("Öğretmen slaytı değiştirdi: {0}",url);
            Madiator.ResimYukle(url);
        }

        public void SoruCevabi(string cevap, Ogrenci ogrenci)
        {
            Console.WriteLine("Öğretmen soruyu cevapladı {0},{1}",cevap,ogrenci.Isim);
        }
        
    }

    class Ogrenci:Kurs
    {
        public Ogrenci(Madiator madiator) : base(madiator)
        {

        }

        public void KarsilaImage(string url)
        {
            Console.WriteLine("{1} resimi karşıladı {0}",url,Isim);
        }

        public void KarsilaCevap(string cevap)
        {
          Console.WriteLine("{1} cevabı karşıladı {0}",cevap,Isim);
        }

        public string Isim { get; set; }

        
    }
     
    class Madiator
    {
        public Ogretmen Ogretmen { get; set; }
        public List<Ogrenci> Ogrenciler { get; set; }

        public void ResimYukle(string url)
        {
            foreach (var ogrenci in Ogrenciler)
            {
                ogrenci.KarsilaImage(url);
            }
        }

        public void SoruGonder(string soru, Ogrenci ogrenci)
        {
            Ogretmen.KarsilaSoru(soru, ogrenci);
        }

        public void CevapGonder(string cevap, Ogrenci ogrenci)
        {
            ogrenci.KarsilaCevap(cevap);
        }
    }

}
