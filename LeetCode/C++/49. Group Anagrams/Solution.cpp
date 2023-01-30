class Solution {
public:
    vector<vector<string>> groupAnagrams(vector<string>& strs) {
        vector<vector<string>> result;
        unordered_map<string,vector<string>> strMap;
        for (int i=0; i<strs.size(); i++)
        {
            string t = strs[i];
            sort(strs[i].begin(),strs[i].end());
            strMap[strs[i]].push_back(t);
        }
        for (auto m: strMap) result.push_back(m.second);
        return result;
    }
};