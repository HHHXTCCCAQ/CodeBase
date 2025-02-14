﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线性表 {
  

interface IListDs <T>
{
    int GetLength();
    void Claer();
    bool IsEmpty();
    void Add(T item);
    void Insert(T item, int index);
    T Delete(int index);
    T this[int index] { get; }
    T GetEle(int index);
    int Locate(T value);
}
}
