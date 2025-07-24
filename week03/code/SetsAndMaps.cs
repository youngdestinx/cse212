using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        var seen = new HashSet<string>();
        var pairs = new HashSet<string>();

        foreach (var word in words)
        {
            var reverse = $"{word[1]}{word[0]}";

            if (seen.Contains(reverse) && word[0] != word[1])
            {
                pairs.Add($"{word}&{reverse}");
            }
            seen.Add(word);
        } 
        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    
    /// <problem>
    /// summarize the degrees (education) that people earned as reported in a file
    /// </problem>
    /// 
    /// <plan>
    /// 1. Read the file line by line.
    /// 2. Split each line into columns based on a delimiter (e.g., comma).
    /// 3. Extract the degree from the fourth column of each line.
    /// 4. Create a dictionary to store the degree count, where the key is the degree and the value is the count
    /// 5. Count the degrees. For each degree, increment the count in the dictionary. If the degree is not already
    ///    in the dictionary, add it with a count of 1.
    /// 6. Return the dictionary containing the degree counts.
    /// 7. Handle errors. Handle error that might occur while reading the file, such as file not found or invalid
    ///    file formats.
    /// </plan>

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        try
        {
            foreach (var line in File.ReadLines(filename))
            {
                var fields = line.Split(",");
                // TODO Problem 2 - ADD YOUR CODE HERE
                if (fields.Length >= 4)
                {
                    string degree = fields[3].Trim(); //.Trim removes any white space.
                    if (degrees.ContainsKey(degree))
                    {
                        degrees[degree]++; // The if block will be executed afterward and the degree count will
                                          //  will be updated i.e increased rather than creating a new entry
                    }
                    else
                    {
                        degrees[degree] = 1; // The else block will be executed initially cause the dictionary is 
                                            //  empty
                    }
                }
            }
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }

        catch (Exception ex)
        {
            Console.WriteLine("An error occured: " + ex.Message);
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    
    /// <problem>
    /// Determine whether two words are anagrams using a dictionary
    /// </problem>
    
    /// <plan>
    /// 1. Remove any spaces from both words and convert them to lowercase to ignore case sensitivity
    /// 2. Check if word length are equal. If the length of the two words are not equal, they cannot be anagrams
    /// 3. Create dictionaries for each word. Create two dictionaries to store the count of each letter in each
    ///    word.
    /// 4. Count Letter occurrences. Iterate through each word and count the occurrences of each letter in the 
    ///    corresponding dictionary.
    /// 5. Compare dictionaries. Compare the two dictionaries. If they are equal, the words are anagrams.
    /// </plan>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // Remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Check if word lengths are equal
        if (word1.Length != word2.Length)
        {
            return false;
        }

        // Create dictionaries to store letter counts
        var dict1 = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        // Count letter occurances in word1
        foreach (char letter in word1)
        {
            if (dict1.ContainsKey(letter))
            {
                dict1[letter]++;
            }
            else
            {
                dict1[letter] = 1;
            }
        }

        // Count letter occurances in word2
        foreach (char letter in word2)
        {
            if (dict2.ContainsKey(letter))
            {
                dict2[letter]++;
            }
            else
            {
                dict2[letter] = 1;
            }
        }

        // Compare dictionaries
        foreach (var pair in dict1)
        {
            if (!dict2.ContainsKey(pair.Key))
            {
                return false;
            }
            // If you put your return true here, the loop will end prematurely once it find a letter that is true
            // without looping through the entire code.
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    /// 

    /// <plan>
    /// 1. Create Custom Classes: Design custom classes to map the JSON data to C# objects.
    /// Ensure the classes have properties that match the relevant data in their JSON format.
    /// 
    /// 2. Fetch the Data: Use the HttpClient class to send a GET request to the USGS API endpoint.
    /// Specify the correct parameters to retrieve data for the current day.
    /// 
    /// 3. Deserialize JSON Data: Use a JSON deserialization library to convert the JSON data to C# objects.
    /// Map the JSON data to the custom classes created earlier.
    /// 
    /// 4. Process Earthquake Data: Extract the earthquake locations and magnitude from the deserialized data.
    /// Format the data into an array of strings with the required format.
    /// 
    /// 5. Handle Errors: Implement try-catch blocks to handle any exceptions that may occur during the data
    /// retrieval or processing
    /// 
    /// 6. Return the Earthquake Summaries: Return the array of formatted strings containing the earthquake 
    /// locations and magnitudes.
    /// 
    /// </plan>
    
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        var earthquakeDescription = featureCollection._feature.Select(f => $"{f._properties._place}- Mag: {f._properties._mag}");
        return earthquakeDescription.ToArray();
    }
}