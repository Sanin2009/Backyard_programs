// beats 100%

class Solution {
private:
    int getMinIndex(vector<int>& nums, int i)
    {
        int t=i;
        while (i<nums.size()-1 && nums[t]<nums[i+1]) i++;
        return i;
    }
    void reverseV(vector<int>& nums, int left, int right)
    {
        while (left<right)
        {
            swap(nums[left],nums[right]);
            left++;
            right--;
        }
    }
public:
    void nextPermutation(vector<int>& nums) {
        int i=nums.size()-1;
        for (;i>0; i--)
        {
            if (nums[i]>nums[i-1])
            {
                int index = getMinIndex(nums,i-1);
                swap(nums[index],nums[i-1]);
                reverseV(nums,i,nums.size()-1);
                return;
            }
        }
        reverse(nums.begin(),nums.end());
    }
};