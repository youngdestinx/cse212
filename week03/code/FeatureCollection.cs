public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Feature[] _feature {get; set;}
}

   
public class Feature
{
    public Properties _properties {get; set;}
}

public class Properties
{
    public double _mag {get; set;}
    public string _place {get; set;}
}
