using System;
using System.Collections.Generic;

public class Logger
{
    private static Logger instance = new Logger();


    public List<string> logs = new List<string>();


    private Logger()
    {
    }

    public static Logger Instance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    //sicc
}
