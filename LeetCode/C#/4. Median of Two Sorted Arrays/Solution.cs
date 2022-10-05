public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        const int MAX_INT = 10000000;
        const int MIN_INT = 10000000;
        int it1=0;
        int it2=0;
        int value1;
        int value2;
        
        if (nums1.Length==0) value1=MAX_INT;
        else value1=nums1[0];
        if (nums2.Length==0) value2=MAX_INT;
        else value2=nums2[0];
        
        int length = nums1.Length + nums2.Length;
        double test = 0;
        int med1=0;
        int med2=0;
        for (int i=0; i<=(length/2); i++)
        {
            // Finding smaller of 2
            if (value1<value2)
            {
                if (i==((length/2)-1)) med1= value1;
                if (i==(length/2)) med2= value1;
                it1++;
                if (it1>=nums1.Length) value1 = MAX_INT;
                else value1=nums1[it1];
            }
            else
            {
                if (i==((length/2)-1)) med1= value2;
                if (i==(length/2)) med2= value2;
                it2++;
                if (it2>=nums2.Length) value2 = MAX_INT;
                else value2=nums2[it2];
            }
        }
            
        if (length % 2 == 1) return med2; 
        else 
        {
            double res=med1+med2;
            return res/2;
        }
    }
}