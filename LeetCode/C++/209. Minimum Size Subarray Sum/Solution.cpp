class Solution {
public:
    int minSubArrayLen(int target, vector<int>& nums) {
        int size = nums.size();
        int sum=0;
        for (int i=0; i<size; i++) sum+=nums[i];
        if (sum<target) return 0;
        return checkTarget(target,nums,size/2,0,size);
    }
private:
    int checkTarget(int target, vector<int>& nums, int length, int previous, int solution)
    {
        if (length==solution) return solution;
        if (previous+1==solution) return solution;
        int sum=0;
        int right=length;
        int left=0;
        for (int i=0; i<length; i++) sum+=nums[i];
        while (right<nums.size())
        {
            if (sum>=target) return checkTarget(target,nums,(previous+length+1)/2,previous,length);
            sum-=nums[left];
            sum+=nums[right];
            left++;
            right++;
        }
        if (sum>=target) return checkTarget(target,nums,(previous+length+1)/2,previous,length);
        return checkTarget(target,nums,(solution+length+1)/2,length,solution);
    }
};