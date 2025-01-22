using System;
using Utilities;

class Program
{
    static void Main()
    {
        // Verificación del balanceo de paréntesis.
        Console.WriteLine("=== Verificación de Fórmula Balanceada ===");
        string expression = "{7+(8*5)-[(9-7)+(4+1)]}";
        bool isBalanced = BalanceChecker.IsBalanced(expression);
        Console.WriteLine($"La fórmula \"{expression}\" está balanceada: {isBalanced}");

        Console.WriteLine("\n=== Resolución de las Torres de Hanoi ===");
        // Resolución del problema de las Torres de Hanoi.
        int numDisks = 3;

        Tower source = new Tower("Origen");
        Tower auxiliary = new Tower("Auxiliar");
        Tower destination = new Tower("Destino");

        for (int i = numDisks; i >= 1; i--)
        {
            source.Disks.Push(i);
        }

        HanoiSolver.Solve(numDisks, source, auxiliary, destination);
    }
}
