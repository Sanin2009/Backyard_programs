/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        if (depth==1)
        {
            TreeNode r = new TreeNode(val,root);
            return r;
        }
        else AddDepth.Check(root,val,depth,1);
        return root;
    }
}

public static class AddDepth
{
    public static void Check(TreeNode root, int val, int depth, int currentDepth)
    {
        if (currentDepth==depth-1)
        {
            TreeNode lr = new TreeNode(val, root.left,null);
            root.left = lr;
            TreeNode rr = new TreeNode(val, null, root.right);
            root.right = rr;
        }
        else
        {
            if (root.left!=null) AddDepth.Check(root.left,val,depth,currentDepth+1);
            if (root.right!=null) AddDepth.Check(root.right,val,depth,currentDepth+1);
        }
        
    }
}