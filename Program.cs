namespace HelloWorld;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"Application Version: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}");
        Console.WriteLine($"Runtime: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
        
        if (args.Length > 0)
        {
            Console.WriteLine($"Arguments: {string.Join(" ", args)}");
        }
    }
}
