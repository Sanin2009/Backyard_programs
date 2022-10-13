public class Solution {
    public IList<IList<int>> result = new List<IList<int>>(); 
    public IList<IList<int>> Subsets(int[] nums) {
        List<int> emptyList = new List<int>();
        List<int> numList = new List<int>();
        foreach (int num in nums) numList.Add(num);
        Solve(numList, emptyList, -11);
        return result;   
    }
    public void Solve(List<int> nums, List<int> res, int minValue)
    {
        result.Add(res);
        foreach(int value in nums)
        {
            if (value>minValue)
            {
                var tempList1 = new List<int>(nums);
                var tempList2 = new List<int>(res);
                tempList2.Add(value);
                tempList1.Remove(value);
                Solve(tempList1, tempList2, value);
            }
        }
    }
}