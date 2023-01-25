class Solution {
public:
    vector<int> partitionLabels(string s) {
        vector<int> res;
        int left=0;
        int leftPos=0;
        int mostRight = s.length()-1;
        while(true)
        {
            int right = s.length()-1;
            if (s[left]==s[s.length()-1])
            {
                res.push_back(s.length()-leftPos);
                return res;
            }
            while (s[left]!=s[right])
            {
                right--;
            }
            if (right>mostRight || mostRight==(s.length()-1)) mostRight=right;
            if (left==mostRight)
            {
                res.push_back(mostRight+1-leftPos);
                left++;
                leftPos=left;
                mostRight=s.length()-1;
            }
            else 
            {
                left++;
            }
        }
    }
};