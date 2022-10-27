public class Solution 
{
    public int SingleNumber(int[] nums) 
    {
        int res=nums[0];
        if (nums.Length==1) return res;
        for (int i=1; i<nums.Length; i++) res=res^nums[i];
        return res;
    }
}