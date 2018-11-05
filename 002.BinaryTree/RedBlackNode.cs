using System;
using System.Collections.Generic;
using System.Text;

namespace _002.BinaryTree
{
    public class RedBlackNode<T> where T : IComparable
    {
        RedBlack color;//颜色
        T key;//关键字(键值)
        RedBlackNode<T> root;//根节点
        RedBlackNode<T> left;//左子节点
        RedBlackNode<T> right;//右子节点
        RedBlackNode<T> parent;//父节点

        public RedBlackNode(T key, RedBlack color, RedBlackNode<T> parent, RedBlackNode<T> left, RedBlackNode<T> right)
        {
            this.key = key;
            this.color = color;
            this.parent = parent;
            this.left = left;
            this.right = right;
        }

        public T GetKey()
        {
            return key;
        }

        public override string ToString()
        {
            return "" + key + (this.color == RedBlack.Red ? "Red" : "Black");
        }

        /*************对红黑树节点x进行左旋操作 ******************/
        /*
         * 左旋示意图：对节点x进行左旋
         *     p                       p
         *    /                       /
         *   x                       y
         *  / \                     / \
         * lx  y      ----->       x  ry
         *    / \                 / \
         *   ly ry               lx ly
         * 左旋做了三件事：
         * 1. 将y的左子节点赋给x的右子节点,并将x赋给y左子节点的父节点(y左子节点非空时)
         * 2. 将x的父节点p(非空时)赋给y的父节点，同时更新p的子节点为y(左或右)
         * 3. 将y的左子节点设为x，将x的父节点设为y
         */
        private void LeftRotate(RedBlackNode<T> x)
        {
            //1. 将y的左子节点赋给x的右子节点，并将x赋给y左子节点的父节点(y左子节点非空时)
            RedBlackNode<T> y = x.right;
            x.right = y.left;

            if (y.left != null)
                y.left.parent = x;

            //2. 将x的父节点p(非空时)赋给y的父节点，同时更新p的子节点为y(左或右)
            y.parent = x.parent;
            if (x.parent != null)
                this.root = y;  //如果x的父节点为空，则将y设为父节点
            else
            {
                if (x == x.parent.left) //如果x是左子节点
                    x.parent.left = y;  //则也将y设为左子节点
                else
                    x.parent.right = y; //否则将y设为右子节点
            }

            //3. 将y的左子节点设为x，将x的父节点设为y
            y.left = x;
            x.parent = y;
        }

        /*************对红黑树节点y进行右旋操作 ******************/
        /*
         * 左旋示意图：对节点y进行右旋
         *        p                   p
         *       /                   /
         *      y                   x
         *     / \                 / \
         *    x  ry   ----->      lx  y
         *   / \                     / \
         * lx  rx                   rx ry
         * 右旋做了三件事：
         * 1. 将x的右子节点赋给y的左子节点,并将y赋给x右子节点的父节点(x右子节点非空时)
         * 2. 将y的父节点p(非空时)赋给x的父节点，同时更新p的子节点为x(左或右)
         * 3. 将x的右子节点设为y，将y的父节点设为x
         */
        private void RightRotate(RedBlackNode<T> y)
        {
            //1. 将y的左子节点赋给x的右子节点，并将x赋给y左子节点的父节点(y左子节点非空时)
            RedBlackNode<T> x = y.left;
            y.left = x.right;

            if (x.right != null)
                x.right.parent = y;

            //2. 将x的父节点p(非空时)赋给y的父节点，同时更新p的子节点为y(左或右)
            x.parent = y.parent;
            if (y.parent != null)
                this.root = x;  //如果x的父节点为空，则将y设为父节点              
            else
            {
                if (y == y.parent.left) //如果x是左子节点
                    y.parent.left = x;  //则也将y设为左子节点
                else
                    y.parent.right = x; //否则将y设为右子节点
            }

            //3. 将y的左子节点设为x，将x的父节点设为y
            x.right = y;
            y.parent = x;
        }

        /*********************** 向红黑树中插入节点 **********************/
        private void Insert(T key)
        {
            RedBlackNode<T> node = new RedBlackNode<T>(key, RedBlack.Red, null, null, null);
            if (node != null)
                Insert(node);
        }

        //将节点插入到红黑树中，这个过程与二叉搜索树是一样的
        private void Insert(RedBlackNode<T> node)
        {
            RedBlackNode<T> current = null; //表示最后node的父节点
            RedBlackNode<T> x = this.root;  //用来向下搜索用的

            //1. 找到插入的位置
            while (x != null)
            {
                current = x;
                int cmp = node.key.CompareTo(x.key);
                if (cmp < 0)
                    x = x.left;
                else
                    x = x.right;
            }

            node.parent = current;  //找到了位置，将当前current作为node的父节点

            //2. 接下来判断node是插左子节点还是右子节点
            if (current != null)
            {
                int cmp = node.key.CompareTo(current.key);
                if (cmp < 0)
                    current.left = node;
                else
                    current.right = node;
            }
            else
            {
                this.root = node;
            }

            //3. 将它重新修正为一颗红黑树
            InsertFixUp(node);
        }

        private void InsertFixUp(RedBlackNode<T> node)
        {
            RedBlackNode<T> parent, gParent;    //定义父节点和祖父节点

            //需要修整的条件：父节点存在，且父节点的颜色是红色
            while (((parent = ParentOf(node)) != null) && IsRed(parent))
            {
                gParent = ParentOf(parent);

                //若父节点是祖父节点的左子节点，下面else与其相反
                if (parent == gParent.left)
                {
                    RedBlackNode<T> uncle = gParent.right;  //获得叔叔节点

                    //case 1:叔叔节点也是红色
                    if (uncle != null && IsRed(uncle))
                    {
                        SetBlack(parent);   //把父节点和叔叔节点涂黑
                        SetRed(uncle);
                        SetRed(gParent);    //把祖父节点涂红
                        node = gParent; //将位置放到祖父节点处
                        continue;   //继续while，重新判断
                    }

                    //case 2：叔叔节点是黑色，且当前节点是右子节点
                    if (node == parent.right)
                    {
                        LeftRotate(parent); //从父节点处左转
                        RedBlackNode<T> temp = parent;  //然后将父节点和自己调换一下，为下面右旋转做准备
                        parent = node;
                        node = temp;
                    }

                    //case 3：叔叔节点是黑色，且当前节点是左子节点
                    SetBlack(parent);
                    SetBlack(gParent);
                    RightRotate(gParent);
                }
                else {  //若父节点是祖父节点的右子节点，与上面的完全相反，本质一样的
                    RedBlackNode<T> uncle = gParent.left;  //获得叔叔节点

                    //case 1:叔叔节点也是红色
                    if (uncle != null && IsRed(uncle))
                    {
                        SetBlack(parent);   //把父节点和叔叔节点涂黑
                        SetRed(uncle);
                        SetRed(gParent);    //把祖父节点涂红
                        node = gParent; //将位置放到祖父节点处
                        continue;   //继续while，重新判断
                    }

                    //case 2：叔叔节点是黑色，且当前节点是左子节点
                    if (node == parent.left)
                    {
                        RightRotate(parent); //从父节点处左转
                        RedBlackNode<T> temp = parent;  //然后将父节点和自己调换一下，为下面右旋转做准备
                        parent = node;
                        node = temp;
                    }

                    //case 3：叔叔节点是黑色，且当前节点是右子节点
                    SetBlack(parent);
                    SetBlack(gParent);
                    LeftRotate(gParent);
                }
            }

            //将根节点设置为黑色
            SetBlack(this.root);
        }

        private RedBlackNode<T> ParentOf(RedBlackNode<T> node)
        {
            return node?.parent;
        }

        private bool IsRed(RedBlackNode<T> node)
        {
            if (node != null)
                return node.color == RedBlack.Red;
            return false;
        }

        private void SetRed(RedBlackNode<T> node)
        {
            if (node != null)
                node.color = RedBlack.Red;
        }

        private void SetBlack(RedBlackNode<T> node)
        {
            if (node != null)
                node.color = RedBlack.Black;
        }
    }

    public enum RedBlack
    {
        Red,
        Black
    }
}
