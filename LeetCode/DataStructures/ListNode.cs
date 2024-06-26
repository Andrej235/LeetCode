﻿using System.Text;

namespace LeetCode.DataStructures
{
    public class ListNode
    {
        public int Value { get; set; }
        public ListNode? Next { get; set; }

        public ListNode()
        {
            Value = 0;
            Next = null;
        }

        public ListNode(int value, ListNode? next)
        {
            Value = value;
            Next = next;
        }

        public static ListNode? From(params int[] values)
        {
            if (values.Length == 0)
                return null;

            ListNode head = new(values[0], null);
            ListNode current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.Next = new ListNode(values[i], null);
                current = current.Next;
            }
            return head;
        }

        public override string ToString()
        {
            string result = string.Empty;
            var current = this;

            while (current != null)
            {
                result += current.Next != null ? $"{current.Value} -> " : current.Value;
                current = current.Next;
            }
            return result;
        }
    }
}
