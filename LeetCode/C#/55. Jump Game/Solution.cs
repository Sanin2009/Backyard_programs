public class Solution 
{
    public bool CanJump(in int[] nums) 
    {
        int farTrue = 0;
        int l = nums.Length-1;
        if (l==0) return true;
        for (int i=0; i<l; i++)
        {
            if (farTrue>=i)
            {
                if (i+nums[i]>farTrue) farTrue=i+nums[i];
                if (farTrue>=l) return true;
            }
        }
        return false;
        
    }
}