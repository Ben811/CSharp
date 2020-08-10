using System.Collections.Generic;
using System.IO;

namespace Chrome_dino_v2.Model
{
    public class FileModel
    {
        private const string GameDirectory = "../../../SavedGames";
        private const string GameFileSuffix = ".game";

        public static FileModel GetModel
        {
            get
            {
                if (instance == null)
                    instance = new FileModel();
                return instance;
            }

        }

        private static FileModel instance;
        private List<string> savedGames;
        public int Index => savedGames.Count;
        

        private FileModel()
        {            
            savedGames = LoadSavedGames();            
        }

        public List<string> LoadSavedGames()
        {
            List<string> saves = new List<string>();
            var games = Directory.GetFiles(GameDirectory, "*.game");            
            foreach (var item in games)
            {
                saves.Add(item.Replace(GameDirectory + "\\", "").Replace(".game", ""));
            }

            return saves;
        }

        public void SaveEntities(List<IEntity> entities)
        {
            StreamWriter stream = new StreamWriter(GameDirectory + $"/Save_n{Index}.game");

            stream.WriteLine($"{entities.Count}");

            foreach (var item in entities)
            {
                stream.WriteLine($"{(int)item.Type} {(int)item.X} {(int)item.Y} {item.Hitbox.Width.ToString()} {item.Hitbox.Height.ToString()}");
            }
            stream.Close();
            savedGames = LoadSavedGames();
        }

        public List<IEntity> LoadEntities(string filename)
        {
            List<IEntity> entities = new List<IEntity>();
            StreamReader stream = new StreamReader(GameDirectory + "/" + filename + GameFileSuffix);

            int count = int.Parse(stream.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] data = stream.ReadLine().Split(" ");

                ElementType type = (ElementType)int.Parse(data[0]);
                double x = int.Parse(data[1]);
                double y = int.Parse(data[2]);
                double width = int.Parse(data[3]);
                double height = int.Parse(data[4]);

                if (type == ElementType.ENEMY)
                    entities.Add(new EnemyV2(height, width) { X = x, Y = y });
                else if (type == ElementType.OBSTACLE)
                    entities.Add(new Obstacle(height, width) { X = x, Y = y });
            }

            stream.Close();
            return entities;
        }

    }
}
