class Solution {
public:
    vector<vector<int>> merge(vector<vector<int>>& intervals) {
        vector<vector<int>> result;
        sort(intervals.begin(),intervals.end());
        int i=1;
        int left=intervals[0][0];
        int right=intervals[0][1];
        while (i<intervals.size())
        {
            if (intervals[i][0]<=right)
            {
                right=max(intervals[i][1],right);
                i++;
            }
            else
            {
                vector<int> t;
                t.push_back(left);
                t.push_back(right);
                result.push_back(t);
                if (i==intervals.size()) return result;
                left=intervals[i][0];
                right=intervals[i][1];
            }
        }
        vector<int> t;
        t.push_back(left);
        t.push_back(right);
        result.push_back(t);
        return result;
    }
};