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
    bool isSameTree(TreeNode* p, TreeNode* q) {
        same=true;
        if (p==NULL && q==NULL) return true;
        if ((p==NULL && q!=NULL) || (p!=NULL && q==NULL)) return false;
        solve(p,q);
        return same;
    }
private:
    bool same;
    void solve(TreeNode* p, TreeNode* q) {
            if (p->val!=q->val) same=false;
            if (same==false) return;
            if ((p->right==nullptr && q->right!=nullptr) || (p->right!=nullptr && q->right==nullptr)) same=false;
            if ((p->left==nullptr && q->left!=nullptr) || (p->left!=nullptr && q->left==nullptr)) same=false; 
            if (p->left!=nullptr && q->left!=nullptr) solve(p->left,q->left);
            if (p->right!=nullptr && q->right!=nullptr) solve(p->right,q->right);
    }
};