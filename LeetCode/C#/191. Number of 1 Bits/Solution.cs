public class Solution {
    public int HammingWeight(uint n) {
        uint t=0;
        while (n>0)
        {
            t+=(n % 2);
            n=n/2;
        }
        return (int)t;
    }
}