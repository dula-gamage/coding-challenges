/* 
    1. Two Sum
    https://leetcode.com/problems/two-sum/
    Easy
*/
public class TwoNums {
    public int[] TwoSum_Option1(int[] nums, int target) {
        for(int i=0; i < nums.Length; i++){
            for(int j=i+1; j < nums.Length; j++){
                if(nums[i] + nums[j] == target){
                    return [i, j];
                }
            }
        }
        return new int[]{}; // either return empty array or throw exception
    }
    public int[] TwoSum_Option2(int[] nums, int target) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for(int i=0; i < nums.Length; i++){
            int remainder = target - nums[i];
            if(dict.TryGetValue(remainder, out int index)){
                return [index, i];
            }else{
                dict[nums[i]] = i;
            }
        }
        return new int[]{}; // either return empty array or throw exception
    }


    /*
        Main Class Method for testing
        public static void Main(string[] args) {
            TwoNums tn = new TwoNums();
            int[] nums = {2, 7, 11, 15};
            int target = 9;
            int[] result = tn.TwoSum_Option2(nums, target);
            foreach(int i in result){
                Console.WriteLine(i);
            }
        }
    */
}