using System;
using System.Collections.Generic;
using System.Text;

namespace _003.ArrayStack
{
    public class ArrayStack<T>
    {
        private T[] _array;
        private int _size;

        public ArrayStack()
        {
            _array = new T[10];
            _size = -1;
        }

        public void Push(T value)
        {
            if (_size == _array.Length - 1)
            {
                var newArray = new T[_array.Length * 2];
                _array.CopyTo(newArray, 0);
                _array = newArray;
            }

            _array[++_size] = value;
        }

        /// <summary>
        /// Returns the object at the top of the Stack without removing it. 
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (_size < 0)
                throw new IndexOutOfRangeException();

            return _array[_size];
        }

        /// <summary>
        /// Removes and returns the object at the top of the Stack.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_size < 0)
                throw new IndexOutOfRangeException();

            return _array[_size--];
        }
    }
}
