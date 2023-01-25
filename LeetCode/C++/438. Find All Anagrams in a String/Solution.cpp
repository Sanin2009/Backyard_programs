class Solution {
public:
    vector<int> findAnagrams(string s, string p) {
        unordered_map<char,int> dict;
        vector<int> result;
        if (p.length()>s.length()) return result;
        int left=0;
        int right = p.length()-1;
        for (char l='a'; l<='z'; l++) dict[l]=0;
        for (int i=0; i<p.length(); i++) dict[p[i]]++;
        for (int i=0; i<p.length(); i++) dict[s[i]]--;
        for (; right<s.length();)
        {
            bool res = true;
            for (char l='a'; l<='z'; l++) 
            {
                if (dict[l]!=0)
                {
                    res = false;
                    break;
                }
            }
            if (res) result.push_back(left);
            dict[s[left]]++;
            right++;
            dict[s[right]]--;
            left++;
        }
        return result;
    }
};