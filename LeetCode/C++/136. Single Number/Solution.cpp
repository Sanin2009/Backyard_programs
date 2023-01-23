class Solution {
public:
    int singleNumber(vector<int>& nums) {
        int res=nums[0];
        int numsSize = nums.size(); 
        if (numsSize==1) return res;
        for (int i=1; i<numsSize; i++) res=res^nums[i];
        return res;
    }
};