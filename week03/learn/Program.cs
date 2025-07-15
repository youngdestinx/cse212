using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n======================\nDuplicate Counter\n======================");
        DuplicateCounter.Run();

        Console.WriteLine("\n======================\nTranslator\n======================");
        Translator.Run();
    }
}

/*********************How to create an header when printing out to the console**********************************/
/*  1.  Use the \n to create a new line. Use three of them to create three new lines.
    2.  Use two contionus "=" on each side of the Word or header of your choice. */