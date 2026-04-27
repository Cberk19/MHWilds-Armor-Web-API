using MHWilds_Armor_Web_API.Models;
using MongoDB.Driver;

namespace MHWilds_Armor_Web_API.Data
{
    public class ArmorData
    {
        //private static readonly string connectionString = "mongodb+srv://db_user1:FortniteBooty697!@testcluster.zco1x3w.mongodb.net/";
        private static readonly string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING" 
            ?? throw new InvalidOperationException("CONNECTION_STRING is not set"));

        public ArmorData()
        {

        }
        public static List<Armor> GetHelmets()
        {
            List<Armor> armorList = new List<Armor>();
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("Armor");
                var collection = database.GetCollection<Armor>("helmets");

                var filter = Builders<Armor>.Filter.Empty;



                using (var jawn = collection.Find<Armor>(filter).ToCursor())
                {
                    foreach (var item in jawn.ToEnumerable())
                    {
                        armorList.Add(item);
                        Console.WriteLine(item);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return armorList;
        }
        public static List<Armor> GetTorsos()
        {
            List<Armor> armorList = new List<Armor>();
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("Armor");
                var collection = database.GetCollection<Armor>("torsos");

                var filter = Builders<Armor>.Filter.Empty;



                using (var jawn = collection.Find<Armor>(filter).ToCursor())
                {
                    foreach (var item in jawn.ToEnumerable())
                    {
                        armorList.Add(item);
                        Console.WriteLine(item);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return armorList;
        }

        public static List<Armor> GetArmor()
        {
            List<Armor> armorList = new List<Armor>();
            try
            {
                armorList.AddRange(GetHelmets());
                armorList.AddRange(GetTorsos());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return armorList;
        }

        public static List<Armor> GetHelmetsBySkill(Skill skill)
        {
            List<Armor> armorList = new List<Armor>();
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("Armor");
                var collection = database.GetCollection<Armor>("helmets");

                var filter = Builders<Armor>.Filter.Eq("skills.name", skill.name);

                using (var jawn = collection.Find<Armor>(filter).ToCursor())
                {
                    foreach (var item in jawn.ToEnumerable())
                    {
                        armorList.Add(item);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return armorList;
        }

        public static List<Armor> GetTorsosBySkill(Skill skill)
        {
            List<Armor> armorList = new List<Armor>();
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("Armor");
                var collection = database.GetCollection<Armor>("torsos");

                var filter = Builders<Armor>.Filter.Eq("skills.name", skill.name);

                using (var jawn = collection.Find<Armor>(filter).ToCursor())
                {
                    foreach (var item in jawn.ToEnumerable())
                    {
                        armorList.Add(item);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return armorList;
        }

        public static List<Armor> GetArmorBySkill(Skill skill)
        {
            List<Armor> armorList = new List<Armor>();
            try
            {
                armorList.AddRange(GetHelmetsBySkill(skill));
                armorList.AddRange(GetTorsosBySkill(skill));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return armorList;
        }
    }
}
