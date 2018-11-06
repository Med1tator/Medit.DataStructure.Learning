using System;
using System.Collections.Generic;
using System.Text;

namespace _001.LinkedList
{
    public class SingleCirclularLinkedList
    {
        public SCLLNode Head { get; set; }
    }

    /// <summary>
    /// 单向循环链表节点类
    /// </summary>
    public class SCLLNode
    {
        public object Value { get; set; }
        public SCLLNode Next { get; set; }
        public SCLLNode Prev { get; set; }
    }
}
