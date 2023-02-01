using Data.LinkedList;
using System;
using System.Collections;
using System.Linq.Expressions;

var linkedList = new CastomLinkedList<int>();
linkedList.Add(1);
linkedList.Add(2);
linkedList.Add(3);
linkedList.Add(4);
linkedList.Add(5);
linkedList.Remove(6);

foreach (var ii in linkedList)
    Console.WriteLine(ii);