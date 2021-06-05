﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TaskManagementApp
{
    public class PriorityList
    {
        //タスク優先度の初期化
        public ObservableCollection<string> Data { get; }
        public PriorityList()
        {
            Data = new ObservableCollection<string>();
            for(int i = 1; i <= 10; i++)
            {
                Data.Add(i.ToString());
            }
        }
    }
}