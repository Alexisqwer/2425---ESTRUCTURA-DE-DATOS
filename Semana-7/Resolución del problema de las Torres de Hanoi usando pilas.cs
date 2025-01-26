using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Tower
    {
        public Stack<int> Disks { get; private set; }
        public string Name { get; private set; }

        public Tower(string name)
        {
            Disks = new Stack<int>();
            Name = name;
        }

        public void MoveDiskTo(Tower destination)
        {
            int disk = Disks.Pop();
            destination.Disks.Push(disk);
            Console.WriteLine($"Mover disco {disk} de {Name} a {destination.Name}");
        }
    }

    public static class HanoiSolver
    {
        /// Resuelve el problema de las Torres de Hanoi de forma recursiva.
        /// "n"Número de discos.
        /// "source"Torre de origen.
        /// "auxiliary"Torre auxiliar.
        /// "destination">Torre de destino.
        public static void Solve(int n, Tower source, Tower auxiliary, Tower destination)
        {
            if (n == 1)
            {
                source.MoveDiskTo(destination);
                return;
            }

            Solve(n - 1, source, destination, auxiliary);
            source.MoveDiskTo(destination);
            Solve(n - 1, auxiliary, source, destination);
        }
    }
}
