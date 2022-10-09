public class Solution 
{
    public double res;
    public double MyPow(double x, int n) 
    {
        if (n<0)
        {
            x=1/x;
            n*=-1;
        }
        if (n==0) return 1.0;
        if (x==0) return 0.0;
        BetterPow(n-1,1,x,x,x);
        return res;
    }
    public void BetterPow(int powsToGo, int currentPow, double currentNumber, double basePow, double resultNumber)
    {
        if (currentPow<powsToGo)
        {
            resultNumber*=currentNumber;
            currentNumber*=currentNumber;
            BetterPow(powsToGo-currentPow,currentPow*2, currentNumber, basePow, resultNumber);
        }
        else if (powsToGo>0)
        {
            BetterPow(powsToGo-1,1,basePow,basePow,resultNumber*basePow);
        }
        else res=resultNumber;
    }
}