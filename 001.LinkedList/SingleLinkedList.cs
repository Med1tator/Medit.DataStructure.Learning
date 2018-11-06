using System;
using System.Collections.Generic;
using System.Text;

namespace _001.LinkedList
{
    /// <summary>
    /// 单链表
    /// </summary>
    public class SingleLinkedList
    {
        public SLLNode Head { get; set; }
        public int Size { get; private set; } = 0;
        public void Add(object value)
        {
            //添加到最后一项
            SLLNode newNode = new SLLNode(value);

            //第一种
            if (Head == null)
                Head = newNode;
            else
            {
                SLLNode current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            //第二种
            //if (Size == 0)
            //    Head = newNode;
            //else
            //{
            //    SLLNode temp = Head;
            //    for (int i = 0; i < Size - 1; i++)
            //    {
            //        temp = temp.Next;
            //    }
            //    temp.Next = newNode;
            //}

            Size++;
        }

        public void Set(int index, object value)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();

            SLLNode current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }

        public object Get(int index)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();

            SLLNode current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public void Clear()
        {
            Head = null;    //清除数据效率非常高
            Size = 0;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();

            if (index == 0)//删除头
                Head = Head.Next;
            else
            {
                SLLNode current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }

            Size--;
        }
    }

    /// <summary>
    /// 单链表节点类
    /// </summary>
    public class SLLNode
    {
        public object Value { get; set; }   //数据
        public SLLNode Next { get; set; }   //下一节点的地址(对象引用)

        public SLLNode(object value)
        {
            Value = value;
        }
    }
}
