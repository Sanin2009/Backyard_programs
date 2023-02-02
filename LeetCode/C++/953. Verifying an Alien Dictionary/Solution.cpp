class Solution {
public:
    bool isAlienSorted(vector<string>& words, string order) {
        unordered_map<char,int> dict;
        for (int i=0; i<order.length(); i++) dict[order[i]]=i;
        int it=0;
        while (it<words.size()-1)
        {
            int i=0;
            while (i<words[it].length() && i<words[it+1].length())
            {
                if (dict[words[it][i]]>dict[words[it+1][i]]) return false;
                if (dict[words[it][i]]<dict[words[it+1][i]]) 
                {
                    i=INT_MAX;
                    break;
                }
                if (dict[words[it][i]]==dict[words[it+1][i]]) i++;

            }
            if (i==words[it+1].length() && i!=words[it].length()) return false;
            it++;
        }
        return true;
    }
};