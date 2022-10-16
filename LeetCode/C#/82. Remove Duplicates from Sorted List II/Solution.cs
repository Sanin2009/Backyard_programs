public class Solution 
{
    public ListNode DeleteDuplicates(ListNode head) 
    {
        ListNode newHead = new ListNode();
        newHead = FindNewHead(head);
        if (newHead==null || newHead.next==null) return newHead;
        Solve(newHead,newHead.next,head.val);
        return newHead;
    }
    private ListNode FindNewHead(ListNode head)
    {
        if (head==null || head.next==null) return head;
        if (head.val!=head.next.val) return head;
        int prevValue = head.val;
        while (head.val==head.next.val || head.val==prevValue)
        {
            prevValue=head.val;
            head = head.next;
            if (head.next==null)
            {
                if (head.val==prevValue) return null;
                else return head;
            }
        }
        return head;
    }
    public void Solve (ListNode currentHead, ListNode current, int value)
    {
        while (current.next!=null)
        {
            if (current.val!=current.next.val)
            {
                currentHead=current;
                current=currentHead.next;
            }
            else if (current.val==current.next.val)
            {
                while (current.val==current.next.val)
                {
                    current=current.next;
                    if (current.next==null) break;
                }
                currentHead.next=FindNewHead(current.next);
            }
        }
        return;
    }
}