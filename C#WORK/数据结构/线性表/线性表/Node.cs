﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线性表 {
    class Node<T> {
        private T data;//储存数据
        private Node<T> next;//指针 指向下个元素

        public Node()
        {
            data = default(T);
            next = null;
        }
        public Node(T value) {
            data = value;
            next = null;
        }
        public Node(T value, Node<T> next) {
            this.data = value;
            this.next = next;
        }
        public Node( Node<T> next) {
            
            this.next = next;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
