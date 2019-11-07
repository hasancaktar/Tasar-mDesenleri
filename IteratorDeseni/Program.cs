using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace IteratorDeseni
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonelAggregate aggregate = new PersonelAggregate();
            aggregate.Add(new Personel { Id = 1, Adi = "Hasan", SoyAdi = "Sancaktar" });
            aggregate.Add(new Personel { Id = 2, Adi = "Ali", SoyAdi = "Kap" });
            aggregate.Add(new Personel { Id = 3, Adi = "Müco", SoyAdi = "Murat" });
            aggregate.Add(new Personel { Id = 4, Adi = "Bunyo", SoyAdi = "Gürmüc" });
            aggregate.Add(new Personel { Id = 5, Adi = "Ercan", SoyAdi = "Sakal" });

            IIterator iterasyon = aggregate.CreateIterator();
            while (iterasyon.HasItem())
            {
                Console.WriteLine($"ID : {iterasyon.CurrentItem().Id}\nAdı : {iterasyon.CurrentItem().Adi}\nSoyadı : {iterasyon.CurrentItem().SoyAdi}\n*****");
                iterasyon.NextItem();
            }

            Console.Read();
        }
    }
    public  class Personel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
    }
    interface IIterator
    {
      
        bool HasItem();
      
        Personel NextItem();
       
        Personel CurrentItem();
    }
    interface IAggregate
    {
        IIterator CreateIterator();
    }
    class PersonelAggregate : IAggregate
    {
        List<Personel> PersonelListesi = new List<Personel>();
        public void Add(Personel Model) => PersonelListesi.Add(Model);
        public Personel GetItem(int index) => PersonelListesi[index];
        public int Count { get => PersonelListesi.Count; }
        public IIterator CreateIterator() => new PersonelIterator(this);
    }
    class PersonelIterator : IIterator
    {
        PersonelAggregate aggregate;
        int currentindex;
        public PersonelIterator(PersonelAggregate aggregate) => this.aggregate = aggregate;
        public Personel CurrentItem() => aggregate.GetItem(currentindex);
        public bool HasItem()
        {
            if (currentindex < aggregate.Count)
                return true;
            return false;
        }
        public Personel NextItem()
        {
            if (HasItem())
                return aggregate.GetItem(currentindex++);
            return new Personel();
        }
    }

}