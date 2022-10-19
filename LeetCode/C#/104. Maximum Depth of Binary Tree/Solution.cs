public class Solution 
{
    private int md = 0;
    public int MaxDepth(TreeNode root)
    {
        if (root==null) return md;
        Solve(md+1,root);
        return md;
    }
    private void Solve (int depth, TreeNode root)
    {
        if (depth>md) md=depth;
        if (root.left!=null) Solve(depth+1,root.left);
        if (root.right!=null) Solve(depth+1, root.right);
    }
}