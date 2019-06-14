using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 通过Thread类开启委托
{
    class MyThread
    {

        private string FileName;
        private string FilePath;

        public MyThread(string FileName, string FilePath)
        {
            this.FileName = FileName;
            this.FilePath = FilePath;
        }

        public void DownFile()
        {
            Console .WriteLine("开始下载"+FileName+FilePath);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }
    }
}
