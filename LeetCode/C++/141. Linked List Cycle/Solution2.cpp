/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */

class Solution {
public:
    bool hasCycle(ListNode *head) {
        if (head==NULL) return false;
        if (head->next==NULL) return false;
        return Solve(head, head->next);
    }
    bool Solve (ListNode *root, ListNode *rootroot) {
        if (rootroot==root) return true;
        if (rootroot->next!=NULL && rootroot->next->next!=NULL) return Solve(root->next,rootroot->next->next);
        else return false;
    }
};