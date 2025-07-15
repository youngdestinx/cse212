public class TranslatorSolution
{
    /// <Description>
    /// Implement the Addword and Translate functions in the translator class using a dictionary.
    /// 
    /// The AddWord function should allow users to add word translations (e.g. english to german)
    /// 
    /// The Translate function should return the translation of a word, 
    /// if the word is not available then "???" should be returned instead.
    /// 
    /// You will need to call AddWord multiple times to build a translation dictionary for testing.
    /// You should assume there is only one translation for every word(and vise versa).
    /// </Description>
    
    public static void Run()
    {
        /// Create an instance of the TranslatorSolution class.
        var englishToGerman = new TranslatorSolution();
        /// Call the Addword function on the class object to convert English to German
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");
        /// print out the German version of the English words using the Translate function
        Console.WriteLine(englishToGerman.Translate("Car")); // Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // ???
    }

    /// Create a private member dictionary attribute named _words with string as it keys and values
    private Dictionary<string, string> _words = new();

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
        /// Add key-value pair to the dictionary using the syntax: dictionary[key] = value
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        /// Declare the variable newWord to be returned when this method is called as the translated word.
        string newWord = "???";

        if (_words.ContainsKey(fromWord))
        /// Use the if statement to update the newWord variable only if the condition is true, else the variable
        /// remain the same.
        {
            /// Get the value of a specific key using the syntax: dictionary[key] stored in a variable
            newWord = _words[fromWord];
        }
        /// Return newWord which can be either of two value, a value if the condition is not met and the value
        /// if the condition is met.
        return newWord;
    }
}

/*************************<What-is-a-Map?>*****************************************************************/
/// <Explanations>
/// A map is a data structure that stores key-value pair data. The key is uniqued while the value does not have to
/// be unique. The map is similar to a set because the keys are stored as a set.They are hashed and an equation
/// is used to determine the index of the key in a map using the formular: index = hash(key) % mapSize.
/// 
/// This is the unique different between a map and a dictionary. It keys are set, so therefore map can be used to
/// easily find the membership of a value with O(1) performance.
/// 
/// In C#, maps are refer to as dictionary and when declared, you must declare the data type of the key and value
/// var dictionary = new Dictionary<string, double>(); or
/// var dictionary = new Dictionary<string, double>() {{key1: 1.5}, {key2: 2.5}};
/// 
/// .......................Objects are Maps...............................................................
/// Whenever you create a class in any programming language, you are creating a map. Each member variable or
/// property on the class can be considered a key, with the value being stored in that variable. The look and
/// access time is ofcourse O(1) performance because the compiler knows the order and type of the data and can
/// jump to that part of the memory without caring how much additional data is needed.
/// 
/// .......................Complex Map Data................................................................
/// JSON is a complex map data it is just a map of map. Overtime, I will get use to it and work with it.
/// </Explanation>