public class Solution 
{
    public int SingleNumber(int[] nums) 
    {
        var n = new int[33];
        int res=0;
        if (nums.Length==1) return nums[0];
        for (int i=0; i<nums.Length; i++)
        {
            int t=nums[i];
            if (nums[i]<0)
            {
                t*=-1;
                n[32]++;
            }
            for (int j=0; j<32; j++)
            {
                n[j]+=t%2;
                t/=2;
            }
        }
        int temp=1;
        for (int j=0; j<32; j++)
        {
            res+=(n[j]%3)*temp;
            temp*=2;
        }
        if ((n[32]%3)==1) res*=-1;
        return res;
    }
}