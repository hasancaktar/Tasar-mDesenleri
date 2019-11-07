using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ObjectPoolDeseni
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory fa = new Factory();
            Ogrenci og1 = fa.GetirOgrenci();
            Console.WriteLine("Obje bir");
            Ogrenci og2 = fa.GetirOgrenci();
            Console.WriteLine("Obje iki");
            Ogrenci og3 = fa.GetirOgrenci();
            Console.WriteLine("Obje üç");
            Console.Read();
        }
    }

    class Factory
    {

        private static int _PoolMaxSize = 3;
        private static readonly Queue objPool = new
           Queue(_PoolMaxSize);
        public Ogrenci GetirOgrenci()
        {
            Ogrenci oStudent;
    
      
            if (Ogrenci.ObjectCounter >= _PoolMaxSize &&
               objPool.Count > 0)
            {
    
                oStudent = HavuzdanAl();
            }
            else
            {
                oStudent = GetNewStudent();
            }
            return oStudent;
        }
        private Ogrenci GetNewStudent()
        {
 
            Ogrenci oStu = new Ogrenci();
            objPool.Enqueue(oStu);
            return oStu;
        }
        protected Ogrenci HavuzdanAl()
        {
            Ogrenci oStu;

            if (objPool.Count > 0)
            {
                oStu = (Ogrenci)objPool.Dequeue();
                Ogrenci.ObjectCounter--;
            }
            else
            {

                oStu = new Ogrenci();
            }
            return oStu;
        }
    }
   public  class Ogrenci
    {
        public static int ObjectCounter = 0;
        public Ogrenci()
        {
            ++ObjectCounter;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int RollNumber { get; set; }
        public string Class { get; set; }
    }
}