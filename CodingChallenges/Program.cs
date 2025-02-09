public class Program {
    public static void Main(string[] args) {
        StringInterpolation si = new StringInterpolation();
        Dictionary<string, string> values = new Dictionary<string, string>();
        values.Add("firstName1", "John");
        values.Add("hobby", "Soccer");

        string template = "Hello, my name is {firstName} and I like to play {hobby}";
        string result = si.InterpolateString2(template, values, "{", "}");
        Console.WriteLine(result);
    }
}