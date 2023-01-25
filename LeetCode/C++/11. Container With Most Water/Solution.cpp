class Solution {
public:
    int maxArea(vector<int>& height) {
        int res =0;
        int left=0;
        int right=height.size()-1;
        int localMax=0;
        while (left!=right)
        {
            if (height[left]<height[right]) localMax=height[left];
            else localMax=height[right];
            if ((localMax*(right-left))>res) res=localMax*(right-left);
            if (height[left]>height[right]) right--;
            else left++;
        }
        return res;
    }
};