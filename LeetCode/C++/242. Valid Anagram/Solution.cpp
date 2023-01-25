class Solution {
public:
    bool isAnagram(string s, string t) {
        if (s.length()!=t.length()) return false;
        unordered_map<char,int> dict;
        for (char l='a'; l<='z'; l++) dict[l]=0;
        for (int i=0; i<s.length(); i++) dict[s[i]]++;
        for (int i=0; i<s.length(); i++) 
        {
            dict[t[i]]--;
            if (dict[t[i]]<0) return false;
        }
        return true;
    }
};