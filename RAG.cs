using System.Collections.Generic;

class RAG
{
    private Dictionary<string, string> knowledge = new()
    {
        { "devops", "DevOps is CI/CD, automation, pipelines." },
        { "maf", "Microsoft Agent Framework is used for tool orchestration." }
    };

    public string Search(string input)
    {
        input = input.ToLower();

        foreach (var item in knowledge)
        {
            if (input.Contains(item.Key))
                return item.Value;
        }

        return null;
    }
}