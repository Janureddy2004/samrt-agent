class Planner
{
    public string Decide(string input)
    {
        input = input.ToLower();

        if (input.Contains("time"))
            return "tool_time";

        if (input.Contains("date"))
            return "tool_date";

        if (input.Contains("devops") || input.Contains("maf"))
            return "rag";

        return "llm";
    }
}