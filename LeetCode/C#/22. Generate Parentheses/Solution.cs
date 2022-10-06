public class Solution {
    public  IList<string> result = new List<string>(); 
    public IList<string> GenerateParenthesis(int n) 
    {
        RunRec(n,0,"");
        return result;
    }
    public void RunRec (int open, int close, string res)
    {
        if (open>0) RunRec (open-1,close+1,res +'(');
        if (close>0) RunRec (open,close-1, res +')');
        if (open==0 && close ==0)
        {
            result.Add(res);
        }
        return;
    }
}