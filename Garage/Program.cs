namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHandler handler = new GarageHandler();
            IUI ui = new ConsoleUI(handler);
            ui.HandleUserInput();
        }
    }
}
