using SingletonPattern.Models;

Logger logger1 = Logger.GetInstance();
Logger logger2 = Logger.GetInstance();

logger1.Log("Application Started");
logger2.Log("User Logged In");

Console.WriteLine();

Console.WriteLine($"HashCode of logger1: {logger1.GetHashCode()}");
Console.WriteLine($"HashCode of logger2: {logger2.GetHashCode()}");

if (logger1 == logger2)
{
    Console.WriteLine("Both objects are the same instance.");
}
else
{
    Console.WriteLine("Different instances.");
}