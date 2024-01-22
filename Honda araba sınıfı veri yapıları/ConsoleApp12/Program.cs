using System;
using System.Collections.Generic;

class HondaCar
{
    public string Model { get; set; }
    public int Year { get; set; }
    public List<HondaCar> SubModels { get; set; } = new List<HondaCar>();

    public HondaCar(string model, int year)
    {
        Model = model;
        Year = year;
    }

    public void AddSubModel(HondaCar subModel)
    {
        SubModels.Add(subModel);
    }

    public override string ToString()
    {
        return $"{Year} {Model} Honda";
    }
}

class HondaCarManager
{
    private List<HondaCar> hondaCars = new List<HondaCar>();
    private LinkedList<HondaCar> linkedList = new LinkedList<HondaCar>();
    private Dictionary<string, HondaCar> hashTable = new Dictionary<string, HondaCar>();

    public void AddCars()
    {
        hondaCars.AddRange(new HondaCar[]
        {
            new HondaCar("Civic", 2022),
            new HondaCar("Accord", 2021),
            new HondaCar("CR-V", 2023),
            new HondaCar("Pilot", 2020)
        });

        linkedList = new LinkedList<HondaCar>(hondaCars);

        foreach (var car in hondaCars)
        {
            hashTable.Add(car.Model, car);
        }
    }

    public void DisplayCars()
    {
        Console.WriteLine("\n----- Honda Araba Modelleri -----");
        Console.WriteLine("Dizi ile Honda Araba Modelleri:");
        DisplayCarList(hondaCars);

        Console.WriteLine("\nBağlı Liste ile Honda Araba Modelleri:");
        DisplayCarList(linkedList);

        Console.WriteLine("\nHash Table ile Honda Araba Modelleri:");
        DisplayCarList(hashTable.Values);
    }

    private void DisplayCarList(IEnumerable<HondaCar> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    public void AddCar(string model, int year)
    {
        HondaCar newCar = new HondaCar(model, year);
        hondaCars.Add(newCar);
        linkedList.AddLast(newCar);
        hashTable.Add(model, newCar);
        Console.WriteLine($"\n{newCar} başarıyla eklendi.");
    }

    public void TraverseTree(HondaCar node, int depth)
    {
        Console.WriteLine(new string('-', depth) + node);

        foreach (var subModel in node.SubModels)
        {
            TraverseTree(subModel, depth + 1);
        }
    }
}

class Program
{
    static void Main()
    {
        HondaCarManager manager = new HondaCarManager();
        manager.AddCars();

        while (true)
        {
            Console.WriteLine("\n----- Honda Araba Uygulaması -----");
            Console.WriteLine("1. Honda Araba Listesini Görüntüle");
            Console.WriteLine("2. Honda Araba Ekle");
            Console.WriteLine("3. Çıkış");
            Console.Write("Lütfen bir seçenek girin (1-3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.DisplayCars();
                    break;

                case "2":
                    Console.Write("Yeni Honda aracının modelini girin: ");
                    string model = Console.ReadLine();

                    Console.Write("Yeni Honda aracının yılını girin: ");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        manager.AddCar(model, year);
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz yıl formatı. Aracın eklenmesi başarısız.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Uygulamadan çıkılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
