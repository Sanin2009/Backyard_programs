class Solution {
private:
    inline bool checkEqual(int l, int r, string& s)
    {
        if (l<0 || r>=s.length()) return false;
        return s[l]==s[r];
    }
public:
    string longestPalindrome(string& s) {
        int solL=0;
        int solR=0;
        int max=1;
        for (int i=0; i<s.length()-1; i++)
        {
            int tempL=i-1;
            int tempR=i+1;
            int tempMax=1;
            while(checkEqual(tempL,tempR,s))
            {
                tempL--;
                tempR++;
                tempMax+=2;
            }
            if (tempMax>max)
            {
                solL=tempL+1;
                solR=tempR-1;
                max=tempMax;
            }
            if (s[i]==s[i+1])
            {
                tempL=i-1;
                tempR=i+2;
                tempMax=2;
                while(checkEqual(tempL,tempR,s))
                {
                    tempL--;
                    tempR++;
                    tempMax+=2;
                }
            }
            if (tempMax>max)
            {
                solL=tempL+1;
                solR=tempR-1;
                max=tempMax;
            }
        }
        return s.substr(solL,solR-solL+1);
    }
};