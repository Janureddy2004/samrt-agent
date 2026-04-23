using System;

class Tools
{
    public string GetTime()
    {
        return DateTime.Now.ToString();
    }

    public string GetDate()
    {
        return DateTime.Today.ToShortDateString();
    }
}