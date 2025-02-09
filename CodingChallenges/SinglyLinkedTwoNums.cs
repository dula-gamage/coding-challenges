
/* 
    1. Two Sum
    https://leetcode.com/problems/
    Easy
*/
public class ListNode{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null){
        this.val = val;
        this.next = next;
    }
}
public class SinglyLinkedTwoNums {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode tempHead = new ListNode(0);
        ListNode temp1 = l1, temp2 = l2, currHead = tempHead; // currHead is used to traverse the linked list keeping the tempHead 0 position as the head
        int remainder = 0;
        while(temp1 != null || temp2 != null){
            int x = (temp1 != null) ? temp1.val : 0;
            int y = (temp2 != null) ? temp2.val : 0;

            int sum = remainder + x + y;
            int nextVal = sum % 10;
            remainder = sum / 10;
            currHead.next = new ListNode(nextVal);
            currHead = currHead.next;
            
            if(temp1 != null) temp1 = temp1.next;
            if(temp2 != null) temp2 = temp2.next;
            if(remainder > 0){
                currHead.next = new ListNode(remainder);
            }
        }
        return tempHead.next; // return next so that first node of 0 will be eliminated
    }
}

/*
public static void Main(string[] args) {
        SinglyLinkedTwoNums singlyLinkedTwoNums = new SinglyLinkedTwoNums();
        ListNode l1 = new ListNode(2, new ListNode(6, new ListNode(3)));
        ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        ListNode result = singlyLinkedTwoNums.AddTwoNumbers(l1, l2);
        while(result != null){
            Console.Write(result.val + " ");
            result = result.next;
        }
    }
*/
