using System;

public delegate void Action();

namespace DelegatesWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Radio Nrj, Fun;
            posteRadio poste1, poste2, poste3;

            Nrj = new Radio("nrj", "musique nrj");
            Fun = new Radio("fun", "musique fun");

            poste1 = new posteRadio();
            poste2 = new posteRadio();
            poste3 = new posteRadio();

            poste1.reglerStation(Nrj);
            poste2.reglerStation(Nrj);
            poste3.reglerStation(Fun);

            Nrj.diffuserMusique();
            Fun.diffuserMusique();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;

            poste1.reglerStation(Fun);
            poste2.reglerStation(Nrj);
            poste3.reglerStation(Fun);

            Nrj.diffuserMusique();
            Fun.diffuserMusique();

            Console.Read();
        }
    }

    public class Radio
    {
        public string Name { get; }
        public string Music { get; }

        public event Action? OnMusic;

        public Radio(string name, string music)
        {
            Name = name;
            Music = music;
        }

        public void diffuserMusique()
        {
            Console.WriteLine($"📻 {Name} is playing: {Music}");
            OnMusic?.Invoke();
        }
    }

    public class posteRadio
    {
        public void reglerStation(Radio station)
        {
            station.OnMusic += () => Console.WriteLine($"🎶 Poste received: {station.Music}");
        }
    }
}

