using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlgoProblems.SimpleLinkedList
{
    public class TestLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public void AddToTop(T data)
        {
            var currentNode = new Node<T> { Data = data, Next = null };
            if (head == null)
            {
                head = currentNode;
                tail = head;
            }
            else
            {
                currentNode.Next = head;
                head = currentNode;
                //tail.Next = currentNode;
                //tail = currentNode;
            }
        }
        public void AddLast(T data)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var currentNode = new Node<T> { Data = data, Next = null };
            tail.Next = currentNode;
            tail = currentNode;
            stopWatch.Stop();
        }
        public List<T> GetAll()
        {
            var nodes = new List<T>();
            var currentHead = head;
            while (currentHead.Next != null)
            {
                nodes.Add(currentHead.Data);
                currentHead = currentHead.Next;
            }
            nodes.Add(currentHead.Data);

            return nodes;
        }
    }
}
