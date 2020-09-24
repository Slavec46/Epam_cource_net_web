using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using DAL.Interfaces;
using Common.Entities;
using System.Threading;

namespace DAL.Json
{
    public class BonusDao : IBonusDAO
    {
        private readonly string _folderName;
        private readonly string _fileExtension;
        private readonly string _folderPath;

        public BonusDao(string folderPath, string folderName = "Bonus_Json", string fileExtension = ".Json")
        {
            _folderPath = folderPath;
            _folderName = folderName;
            _fileExtension = fileExtension;

            CreateDirectory();
        }

        public Guid AddBonus(Bonus bonus)
        {
            using (var writer = AddJsonFile(bonus.Id))
            {
                writer.Write(JsonConvert.SerializeObject(bonus));
            }
            return bonus.Id;
        }

        public bool ChangeBonus(Bonus newBonus)
        {
            using (var writer = ChangeJsonFile(newBonus.Id))
            {
                writer.Write(JsonConvert.SerializeObject(newBonus));
            }

            return true;
        }

        public Bonus GetBonus(Guid id)
        {
            string jsonStr;

            using (var stream = GetJsonFileForReader(id))
            {
                jsonStr = stream.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Bonus>(jsonStr);
        }

        public IEnumerable<Bonus> GetAllBonus()
        {
            string path = Path.Combine(_folderPath, _folderName);
            string templateExtention = "*" + _fileExtension;

            foreach (var item in Directory.EnumerateFiles(path, templateExtention))
            {
                yield return GetBonus(Guid.Parse(Path.GetFileNameWithoutExtension(item)));
            }
        }

        public bool IsBonus(Guid id)
        {
            return IsJsonFile(id);
        }

        public bool DeleteBonus(Guid id)
        {
            DeleteJsonFile(id);

            return true;
        }

        /// 
        private TextWriter AddJsonFile(Guid id)
        {
            try
            {
                var stream = File.Open(
                    GetFilePath(id),
                    FileMode.CreateNew,
                    FileAccess.Write);

                return new StreamWriter(stream);
            }
            catch (IOException e)
            {
                throw new IOException("Json File has already been created!", e);
            }
            catch
            {
                Thread.Sleep(20);
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Open,
                                FileAccess.Write
                            );

                return new StreamWriter(stream);
            }
        }

        private TextWriter ChangeJsonFile(Guid id)
        {
            try
            {
                if (!IsJsonFile(id))
                {
                    throw new FileNotFoundException("Json file wasn't found!");
                }

                var stream = File.Open(
                    GetFilePath(id),
                    FileMode.Create,
                    FileAccess.Write);

                return new StreamWriter(stream);
            }
            catch (FileNotFoundException e)
            {
                throw new IOException("Json file not found!", e);
            }
            catch
            {
                Thread.Sleep(20);
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Open,
                                FileAccess.Write
                            );

                return new StreamWriter(stream);
            }
        }

        private void DeleteJsonFile(Guid id) 
        {
            try
            {
                File.Delete(GetFilePath(id));
            }
            catch (IOException e)
            {
                throw new IOException("Failed to delete file!", e);
            }
        }

        private string GetFilePath(Guid id)
        {
            return Path.Combine(_folderPath, _folderName, id.ToString() + _fileExtension);
        }

        private bool IsJsonFile(Guid id)
        {
            return File.Exists(GetFilePath(id));
        }

        private TextReader GetJsonFileForReader(Guid id)
        {
            try
            {
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Open,
                                FileAccess.Read
                            );

                return new StreamReader(stream);
            }
            catch (FileNotFoundException e)
            {
                throw new IOException("Data retrieval error!", e);
            }
            catch
            {
                Thread.Sleep(20);
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Open,
                                FileAccess.Read
                            );

                return new StreamReader(stream);
            }
        }

        private TextWriter GetJsonFileForWrite(Guid id)
        {
            try
            {
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Open,
                                FileAccess.Write
                            );

                return new StreamWriter(stream);
            }
            catch (FileNotFoundException e)
            {
                throw new IOException("Data retrieval error!", e);
            }
            catch
            {
                Thread.Sleep(20);
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Open,
                                FileAccess.Write
                            );

                return new StreamWriter(stream);
            }
        }

        private void CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(_folderPath, _folderName));
            }
            catch (IOException e)
            {
                throw new IOException("Storage " + _folderName + " is damaged!", e);
            }
        }
    }
}
