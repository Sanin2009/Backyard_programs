public class Solution 
{
    public  IList<IList<int>> result = new List<IList<int>>(); 
    public IList<IList<int>> Permute(int[] nums) 
    {
        List<int> emptyList = new List<int>();
        List<int> numList = new List<int>();
        foreach (int num in nums) numList.Add(num);
        Solve(numList, emptyList);
        return result;   
    }
    public void Solve(List<int> nums, List<int> res)
    {
        if (!nums.Any())
        {
            result.Add(res);
            return;
        }
        else foreach (int num in nums)
        {
            var tempList1 = new List<int>(nums);
            var tempList2 = new List<int>(res);
            tempList2.Add(num);
            tempList1.Remove(num);
            Solve(tempList1, tempList2);
        }
    }
}