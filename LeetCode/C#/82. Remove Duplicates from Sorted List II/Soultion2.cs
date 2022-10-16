public class Solution 
{
    public ListNode DeleteDuplicates(ListNode head) 
    {
        List<int> values = new List<int>();
        List<int> valuesToDelete = new List<int>();
        ListNode temp = new ListNode();
        temp=head;
        while (temp!=null)
        {
            values.Add(temp.val);
            temp=temp.next;
        }
        if (values.Count==0) return null;
        for (int i=0; i<values.Count-1; i++)
        {
            if (values[i]==values[i+1]) valuesToDelete.Add(values[i]);
        }
        foreach (int v in valuesToDelete) while(values.Remove(v));
        if (values.Count==0) return null;
        temp=head;
        for (int i=0; i<values.Count; i++)
        {
            temp.val=values[i];
            if (i==values.Count-1) temp.next=null;
            else temp=temp.next;
        }
        //temp=null;
        return head;
    }
}