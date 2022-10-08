public class Solution {
    public  IList<IList<int>> result = new List<IList<int>>(); 
    public IList<IList<int>> CombinationSum(in int[] candidates, in int target) 
    {
        List<int> emptyList = new List<int>();
        Solve(candidates, emptyList, 0, target, 0);
        return result;
    }
    public void Solve (int[] candidates, List<int> list, int sum, int targetsum, int lastAdd)
    {
        foreach (int candidate in candidates)
        {
            if ((sum+candidate)==targetsum && (candidate>=lastAdd))
            {
                var tempList = new List<int>(list);
                tempList.Add(candidate);
                result.Add(tempList);
            }
            if ((sum+candidate)<targetsum && (candidate>=lastAdd))
            {
                var tempList = new List<int>(list);
                tempList.Add(candidate);
                Solve(candidates, tempList, sum+candidate, targetsum, candidate);
            }
        }
    }
}