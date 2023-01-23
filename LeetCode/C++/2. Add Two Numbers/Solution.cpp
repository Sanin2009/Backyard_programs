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
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
        ListNode* resultList = new ListNode();
        ListNode* tempNode = resultList;
        int memoryBit=0;
        int result = l1->val+l2->val;
        while (result!=0 || l1->next!=nullptr || l2->next!=nullptr )
        {
            tempNode->val = result%10;
            if (result>9) memoryBit=1;
            result=0;
            if (l1->next!=nullptr)
            {
                l1=l1->next;
                result+=l1->val;
            }
            if (l2->next!=nullptr)
            {
                l2=l2->next;
                result+=l2->val;
            }
            result+=memoryBit;
            if (result!=0 || l1->next!=nullptr || l2->next!=nullptr) 
            {
                tempNode->next = new ListNode();
                tempNode=tempNode->next;
            }
            memoryBit=0;
        }
        return resultList; 
    }
};