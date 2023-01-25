class Solution {
public:
    int numIslands(vector<vector<char>>& grid) {
        int m = grid.size();
        int n = grid[0].size();
        int res=0;
        for (int i=0; i<m; i++)
        {
            for (int j=0; j<n; j++)
            {
                if (grid[i][j]=='1')
                {
                    res++;
                    setIsland(grid,i,j);
                }
            }
        }
        return res;
    }
    void setIsland(vector<vector<char>>& grid, int i, int j)
    {
        grid[i][j]='2';
        if (i>0 && grid[i-1][j]=='1') setIsland(grid,i-1,j);
        if (j>0 && grid[i][j-1]=='1') setIsland(grid,i,j-1);
        if (i<grid.size()-1 && grid[i+1][j]=='1') setIsland(grid,i+1,j);
        if (j<grid[0].size()-1 && grid[i][j+1]=='1') setIsland(grid,i,j+1);
    }
};