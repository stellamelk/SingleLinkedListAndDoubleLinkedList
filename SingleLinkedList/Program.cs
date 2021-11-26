using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedListAndDoubleLinkedList
{

    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<string> singleLinkedList = new SingleLinkedList<string>();
            //InsertFront(singleLinkedList, "GrandPa");
            //InsertFront(singleLinkedList, "Father");
            //InsertFront(singleLinkedList, "Son");
            InsertLast(singleLinkedList, "GrandPa");
            InsertLast(singleLinkedList, "Father");
            InsertLast(singleLinkedList, "Son");
            ReverseLinkedList(singleLinkedList);
            InsertAfter(singleLinkedList.head.next, "Mother");
            DoubleLinkedList<string> doubleLinkedList = new DoubleLinkedList<string>();
            //InsertFront(doubleLinkedList, "GrandPa");
            //InsertFront(doubleLinkedList, "Father");
            //InsertFront(doubleLinkedList, "Son");
            //InsertFront(doubleLinkedList, "GrandSon");
            InsertLast(doubleLinkedList, "GrandPa");
            InsertLast(doubleLinkedList, "Father");
            InsertLast(doubleLinkedList, "Son");
            InsertLast(doubleLinkedList, "GrandSon");
        }
        public static void ReverseLinkedList<T>(SingleLinkedList<T> singlyList)
        {
            Node<T> prev = null;
            Node<T> current = singlyList.head;
            Node<T> temp = null;
            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            singlyList.head = prev;
        }
        public static void InsertLast<T>(DoubleLinkedList<T> doubleLinkedList, T data)
        {
            DNode<T> newNode = new DNode<T>(data);
            if (doubleLinkedList.head == null)
            {
                newNode.prev = null;
                doubleLinkedList.head = newNode;
                return;
            }
            DNode<T> lastNode = GetLastNode(doubleLinkedList);
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }
        public static void InsertLast<T>(SingleLinkedList<T> singlyList, T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            if (singlyList.head == null)
            {
                singlyList.head = new_node;
                return;
            }
            Node<T> lastNode = GetLastNode(singlyList);
            lastNode.next = new_node;
        }
        public static void InsertFront<T>(SingleLinkedList<T> singlyList, T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            new_node.next = singlyList.head;
            singlyList.head = new_node;
        }
        public static void InsertFront<T>(DoubleLinkedList<T> doubleLinkedList, T data)
        {
            DNode<T> newNode = new DNode<T>(data);
            newNode.next = doubleLinkedList.head;
            newNode.prev = null;
            if (doubleLinkedList.head != null)
            {
                doubleLinkedList.head.prev = newNode;
            }
            doubleLinkedList.head = newNode;
        }
        public static void InsertAfter<T>(Node<T> prev_node, T new_data)
        {
            if (prev_node == null)
            {
               throw new NullReferenceException("The given previous node Cannot be null");
            }
            Node<T> new_node = new Node<T>(new_data);
            new_node.next = prev_node.next;
            prev_node.next = new_node;
        }
        public static void InsertAfter<T>(DNode<T> prev_node, T data)
        {
            if (prev_node == null)
            {
                throw new NullReferenceException("The given previous node Cannot be null");
            }
            DNode<T> newNode = new DNode<T>(data);
            newNode.next = prev_node.next;
            prev_node.next = newNode;
            newNode.prev = prev_node;
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
        }
        //public static void DeleteNodebyKey<T>(SingleLinkedList<T> singlyList, T key)
        //{
        //    Node<T> temp = singlyList.head;
        //    Node<T> prev = null;
        //    if (temp != null && temp.data== key)// Error -"Operation "==" cannot be applied to operands of type 'T' and 'T'"
        //    {
        //        singlyList.head = temp.next;
        //        return;
        //    }
        //    while (temp != null && temp.data != key)
        //    {
        //        prev = temp;
        //        temp = temp.next;
        //    }
        //    if (temp == null)
        //    {
        //        return;
        //    }
        //    prev.next = temp.next;
        //}
        private static Node<T> GetLastNode<T>(SingleLinkedList<T> singlyList)
        {
            Node<T> temp = singlyList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        private static DNode<T> GetLastNode<T>(DoubleLinkedList<T> doubleLinkedList)
        {
            DNode<T> temp = doubleLinkedList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
    }
    internal class DoubleLinkedList<T>
    {
        internal DNode<T> head;
    }
    internal class DNode<T>
    {
        internal T data;
        internal DNode<T> prev;
        internal DNode<T> next;
        public DNode(T value)
        {
            data = value;
            prev = null;
            next = null;
        }
    }
    internal class SingleLinkedList<T>
    {
        internal Node<T> head;
    }

    internal class Node<T>
    {
        internal T data;
        internal Node<T> next;
        public Node(T value)
        {
            data = value;
            next = null;
        }
    }

}
