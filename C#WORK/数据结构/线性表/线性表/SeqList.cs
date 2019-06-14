using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线性表 {
    /// <summary>
    /// 顺序表实现的方式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SeqList<T> : IListDs<T> {
        private T[] data;//用来存储数据
        private int count = 0;//表示存储了多少个数据

        public SeqList(int size)//size就是最大容量
        {
            data = new T[size];
            count = 0;
        }

        public SeqList()
            : this(10) {//默认的构造函数 容量为10

        }
        /// <summary>
        /// 取得数据的个数
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return count;
        }
        /// <summary>
        ///清空List
        /// </summary>
        public void Claer()
        {
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="item">数据</param>
        public void Add(T item) {
            if (count == data.Length)
            {
                Console.WriteLine("当前顺序表已经存满，不允许再存入");
            }
            else
            {
                data[count] = item;
                count++;

            }
            
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void Insert(T item, int index) {
            for (int i = count-1 ; i >=index  ; i--)
            {

                data[i+1] = data[i];
            }
            data[index] = item;
            count ++;
        }
        /// <summary>
        /// 删除索引位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Delete(int index)
        {
            T temp = data[index];
            for (int i = index+1; i < count; i++)
            {
                data[i - 1] = data[i];//把数据向前移动
            }
            count--;
            return temp;
        }

        public T this[int index] {
            get { return GetEle(index); }
        }
        /// <summary>
        /// 通过索引取得元素
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns></returns>
        public T GetEle(int index) {
            if (index >= 0 && index <= count - 1)
            {
                return data[index];
            }
            else
            {
                Console.WriteLine("索引不存在");
                return default(T);
            }
        }

        public int Locate(T value) {
            for (int i = 0; i < count ; i++)
            {
                if (data[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
