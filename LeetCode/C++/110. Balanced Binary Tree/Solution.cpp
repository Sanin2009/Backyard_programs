/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */

class Solution {
public:
    bool isBalanced(TreeNode* root) {
        return (solve(root)!=-1);
    }
private:
    int solve(TreeNode* node)
    {
        if (node==nullptr) return 0;
        if (node->left==nullptr && node->right==nullptr) return 1;
        int l = (solve(node->left));
        if (l==-1) return -1;
        int r = (solve(node->right));
        if (r==-1) return -1;
        return (abs(r-l)>1 ? -1 : max(l,r)+1);
    }
};