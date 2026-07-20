public class Solution {

    public string Encode(IList<string> strs) {
        var strBuilder = new StringBuilder();
        foreach(var str in strs)
        {
            strBuilder.Append($"{str.Length}#");
            strBuilder.Append(str);
        }
        return strBuilder.ToString();
    }

    public List<string> Decode(string s) {
        List<string> result = new List<string>(s.Length);
        int i = 0;
        while(i < s.Length)
        {
            StringBuilder lengthStr = new ();
            while(s[i] != '#')
            {
                lengthStr.Append(s[i]);
                i++;
            }
            int length = Int32.Parse(lengthStr.ToString());
            result.Add(s.Substring(i+1,length));
            i = i + length + 1;
        }
        return result;
   }
}
