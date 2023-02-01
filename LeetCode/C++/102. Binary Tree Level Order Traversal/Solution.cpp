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
    vector<vector<int>> levelOrder(TreeNode* root) {
        vector<vector<int>> result;
        vector<int> temp;
        queue<TreeNode*> firstQ;
        queue<TreeNode*> secondQ;
        firstQ.push(root);
        while (!firstQ.empty() || !secondQ.empty())
        {
            if (firstQ.empty())
            {
                while (!secondQ.empty())
                {
                    firstQ.push(secondQ.front());
                    secondQ.pop();
                }
            }
            while (!firstQ.empty())
            {
                if (firstQ.front()!=nullptr)
                {
                    temp.push_back(firstQ.front()->val);
                    secondQ.push(firstQ.front()->left);
                    secondQ.push(firstQ.front()->right);
                }
                firstQ.pop();
            }
            if (!temp.empty()) result.push_back(temp);
            temp.clear();
        }
        return result;
    }
};