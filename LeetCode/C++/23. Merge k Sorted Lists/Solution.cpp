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
    ListNode* mergeKLists(vector<ListNode*>& lists) {
        vector<int> v(20001,0);
        int count=0;
        for (auto l : lists)
        {
            while (l!=nullptr)
            {
                v[l->val+10000]++;
                l=l->next;
                count++;
            }
        }
        if (count==0) return nullptr;
        ListNode* result = new ListNode();
        ListNode* t = result;
        for (int i=0; i<20001; i++)
        {
            while (v[i]>0)
            {
                t->val=i-10000;
                v[i]--;
                t->next= new ListNode();
                t=t->next;
            }
        }
        t=result;
        while (t!=nullptr && t->next!=nullptr)
        {
            if (t->next->next==nullptr)
            {
                t->next=nullptr;
                break;
            }
            else t=t->next;
        }
        return result;
    }
};