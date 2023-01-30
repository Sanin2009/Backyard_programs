/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
class Solution {
public:
    ListNode* mergeTwoLists(ListNode* list1, ListNode* list2) {
        if (list1==NULL) return list2;
        if (list2==NULL) return list1;
        ListNode* left = list1;
        ListNode* right = list2;
        bool leftSmall=true;
        if (left->val>right->val)
        {
            left=list2;
            right=list1;
            leftSmall=false;
        }
        while (left!=nullptr)
        {
            if (right==nullptr) return leftSmall? list1 : list2;
            if (left->next==nullptr)
            {
                left->next=right;
                return leftSmall? list1 : list2;
            }
            else if (left->next->val>right->val)
            {
                auto temp=right->next;
                right->next=left->next;
                left->next=right;
                left=left->next;
                right=temp;
            }
            else
            {
                left=left->next;
            }
        }
        return leftSmall? list1 : list2;
    }
};