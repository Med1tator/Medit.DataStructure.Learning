using System;
using System.Collections.Generic;
using System.Text;

namespace _001.LinkedList
{
    /// <summary>
    /// 内部实质是一个数组
    /// </summary>
    public class ArrayList
    {
        //定义一个数组
        private object[] objs = new object[4];//可存长度
        public int Size { get; private set; } = 0;//集合的大小,已存长度

        //添加
        public void Add(object value)
        {
            //是否能放下新值
            if (Size >= objs.Length)
            {
                //放不下
                object[] temp = new object[Size * 2];//java中 Size*3/2+1
                //搬家
                for (int i = 0; i < objs.Length; i++)
                {
                    temp[i] = objs[i];
                }
                objs = temp;
            }
            objs[Size] = value;
            Size++;
        }

        public void Set(int index, object value)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();

            objs[index] = value;
        }

        public object Get(int index)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();

            return objs[index];
        }

        public void Clear()
        {
            Size = 0;
            objs = new object[4];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();

            for (int i = index; i < Size - 1; i++)
            {
                objs[i] = objs[i + 1];
            }
            objs[Size] = null;
            Size--;
        }
    }
}
