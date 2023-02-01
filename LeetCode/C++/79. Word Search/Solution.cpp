class Solution {
private:
    bool exists;
    void lookUp(vector<vector<char>>& board, string word, int i, int j, unordered_set<int> crd, int letter)
    {
        if (exists) return;
        if (letter==word.length())
        {
            exists=true;
            return;
        }
        if (i<0 || j<0 || i==board.size() || j==board[0].size()) return;
        if (word[letter]!=board[i][j]) return;
        if (crd.count(10*i+j)>0) return;
        crd.insert(10*i+j);
        lookUp(board,word,i-1,j,crd,letter+1);
        lookUp(board,word,i+1,j,crd,letter+1);
        lookUp(board,word,i,j+1,crd,letter+1);
        lookUp(board,word,i,j-1,crd,letter+1);
    }
public:
    bool exist(vector<vector<char>>& board, string word) {
        unordered_set<int> crd;
        multiset<char> blackStart;
        multiset<char> blackSecond;
        multiset<char> whiteStart;
        multiset<char> whiteSecond;
        int m = board.size();
        int n = board[0].size();
        exists=false;
        for (int i=0; i<m; i++) for (int j=0; j<n; j++)
        {
            if ((i+j)%2)
            {
                whiteStart.insert(board[i][j]);
                whiteSecond.insert(board[i][j]);
            }
            else
            {
                blackStart.insert(board[i][j]);
                blackSecond.insert(board[i][j]);
            }
        }
        bool whiteCanStart=true;
        bool blackCanStart=true;
        for (int i=0; i<word.length(); i++)
        {
            if (i%2)
            {
                auto it = whiteStart.find(word[i]);
                if (it==whiteStart.end()) whiteCanStart=false;
                else whiteStart.erase(it);
            }
            else
            {
                auto it = blackSecond.find(word[i]);
                if (it==blackSecond.end()) whiteCanStart=false;
                else blackSecond.erase(it);
            }
        }
        //
        for (int i=0; i<word.length(); i++)
        {
            if (i%2)
            {
                auto it = blackStart.find(word[i]);
                if (it==blackStart.end()) blackCanStart=false;
                else blackStart.erase(it);
            }
            else
            {
                auto it = whiteSecond.find(word[i]);
                if (it==whiteSecond.end()) blackCanStart=false;
                else whiteSecond.erase(it);
            }
        }
        for (int i=0; i<m; i++) for (int j=0; j<n; j++) 
        {
            if ((i+j)%2 && blackCanStart) lookUp(board,word,i,j,crd,0);
            if ((i+j)%2==0 && whiteCanStart) lookUp(board,word,i,j,crd,0);
        }
        return exists;        
    }
};