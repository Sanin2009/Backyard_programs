// still slow

class Solution {
public:
    vector<int> maxSlidingWindow(vector<int>& nums, int k) {
        map<int,int> temp;
        vector<int> result;
        int left=0;
        int right=k;
        for (int i=0; i<k; i++) mapAdd(temp,nums[i]);
        result.push_back(temp.rbegin()->first);
        while (right<nums.size())
        {
            mapRemove(temp,nums[left]);
            mapAdd(temp,nums[right]);
            result.push_back(temp.rbegin()->first);
            left++;
            right++;
        }
        return result;
    }
private:
    void mapAdd(map<int,int>& m, int val)
    {
        auto v = m.find(val);
        if (v==m.end()) m[val]=1;
        else m[val]++;
    }
    void mapRemove(map<int,int>& m, int val)
    {
        m[val]--;
        if (m[val]==0) m.erase(val);
    }
};