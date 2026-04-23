using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        var agent = new Agent();

        while (true)
        {
            Console.Write("You: ");
            var input = Console.ReadLine();

            var response = await agent.Run(input);

            Console.WriteLine("Agent: " + response);
        }
    }
}