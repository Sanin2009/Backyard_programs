class Solution {
public:
    int tribonacci(int n) {
        int n1=0, n2=1, n3=1;
        if (n==0) return n1;
        if (n==1) return n2;
        if (n==2) return n3;
        for (int i=2; i<n; i++)
        {
            n1=n1+n2+n3;
            swap(n1,n2);
            swap(n2,n3);
        }
        return n3;
    }
};