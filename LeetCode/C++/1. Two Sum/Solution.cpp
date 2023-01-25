class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        int size = nums.size();
        unordered_map<int,int> dict;
        vector<int> result;
        for (int i=0; i<size; i++) dict[target-nums[i]]=i;
        for (int i=0; i<size; i++)
        {
            if ((dict.count(nums[i])>0) && dict[nums[i]]!=i)
            {
                result.push_back(i);
                result.push_back(dict[nums[i]]);
                return result;
            }
        }
        return result;
    }
};