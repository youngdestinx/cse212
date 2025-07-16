public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");
        Console.WriteLine(englishToGerman.Translate("Car")); // Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // ???
    }

    private Dictionary<string, string> _words = new();
    /***********************************Steps For Writing the Codes******************************************/
    /// <steps>
    /// 1. Create a dictionary of strings for the key and value pair
    /// 2. For the AddWord function, simply add a key-value pair with the "from_word" as the key and
    ///    the "to_word" as the value.
    /// 3. For the Translate function, use the get value method for dictionary to get the value (to_word) from
    ///    the key (from_word)
    /// </steps>
    /******************************************************************************************************/

    /// <summary>
    /// Add the translation from 'from_word' to 'to_word'
    /// For example, in a english to german dictionary:
    /// 
    /// my_translator.AddWord("book","buch")
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    /// <returns>fixed array of divisors</returns>
    public void AddWord(string fromWord, string toWord)
    {
        // ADD YOUR CODE HERE
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        // ADD YOUR CODE HERE
        var Word = "???";
        if (_words.ContainsKey(fromWord))
        {
            Word = _words[fromWord];
        }
        return Word;
    }
}

/********************An Instance of a Class in a Class?*******************************************************/
/*  Yes, you are correct, this class contain a method, which is an instance of another method. It can be done. */


/************************************************Conditional Statement****************************************/
/// <Description>
/// One of the usefullness of a conditional statement such as an if statement is to update a value or append 
/// value to a variable. 
/// 
/// You can declare a variable outside the scope of the conditional statement and use the conditional statement to
/// update it value or append to it, just like what a function will do.
/// 
/// In this project, a conditional statement was used to achieve the Translate function responsibilty.
/// </Description>