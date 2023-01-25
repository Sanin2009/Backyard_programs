class Solution {
public:
    bool isValid(string s) {
        stack<char> temp;
        for (int i=0; i<s.length(); i++)
        {
            switch (s[i])
            {
                case '(':
                case '[':
                case '{':
                {
                    temp.push(s[i]);
                }
                break;
                case ')':
                {
                    if (temp.empty() || temp.top()!='(') return false;
                    temp.pop();
                }
                break;
                case ']':
                {
                    if (temp.empty() || temp.top()!='[') return false;
                    temp.pop();
                }
                break;
                case '}':
                {
                    if (temp.empty() || temp.top()!='{') return false;
                    temp.pop();
                }
                break;
            }
        }
        return temp.empty();
    }
};