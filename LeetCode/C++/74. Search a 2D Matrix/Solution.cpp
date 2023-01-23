class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        if (target<matrix[0][0]) return false;
        if (target==matrix[0][0]) return true;
        int m = matrix.size();
        int n = matrix[0].size();
        if (target>matrix[m-1][n-1]) return false;
        if (target==matrix[m-1][n-1]) return true;
        int right = m*n-1; 
        int left = 0;
        int mid = (left+right)/2;
        int i = mid/m;
        int j = mid%n;
        while (left+1<right)
        {
            mid = (left+right)/2;
            i = mid/n;
            j = mid%n;
            if (matrix[i][j]>target) right=(left+right)/2;
            else if (matrix[i][j]<target) left=(left+right)/2;
            else return true;
        }
        return false;
    }
};