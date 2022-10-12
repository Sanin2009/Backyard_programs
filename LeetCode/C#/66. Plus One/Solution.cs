public class Solution 
{
    public int[] PlusOne(int[] nums) 
    {
        if (nums.Sum()==nums.Length*9)
        {
            int[] res = new int[nums.Length+1];
            res[0]=1;
            return res;
        }
        for (int i = nums.Length-1; i>=0; i--)
        {
            if (nums[i]==9) nums[i]=0;
            else
            {
                nums[i]++;
                return nums;
            }

        }
        return nums;
    }
}