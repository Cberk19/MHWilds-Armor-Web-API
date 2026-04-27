using MongoDB.Bson;

namespace MHWilds_Armor_Web_API.Models
{
    public class Skill
    {
        public string? name { get; set; }
        public int level { get; set; }
        public int? maxValue { get; set; }

        public override string ToString()
        {
            return $"{name ?? "N/A"} {level}";
        }
    }

    public class Armor
    {
        public ObjectId _id { get; set; }
        public int setId { get; set; }
        public int pieceId { get; set; }
        public int rarity { get; set; }
        public string name { get; set; }
        public Skill[] skills { get; set; }
        public int[] slots { get; set; }
        public Skill[] setBonus { get; set; }
        public int defense { get; set; }
        public int fireRes { get; set; }
        public int waterRes { get; set; }
        public int thunderRes { get; set; }
        public int iceRes { get; set; }
        public int dragonRes { get; set; }

        public override string ToString()
        {
            var skillsList = "";
            foreach (var skill in skills)
            {
                skillsList += $"\n  - {skill}";
            }

            var setBonusList = "";
            foreach (var skill in setBonus)
            {
                setBonusList += $"\n  - {skill}";
            }

            string output = "";
            output += $"_id: {_id} \n" +
                $"setId: {setId} \n" +
                $"pieceId: {pieceId} \n" +
                $"rarity: {rarity} \n" +
                $"name: {name} \n" +
                $"skills: {skillsList} \n" +
                $"slots: {slots[0]} {slots[1]} {slots[2]} \n" +
                $"setBonus: {setBonusList} \n" +
                $"defense: {defense} \n" +
                $"fireRes: {fireRes} \n" +
                $"waterRes: {waterRes} \n" +
                $"thunderRes: {thunderRes} \n" +
                $"iceRes: {iceRes} \n" +
                $"dragonRes: {dragonRes} \n" +
                $"\n";
            return output;
        }
    }
}

/*namespace MHWilds_Armor_Web_API
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}*/
