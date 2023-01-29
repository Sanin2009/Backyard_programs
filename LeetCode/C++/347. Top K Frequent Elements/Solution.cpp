struct fNum
{
    int count;
    int value;
    fNum (int count, int value)
    {
        this->count=count;
        this->value=value;
    }
    friend bool operator <(fNum const& l, fNum const& r)
    {
        return l.count<r.count;
    }
};
class Solution {
public:
    vector<int> topKFrequent(vector<int>& nums, int k) {
        unordered_map<int,int> map;
        priority_queue<fNum> pQ;
        vector<int> result;
        for (int i=0; i<nums.size(); i++)
        {
            if (map[nums[i]]==0) map[nums[i]]=1;
            else map[nums[i]]++;
        }
        for (auto item: map)
        {
            pQ.push(fNum(item.second,item.first));
        }
        for (int i=0; i<k; i++)
        {
            result.push_back(pQ.top().value);
            pQ.pop();
        }
        return result;
    }
};