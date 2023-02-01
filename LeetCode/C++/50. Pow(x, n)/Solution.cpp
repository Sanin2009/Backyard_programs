class Solution {
private:
    double res;
    double betterPow(double startNum, long leftN, long currentN, double currentRes, double currentMult)
    {
        if (leftN==1) return currentRes;
        return currentN>=leftN ? betterPow(startNum,leftN,1,currentRes,startNum) : betterPow(startNum,leftN-currentN,2*currentN,currentRes*currentMult,currentMult*currentMult);
    }
public:
    double myPow(double x, long n) {
        if (n<0)
        {
            n*=-1;
            x=1/x;
        }
        return n==0 ? 1 : betterPow(x,n,1,x,x);
    }
};