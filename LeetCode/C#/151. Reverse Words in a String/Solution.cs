public class Solution 
{
    public string ReverseWords(string s) 
    {
        string result="";
        while (s.Contains("  ")) s = s.Replace("  ", " "); 
        string[] r = s.Split(' ');
        for (int i=r.Count()-1; i>=0; i--)
        {
            result=result + r[i] + " ";
        }
        return result.Trim();
    }
}