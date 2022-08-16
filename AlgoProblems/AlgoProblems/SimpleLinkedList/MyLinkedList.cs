using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlgoProblems.SimpleLinkedList
{
    public class MyLinkedList<T>
    {
        private Node<T> head;
        public void AddFirst(T data)
        {
            var currentNode = new Node<T> { Data = data, Next = null };
            if (head==null)
            {
                head = currentNode;
            }
            else
            {
                currentNode.Next = head;
                head = currentNode;
            }
        }
        public void AddLast(T data)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var currentNode = new Node<T> { Data = data, Next = null };
            var currentHead = head;
            while (currentHead.Next!=null)
            {
                currentHead = currentHead.Next;
            }
            currentHead.Next = currentNode;
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
