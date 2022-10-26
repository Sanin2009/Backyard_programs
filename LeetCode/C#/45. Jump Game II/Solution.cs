public class Solution 
{
    public int result;
    public int Jump(int[] nums) 
    {
        if (nums.Count()==1) return 0;
        Solve(0,0,nums);
        return result;
    }
    private void Solve(int p, int steps, in int[] n)
    {
        int max=-1;
        int temp_p=0;
        for (int i=1; i<=n[p]; i++)
        {
            if (i+p==n.Count()-1) 
            {
                result=steps+1;
                return;
            }
            if ((i+n[i+p])>max)
            {
                temp_p=i+p;
                max=i+n[i+p];
            }
        }
        Solve(temp_p,steps+1,n);
    }
}