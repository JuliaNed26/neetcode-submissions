public class Solution {

    public string Encode(IList<string> strs) {
        var strBuilder = new StringBuilder();
        foreach(var str in strs)
        {
            strBuilder.Append($"{str.Length}#").Append(str);
        }
        return strBuilder.ToString();
    }

    public List<string> Decode(string s) {
        List<string> result = new List<string>(s.Length);
        int i = 0;
        while(i < s.Length)
        {
            int delimiterIndex = s.IndexOf("#",i);
            int length = Int32.Parse(s[i..delimiterIndex]);
            i = delimiterIndex + 1;
            result.Add(s.Substring(i,length));
            i += length;
        }
        return result;
   }
}
