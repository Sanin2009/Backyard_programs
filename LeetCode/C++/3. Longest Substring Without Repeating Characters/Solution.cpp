class Solution {
public:
    int lengthOfLongestSubstring(string s) {
        set<char> chars;
        if (s.length()<2) return s.length();
        int l=0;
        int r=1;
        int tempres=1;
        int res=1;
        chars.insert(s[0]);
        while (r<s.length())
        {
            if (chars.find(s[r])==chars.end())
            {
                tempres++;
                chars.insert(s[r]);
                r++;
            }
            else
            {
                if (tempres>res) res=tempres;
                while (chars.find(s[r])!=chars.end())
                {
                    chars.erase(s[l]);
                    tempres--;
                    l++;
                }
            }
        }
        if (tempres>res) res=tempres;
        return res;
    }
};