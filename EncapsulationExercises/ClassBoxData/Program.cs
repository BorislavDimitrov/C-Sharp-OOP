using System;

namespace ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            double surfaceArea = box.SurfaceArea();
            double lateralSurfaceArea = box.LateralSurfaceArea();
            double volume = box.Volume();

            Console.WriteLine($"Surface Area - {surfaceArea:F2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}
