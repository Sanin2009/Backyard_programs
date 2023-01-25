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
    bool isSymmetric(TreeNode* root) {
        sym=true;
        if (root->right==nullptr && root->left==nullptr) return true;
        if (root->right==nullptr && root->left!=nullptr) return false;
        if (root->right!=nullptr && root->left==nullptr) return false;
        solve(root->left,root->right);
        return sym;
    }
private:
    bool sym;
    void solve(TreeNode* left,TreeNode* right){
        if (sym==false) return;
        if (left->val!=right->val) sym=false;
        if (left->left==nullptr && right->right!=nullptr) sym=false;
        if (left->left!=nullptr && right->right==nullptr) sym=false;
        if (left->right==nullptr && right->left!=nullptr) sym=false;
        if (left->right!=nullptr && right->left==nullptr) sym=false;
        if (left->right!=nullptr && right->left!=nullptr) solve(left->right,right->left);
        if (left->left!=nullptr && right->right!=nullptr) solve(left->left,right->right);
    }
};