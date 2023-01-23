class Solution {
public:
    int search(vector<int>& nums, int target) {
        int left=0;
        int right = nums.size()-1;
        while (left+1<right)
        {
            if (nums[(left+right)/2]>target) right=(left+right)/2;
            else if (nums[(left+right)/2]<target) left=(left+right)/2;
            else return (left+right)/2;
        }
        if (nums[left]==target) return left;
        if (nums[right]==target) return right;
        return -1;
    }
};