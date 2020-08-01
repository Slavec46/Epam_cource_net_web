using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading;

namespace Task_4_1_1_File_Management_System
{
    public class Tracker : IDisposable
    {
        #region Variable

        private readonly string PathToCatalog;
        private const string PathForLog = @"C:\temp.xml";
        private bool flagSpy;
        private static XmlDocument document;
        public FileSystemWatcher fileWatcher;
        private DirectoryInfo dirInfo;
        private string dateTimeRestoration;
        private int dateTimeNegative;

        #endregion

        public Tracker(string pathToCatalog)
        {
            if (!Directory.Exists(pathToCatalog))
            {
                throw new DirectoryNotFoundException(pathToCatalog);
            }

            PathToCatalog = pathToCatalog;

            Console.WriteLine("Каталог под контролем...");
            Thread.Sleep(1500);
            OnSpy();

            if (flagSpy)
            {
                #region WriteStartElementInXmlFile

                try
                {
                    var xmlWriter = new XmlTextWriter(PathForLog, Encoding.UTF8)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4
                    };
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Spy");
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                #endregion
            }

            var temp = new FileInfo(PathForLog);
            if (temp.IsReadOnly)
                temp.IsReadOnly = false;

            document = new XmlDocument();
            document.Load(PathForLog);

            Subscribe();
        }

        private void Subscribe()
        {
            if (flagSpy)
            {
                dirInfo = new DirectoryInfo(PathToCatalog);
                fileWatcher = new FileSystemWatcher(dirInfo.FullName);

                fileWatcher.Changed += FileWatcherOnChanged;
                fileWatcher.Created += FileWatcherOnCreated;
                fileWatcher.Deleted += FileWatcherOnDeleted;
                fileWatcher.Renamed += FileWatcherOnRenamed;

                //fileWatcher.Filter = "*.txt"; // фильтр исключал каталоги((

                fileWatcher.EnableRaisingEvents = true;
            }
            else
            {
                Console.Clear();
                var temp = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                Console.WriteLine("Введите дату и/или время на которую \nнеобходимо сделать откат, вида \"{0}\" :", temp);
                dateTimeRestoration = Console.ReadLine();
                try
                {
                    dateTimeNegative = dateTimeRestoration.Length;

                    DateTime.Parse(dateTimeRestoration).ToString(CultureInfo.CurrentCulture);

                    Thread.Sleep(1500);

                    Console.Clear();
                    Console.WriteLine("Идет откат изменений...");

                    OnRestoration();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(1500);
                    Subscribe();
                }
            }
        }

        private void OnRestoration()
        {
            var restoration = new Restoration(dateTimeRestoration, 9);
            // Не смог получить доступ к времени удаления в корзине решил восстонавлвивать по дате(( понимаю что не так ...

            Console.WriteLine();
            Console.WriteLine("\tУдаленные файлы и/или папки восстановлены {0}...", restoration.list.Count);
            Console.WriteLine();

            dateTimeRestoration = dateTimeRestoration.Substring(0, dateTimeNegative);

            foreach (XmlElement element in document.DocumentElement.ChildNodes.Cast<XmlElement>().
                Where(element => element.Attributes[0].Value.
                                     Contains(dateTimeRestoration) && !element.Name. // Проверка на время редактирования
                                                                           Contains("elete")))
            // Удаленные элементы были восстановлены выше
            {
                Console.WriteLine("element: {0} - {1}", element.Name,
                                  element.Attributes.Count > 0 ? element.Attributes[0].Value : "null");
                foreach (XmlNode node in element)
                {
                    foreach (XmlNode el in node)
                    {
                        if (node.Name != "FullPath")
                        // Просто у этого элементы есть подэлементы и в итоге выводится мусор
                        {
                            Console.WriteLine("\t{0} - {1}", node.Name, node.InnerText);
                        }
                        foreach (XmlNode e in el)
                        {
                            Console.WriteLine("\t\t{0} - {1}", e.Name, e.InnerText);

                            if (e.InnerText.Contains(PathToCatalog) &&
                                (File.Exists(PathToCatalog) || Directory.Exists(PathToCatalog)))
                            {
                                if (element.Name.Contains("reated"))
                                {
                                    var tempInfo = new FileInfo(e.InnerText);
                                    tempInfo.Delete();
                                }
                                else
                                {
                                    bool f1 = File.Exists(e.InnerText);
                                    bool f2 = Directory.Exists(e.InnerText);
                                    bool f3 = element.Name.Contains("named");

                                    string path1 = el["FullPath"].InnerText;
                                    string path2 = string.Format("{0}{1}", (el["FullPath"].InnerText.Substring(0, el["FullPath"].InnerText.Length - element["NewName"].InnerText.Length)), element["OldName"].InnerText);

                                    if (f1 && f3)
                                    {
                                        File.Move(path1, path2);
                                    }
                                    else
                                    if (f2 && f3)
                                    {
                                        Directory.Move(path1, path2);
                                    }

                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Откат успешно завершен.");
        }

        #region ProcessingEvents

        private static void FileWatcherOnRenamed(object sender, RenamedEventArgs renamedEventArgs)
        {
            XmlAppendNewLog("Renamed",
                            renamedEventArgs.OldName,
                            renamedEventArgs.Name,
                            renamedEventArgs.ChangeType.ToString(),
                            renamedEventArgs.FullPath);

            Console.WriteLine("Remamed");
        }

        private static void FileWatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            XmlAppendNewLog("Deleted",
                            changeType: fileSystemEventArgs.ChangeType.ToString(),
                            fullPath: fileSystemEventArgs.FullPath,
                            name: fileSystemEventArgs.Name,
                            oldName: ""
                );

            Console.WriteLine("Deleted");
        }

        private static void FileWatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            XmlAppendNewLog("Created",
                            changeType: fileSystemEventArgs.ChangeType.ToString(),
                            fullPath: fileSystemEventArgs.FullPath,
                            name: fileSystemEventArgs.Name,
                            oldName: "");

            Console.WriteLine("Created");
        }

        private static void FileWatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            XmlAppendNewLog("Changed",
                            changeType: fileSystemEventArgs.ChangeType.ToString(),
                            fullPath: fileSystemEventArgs.FullPath,
                            name: fileSystemEventArgs.Name,
                            oldName: "");

            Console.WriteLine("Changed");
        }

        #endregion

        private void OnSpy()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tУстановить слежку / или перейти в режим отката  ? y/n");
                var keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    flagSpy = true;
                    Console.WriteLine("Включен режим слежки...");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }

                if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine();
                    flagSpy = false;
                    Console.WriteLine("Включен режим отката...");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }
            }
        }

        public static void XmlAppendNewLog(string eventName,
                                           string oldName,
                                           string name,
                                           string changeType,
                                           string fullPath)
        {

            if (File.Exists(fullPath))
            {
                var fileInfo = new FileInfo(fullPath);
                if (fileInfo.Extension != ".txt") return;
            }


            var element = document.CreateElement(eventName);
            document.DocumentElement.AppendChild(element);

            var attribute = document.CreateAttribute("DateTime");
            attribute.Value = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            element.Attributes.Append(attribute);

            if (oldName != "")
            {
                XmlNode subElement1 = document.CreateElement("OldName");
                subElement1.InnerText = oldName;
                element.AppendChild(subElement1);
            }

            if (name != "")
            {
                XmlNode subElement2 = document.CreateElement("NewName");
                subElement2.InnerText = name;
                element.AppendChild(subElement2);
            }

            if (fullPath != "")
            {
                var elementFullPath = document.CreateElement(Directory.Exists(fullPath) ? "Catalog" : "File");
                XmlNode subElement3 = document.CreateElement("FullInfo");

                element.AppendChild(subElement3).AppendChild(elementFullPath);

                #region DirectoryExist

                if (Directory.Exists(fullPath))
                {
                    XmlNode subElement3_1 = document.CreateElement("CreationTime");
                    subElement3_1.InnerText = Directory.GetCreationTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(subElement3_1);

                    XmlNode subElement3_2 = document.CreateElement("LastAccessTime");
                    subElement3_2.InnerText = Directory.GetLastAccessTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(subElement3_2);

                    XmlNode subElement3_3 = document.CreateElement("LastWriteTime");
                    subElement3_3.InnerText = Directory.GetLastWriteTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(subElement3_3);

                    XmlNode subElement3_4 = document.CreateElement("LogicalDrives");
                    subElement3_4.InnerText = Directory.GetLogicalDrives().ToString();
                    elementFullPath.AppendChild(subElement3_4);

                    var directoryInfo = new DirectoryInfo(fullPath);

                    XmlNode subElement3_5 = document.CreateElement("Name");
                    subElement3_5.InnerText = directoryInfo.Name;
                    elementFullPath.AppendChild(subElement3_5);

                    XmlNode subElement3_6 = document.CreateElement("Root");
                    subElement3_6.InnerText = directoryInfo.Root.ToString();
                    elementFullPath.AppendChild(subElement3_6);

                    XmlNode subElement3_7 = document.CreateElement("Parent");
                    subElement3_7.InnerText = directoryInfo.Parent.ToString();
                    elementFullPath.AppendChild(subElement3_7);

                    XmlNode subElement3_8 = document.CreateElement("Attributes");
                    subElement3_7.InnerText = directoryInfo.Attributes.ToString();
                    elementFullPath.AppendChild(subElement3_8);

                    XmlNode subElement3_9 = document.CreateElement("HashCode");
                    subElement3_9.InnerText = directoryInfo.GetHashCode().ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(subElement3_9);

                    XmlNode subElement3_10 = document.CreateElement("FullPath");
                    subElement3_10.InnerText = fullPath;
                    elementFullPath.AppendChild(subElement3_10);

                }
                #endregion

                #region FileExist

                else if (File.Exists(fullPath))
                {
                    XmlNode subElement3_1 = document.CreateElement("CreationTime");
                    subElement3_1.InnerText = File.GetCreationTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(subElement3_1);

                    XmlNode subElement3_2 = document.CreateElement("LastAccessTime");
                    subElement3_2.InnerText = File.GetLastAccessTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(subElement3_2);

                    XmlNode subElement3_3 = document.CreateElement("LastWriteTime");
                    subElement3_3.InnerText = File.GetLastWriteTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(subElement3_3);

                    var fileInfo = new FileInfo(fullPath);

                    XmlNode subElement3_4 = document.CreateElement("Extension");
                    subElement3_4.InnerText = fileInfo.Extension;
                    elementFullPath.AppendChild(subElement3_4);

                    XmlNode subElement3_5 = document.CreateElement("IsReadOnly");
                    subElement3_5.InnerText = fileInfo.IsReadOnly.ToString();
                    elementFullPath.AppendChild(subElement3_5);

                    XmlNode subElement3_6 = document.CreateElement("Length");
                    subElement3_6.InnerText = fileInfo.Length.ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(subElement3_6);

                    XmlNode subElement3_7 = document.CreateElement("FullPath");
                    subElement3_7.InnerText = fullPath;
                    elementFullPath.AppendChild(subElement3_7);
                }

                #endregion
            }

            if (changeType != "")
            {
                XmlNode subElement4 = document.CreateElement("ChangeType");
                subElement4.InnerText = changeType;
                element.AppendChild(subElement4);
            }
        }

        public void Dispose()
        {
            if (flagSpy)
            {
                document.Save(PathForLog);
            }

            var temp = new FileInfo(PathForLog);

            if (temp.IsReadOnly != true)
            {
                temp.IsReadOnly = true;
            }
        }
    }
}
