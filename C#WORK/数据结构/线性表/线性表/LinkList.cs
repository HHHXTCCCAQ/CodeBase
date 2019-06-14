using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线性表 {
    class LinkList<T> : IListDs<T> {

        private Node<T> headNode;//存储一个头结点

        public LinkList() {
            headNode = null;
        }
        public int GetLength()
        {
            if (headNode==null)
            {
                return 0;
            }
            Node<T> temp = headNode;
            int count = 1;
            while (true)
            {
                if (temp.Next!=null)
                {
                    count++;
                    temp = temp.Next;
                }
                else
                {
                    break;
                }
                
                
            }
            return count;
        }

        public void Claer()
        {
            headNode = null;
        }

        public bool IsEmpty()
        {
            return headNode == null;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item) {
            Node<T> newNode = new Node<T>(item);//创建一个新的节点
            //如果头结点为空，那么这个节点是头结点
            if (headNode == null) {
                headNode = newNode;

            } else {//把新的节点放到链表的尾部
                //要访问链表的尾节点
                Node<T> temp = headNode;
                while (true) {
                    if (temp.Next != null) {
                        temp = temp.Next;

                    } else {
                        break;
                    }
                }
                temp.Next = newNode;//把新节点放到尾部
            }


        }

        public void Insert(T item, int index) {
            Node<T> newNode = new Node<T>();
            if (index == 0)//插入到头结点
            {
                newNode.Next = headNode;
                headNode = newNode;
            } else {//插入到其他位置
                Node<T> temp = headNode;
                for (int i = 1; i <= index - 1; i++) {//让temp像后移动index-1次
                    temp = temp.Next;
                }
                Node<T> preNode = temp;
                Node<T> currentNode = temp.Next;
                preNode.Next = newNode;
                newNode.Next = currentNode;
            }
        }

        public T Delete(int index)
        {
            T data = default(T);
            if (index == 0)
            {
                data = headNode.Data;
                headNode = headNode.Next;
            }
            else
            {
                Node<T> temp = headNode;
                for (int i = 1; i <= index - 1; i++) {//让temp像后移动index-1次
                    temp = temp.Next;
                }
                Node<T> preNode = temp;
                Node<T> currentNode = temp.Next;
                data = currentNode.Data;
                Node<T> nextNode = temp.Next.Next;
                preNode.Next = nextNode;
            }
            return data;
        }

        public T this[int index] {
            get {
                Node<T> temp = headNode;
                for (int i = 1; i <= index ; i++) {
                    temp = temp.Next;
                }
                return temp.Data;
            }
        }

        public T GetEle(int index)
        {
            return this[index];
        }

        public int Locate(T value) {
            Node<T> temp = headNode;
            if (temp==null)
            {
                return -1;

            }
            else
            {
                int index = 0;
                while (true)
                {
                    if (temp.Data.Equals(value))
                    {
                        return index;
                    }
                    else
                    {
                        if (temp.Next!=null)
                        {
                            temp = temp.Next;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return -1;
            }
        }
    }
}
