using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Shell32;

namespace Task_4_1_1_File_Management_System
{
    public class Restoration
    {
        public readonly List<FolderItem2> list;

        public Restoration(string dateTime, int dateTimeNegative)
        {
            var shell = new Shell();
            list = new List<FolderItem2>();

            Folder recypleBin = shell.NameSpace(10);

            foreach (FolderItem2 f in from FolderItem2 f in recypleBin.Items()
                                      where f.ModifyDate.ToString(CultureInfo.CurrentCulture).Contains(dateTime.Substring(0, dateTimeNegative))
                                      where f.Type == "Текстовый документ" || f.Type == "Папка с файлами"
                                      select f)
            {
                list.Add(f);
                foreach (var folderItemVerb in
                    f.Verbs().Cast<FolderItemVerb>().Where(folderItemVerb => folderItemVerb.Name.ToUpper().Contains("estore".ToUpper()) || folderItemVerb.Name.ToUpper().Contains("тановить".ToUpper())))
                {
                    folderItemVerb.DoIt();
                    Console.WriteLine(f.Name + " - \t Восстановлен");
                }
            }
            Marshal.FinalReleaseComObject(shell);
        }
    }
}