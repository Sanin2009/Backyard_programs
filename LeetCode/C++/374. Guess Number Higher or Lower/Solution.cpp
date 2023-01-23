/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

class Solution {
public:
    int guessNumber(int n) {
        long min=0;
        long max=n;
        long res=0;
        while(true){
            res=guess((min+max+1)/2);
            if (res==1) min = (min+max+1)/2;
            else if (res==-1) max = (min+max+1)/2;
            else return (min+max+1)/2;
        }
        
    }
};