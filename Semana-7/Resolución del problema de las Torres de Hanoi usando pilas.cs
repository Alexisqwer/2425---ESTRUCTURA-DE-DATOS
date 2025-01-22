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
        /// <summary>
        /// Resuelve el problema de las Torres de Hanoi de forma recursiva.
        /// </summary>
        /// <param name="n">Número de discos.</param>
        /// <param name="source">Torre de origen.</param>
        /// <param name="auxiliary">Torre auxiliar.</param>
        /// <param name="destination">Torre de destino.</param>
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
