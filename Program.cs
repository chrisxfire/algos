using System.Text;

namespace Algorithms;
public class StringAlgorithms {
    // Test  if a string is all uppercase: 
    static Boolean IsUppercase(string s) {
        return s.All(char.IsUpper);
    }

    // Test if a string is complex:
    static Boolean isComplex(string s) {
        return s.Any(char.IsUpper) && s.Any(char.IsLower)
                                   && s.Any(char.IsDigit);

    }

    // Normalize a string to a common form:
    static string NormalizeString(string input) {
        string lowercased = input.ToLower().Trim();
        return lowercased;
    }

    // Reverse a string:
    static string Reverse(string input) {
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) {
            return input;
        }

        StringBuilder reversed = new StringBuilder(input.Length);

        // Iterate through the string backwards:
        for (int i = input.Length - 1; i >= 0; i--) {
            reversed.Append(input[i]); // Take the next character and append it to the StringBuilder object
        }

        return reversed.ToString(); // Convert the StringBuilder object to a string.
    }
    // Reverse each word in a string and return it.
    static string ReverseEachWord(string input) {
        if (string.IsNullOrEmpty(input)) {
            return input;
        }

        StringBuilder result = new StringBuilder();
        string[] arr = input.Split(" ");
        for (int i = 0; i < arr.Length; i++) {
            result.Append(Reverse(arr[i]));
            if (i != arr.Length - 1) {
                result.Append(" ");
            }
        }
        return result.ToString();
    }
}

public class ArrayAlgorithms {
    // Linear Search (sequential search) | O(n) time.
    // Built-in:  Array.Find().
    static Boolean LinearSearch(int[] input, int n) {
        foreach (int current in input) {
            if (n == current) {
                return true;
            }
        }
        return false;
    }

    // Binary Search | O(log(n)) time.
    // Built-in:  Array.BinarySearch().
    // Given a sorted array of integers, return Boolean if the element exists.
    static Boolean BinarySearch(int[] inputArray, int item) {
        int min = 0;
        int max = inputArray.Length - 1;

        while (min <= max) {
            int mid = (min + max) / 2; // Find the midpoint
            if (item == inputArray[mid]) { // If the midpoint is the item we are looking for
                return true;
            } else if (item < inputArray[mid]) { // If the item we are looking for < the item at the midpoint:
                max = mid - 1; // Search the front half of the array.
            } else {
                min = mid + 1; // Search through the back half of the array.
            }
        }
        return false;
    }

    // Given two arrays of integers, find the even numbers they contain(?)
    static int[] FindEvenNums(int[] arr1, int[] arr2) {
        var result = new List<int>();
        foreach (int num in arr1) {
            if (num % 2 == 0) {
                result.Add(num);
            }
        }
        foreach (int n2 in arr2) {
            if (n2 % 2 == 0) {
                result.Add(n2);
            }
        }
        return result.ToArray();
    }

    // Given an array of integers, reverse it and return the reversed array.
    static int[] Reverse(int[] input) {
        int[] reversed = new int[input.Length]; // Create a new array to hold the reversed array.

        for (int i = 0; i < reversed.Length; i++) {
            reversed[i] = input[input.Length - i - 1]; // reversed[0] = input[4], reversed[1] = input[3], ...
        }

        return reversed;
    }

    // Reverse an array of integers in place.
    static void ReverseInPlace(int[] input) {
        // Swapping elements, so only need to iterate half the length of the array:
        for (int i = 0; i < input.Length / 2; i++) {
            // Swap index(i) with index(input.Length - i - 1)
            int temp = input[i];
            input[i] = input[input.Length - i - 1];
            input[input.Length - i - 1] = temp;
        }
    }

    // Given { 1, 3, 5, 7, 9 }
    // Result { 9, 3 ?
    static void RotateArrayLeft(int[] input) {
        int temp = input[0];
        for (int i = 0; i < input.Length - 1; i++) {
            input[i] = input[i + 1];
        }
        input[input.Length - 1] = temp;
    }
}

public class LinkedListAlgorithms {
    class CustomLinkedList {
        Node? head; // First item in the list

        public class Node { // Used by CustomLinkedList to describes Nodes
            public int data;
            public Node? next; // The next item in the list
            public Node(int d) { data = d; }
        }

        public void DeleteBackHalf() {
            if (head == null || head.next == null) {
                head = null;
            }
            Node? slow = head;
            Node? fast = head;
            Node? prev = null;

            while (fast != null) {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
        }

        public void DeleteNthNodeFromEnd(int n) {
            if (head == null || n == 0) { return; }

            Node? first = head;
            Node? second = head;

            for (int i = 0; i < n; i++) {
                second = second.next;
                if (second.next == null) {
                    if (i == n - 1) {
                        head = head.next; // Delete the first element.
                    }
                    return;
                }
            }

            while (second.next != null) {
                first = first.next;
                second = second.next;
            }
            first.next = first.next.next;
        }
    }
}

public class QueueAlgorithms {
    // Print the first n binary numbers:
    static void PrintBinary(int n) {
        if (n <= 0) { return; }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        // Assume n = 5.
        for (int i = 0; i < n; i++) {
            int current = queue.Dequeue(); // current == 1
            Console.WriteLine(current);
            queue.Enqueue(current * 10); // Append a 0 to the end of current, making 1 -> 10, and enqueue it.
            queue.Enqueue(current * 10 + 1); // Append a 1 to the end of current * 10 (10), making 11, and enqueue it.
        }
        Console.WriteLine();
    }
}