public class Solution {
    private List<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) 
    {
        var emptyList = new List<int>();
        if (root==null) return result;
        Solve(emptyList, 0, root, targetSum);
        return result;
    }
    private void Solve(List<int> currentList, int currentSum, TreeNode node, int targetSum)
    {
        currentSum+=node.val;
        currentList.Add(node.val);
        if (node.left==null && node.right==null)
        {
            if (currentSum==targetSum) result.Add(currentList);
            return;
        }
        if (node.left!=null) 
        {
            var newList = new List<int>(currentList);
            Solve(newList,currentSum,node.left,targetSum);
        }
        if (node.right!=null) 
        {
            var newList = new List<int>(currentList);
            Solve(newList,currentSum,node.right,targetSum);
        }
    }
}