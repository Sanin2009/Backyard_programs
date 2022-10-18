public class Solution 
{
    private bool same;
    public bool IsSameTree(TreeNode p, TreeNode q) 
    {
        same=true;
        if (p==null && q==null) return true;
        if ((p==null && q!=null) || (p!=null && q==null)) return false;
        Solve(p,q);
        return same;
    }
    public void Solve(TreeNode p, TreeNode q) 
    {
        if (p.val!=q.val) same=false;
        if (p.left!=null && q.left!=null) Solve(p.left,q.left);
        if (p.right!=null && q.right!=null) Solve(p.right,q.right);
        if ((p.right==null && q.right!=null) || (p.right!=null && q.right==null)) same=false;
        if ((p.left==null && q.left!=null) || (p.left!=null && q.left==null)) same=false;
    }
}