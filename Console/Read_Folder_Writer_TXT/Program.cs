using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_Folder_Writer_TXT
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo diretorio = new DirectoryInfo(@"C:\folder");
            FileInfo[] Arquivos = diretorio.GetFiles("*.*");
            StreamWriter sr = new StreamWriter(@"C:\save.txt");
            foreach (FileInfo fileinfo in Arquivos)
            {
                sr.WriteLine(fileinfo.Name);
                
            }
        }
    }
}
