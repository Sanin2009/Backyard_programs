class Solution {
public:
    int findMin(vector<int>& nums) {
        int size = nums.size()-1; 
        if (nums[0]<=nums[size]) return nums[0];
        return subSearch(nums,1,(size+1)/2,size);
    }
    int subSearch(vector<int>& nums, int min, int mid, int solution)
    {
        if (nums[solution]<nums[solution-1]) return nums[solution];
        if (nums[mid]<nums[0]) return subSearch(nums,min,(min+mid)/2,mid);
        else return subSearch(nums,mid,(mid+solution)/2,solution);
    }
};