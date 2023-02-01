class Solution {
public:
    int uniquePaths(int m, int n) {
        vector<vector<int>> howLong;
        vector<int> t(n,0);
        for (int i=0; i<m; i++) howLong.push_back(t);
        howLong[m-1][n-1]=1;
        for (int i=m-1; i>=0; i--)
        {
            for (int j=n-1; j>=0; j--)
            {
                if (j<n-1) howLong[i][j]+=howLong[i][j+1];
                if (i<m-1) howLong[i][j]+=howLong[i+1][j];
            }
        }
        return howLong[0][0];
    }
};