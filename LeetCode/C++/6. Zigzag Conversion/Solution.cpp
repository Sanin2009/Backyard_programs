class Solution {
public:
    string convert(string s, int numRows) {
        if (numRows==1) return s;
        string res;
        for (int i=0;i<s.length(); i=i+(numRows-1)*2) res.push_back(s[i]);
        int i=1;
        int t=0;
        while (i<numRows-1) 
        {
            while (i+t<s.length())
            {
                res.push_back(s[i+t]);
                if (2*(numRows-i-1)+i+t<s.length()) res.push_back(s[2*(numRows-i-1)+i+t]);
                t=t+(numRows*2)-2;
            }
            i++;
            t=0;
        }
        for (int i=numRows-1;i<s.length(); i=i+(numRows-1)*2) res.push_back(s[i]);
        return res;
    }
};