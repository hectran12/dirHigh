using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        dirCsharp.dirHigh dir = new dirCsharp.dirHigh();
        string tao = dir.createFolder(@"C:\Users\tronghoa\Documents\clone","clone1");
        if (dir.status)
        {
            Console.WriteLine(tao);
        } else
        {
            Console.WriteLine(tao);
        }

        
        Console.WriteLine(dir.getSizeFolder(@"C:\Users\tronghoa\Downloads\cmder"));

        dir.DirectoryCopy(@"C:\Users\tronghoa\Downloads\cmder", @"C:\Users\tronghoa\Documents\clone\clone1", true);
        if (dir.status)
        {
            Console.WriteLine("Copy thành công!");
        }
    }
}