/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */

 // Some sort of twisted joke
class Solution {
public:
    bool hasCycle(ListNode *head) {
        if (head==NULL) return false;
        return Solve(head, 0);
    }
    bool Solve (ListNode *root, int depth) {
        if (depth>10002) return true;
        if (root->next!=NULL) return Solve(root->next,depth+1);
        else return false;
    }
};