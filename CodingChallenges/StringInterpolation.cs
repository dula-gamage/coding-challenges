/*

Create a function that takes in the following arguments
• template
• map of keys and values
• placeholder prefix, e.g. “{“, denotes start of placeholder
• placeholder suffix, e.g. “}”, denotes end of placeholder

Placeholder values are provided by a map of key-value pairs, with the keys being the placeholder names.
This function should replace all placeholders in the template with the corresponding values from the map.
If a placeholder’s value is not provided, the placeholder should be replaced with “#placeHolderNameNotFound#”, 
with “placeHolderName” replaced with the name of the placeholder.

*/

using System.Text;
using System.Text.RegularExpressions;

public class StringInterpolation {
    const string PLACEHOLDER_NOT_FOUND = "NotFound#";
    public string InterpolateString(string template, Dictionary<string, string> values, string prefix, string suffix){
        string result = template;
        //Get all placeholders in template
        List<string> placeholders = new List<string>();
        foreach(Match match in Regex.Matches(template, prefix + "(.*?)" + suffix)){
            placeholders.Add(match.Groups[1].Value);
        }
        //Replace placeholders with values
        foreach(var placeholder in placeholders){
            if(values.ContainsKey(placeholder)){
                result  =result.Replace(prefix +placeholder + suffix, values[placeholder]);
            }else{
                result =result.Replace(prefix +placeholder + suffix,$"#{placeholder}"+PLACEHOLDER_NOT_FOUND);
            }
        }
        return result;
    }

    public string InterpolateString2(string template, Dictionary<string, string> values, string prefix, string suffix){

        // Construct regex pattern and precompile it for better performance
        string pattern = Regex.Escape(prefix) + "(.*?)" + Regex.Escape(suffix);
        Regex regex = new Regex(pattern, RegexOptions.Compiled);

        StringBuilder result = new StringBuilder(template);

        // Find all placeholders
        foreach (Match match in regex.Matches(template))
        {
            string placeholder = match.Groups[1].Value;
            string fullPlaceholder = match.Value;

            // Replace placeholder with the value or a default not-found string
            if (values.TryGetValue(placeholder, out string value))
            {
                result.Replace(fullPlaceholder, value);
            }
            else
            {
                result.Replace(fullPlaceholder, $"#{placeholder}{PLACEHOLDER_NOT_FOUND}");
            }
        }

        return result.ToString();
    }
}