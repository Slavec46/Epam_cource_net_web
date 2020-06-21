using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_GameDev.Map
{
    public class LocationMap
    {
        public List<List<MapCell>> MapCells { get; set; } = new List<List<MapCell>>();

        /// <summary>
        /// Создать карту m x n со случайными клетками
        /// </summary>
        /// <param name="m">Ширина карты в клетках</param>
        /// <param name="n">Длина карты в клетках</param>
        /// <remarks>Можнд добавить сколько угодно измерений и многомерную геометрию.
        /// Это весьма эффектно смотрится и эффективно выносит мозг.</remarks>
        public void FillMap(int m = 4, int n = 4) 
        {
            for (int i = 0; i < m; i++)
            {
                var mapRow = new List<MapCell>();
                
                for (int j = 0; j < n; j++)
                {
                    var cell = MapCellFactory.GerRandomCell();
                    mapRow.Add(cell);
                }

                MapCells.Add(mapRow);
            }
        }

        public void SaveMap(string savePath = "MyMap.json")
        {
            var mapJson = JsonConvert.SerializeObject(MapCells);
            File.WriteAllText(savePath,mapJson);
        }

        public void LoadMap(string loadPath = "MyMap.json")
        {
            try
            {
                var mapJson = File.ReadAllText(loadPath);
                MapCells = JsonConvert.DeserializeObject<List<List<MapCell>>>(mapJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something wrong: {ex.Message}");
            }
        }
    }
}
