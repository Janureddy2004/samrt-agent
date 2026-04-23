using System.Threading.Tasks;

class Agent
{
    private LLM llm = new LLM();
    private RAG rag = new RAG();
    private Tools tools = new Tools();
    private Planner planner = new Planner();

    public async Task<string> Run(string input)
    {
        var decision = planner.Decide(input);

        System.Console.WriteLine($"[Planner]: {decision}");

        if (decision == "tool_time")
            return tools.GetTime();

        if (decision == "tool_date")
            return tools.GetDate();

        if (decision == "rag")
            return rag.Search(input);

        var prompt = $@"
You are a helpful assistant.
fo
Examples:
Q: What is DevOps?
A: DevOps is CI/CD automation.

Q: {input}
A:
";

        return await llm.Ask(prompt);
    }
}
