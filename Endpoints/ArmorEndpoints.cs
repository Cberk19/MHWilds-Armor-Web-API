using MHWilds_Armor_Web_API.Data;
using MHWilds_Armor_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MHWilds_Armor_Web_API.Endpoints
{
    public static class ArmorEndpoints
    {
        public static void AddArmorEndpoints(this WebApplication app)
        {
            
            app.MapGet("/getHelmets", (ArmorData data) =>
            {
                return Data.ArmorData.GetHelmets();
            });

            app.MapGet("/getTorsos", (ArmorData data) =>
            {
                return Data.ArmorData.GetTorsos();
            });

            app.MapGet("/getArmor", (ArmorData data) =>
            {
                return Data.ArmorData.GetArmor();
            });

            app.MapGet("/getHelmetsBySkill{skill}", ([FromRoute] string skill, ArmorData data) =>
            {
                Skill temp = new Skill();
                temp.name = skill;
                return Data.ArmorData.GetHelmetsBySkill(temp);
            });

            app.MapGet("/getTorsosBySkill{skill}", ([FromRoute] string skill, ArmorData data) =>
            {
                Skill temp = new Skill();
                temp.name = skill;
                return Data.ArmorData.GetTorsosBySkill(temp);
            });

            app.MapGet("/getArmorBySkill{skill}", ([FromRoute] string skill, ArmorData data) =>
            {
                Skill temp = new Skill();
                temp.name = skill;
                return Data.ArmorData.GetArmorBySkill(temp);
            });
        }
    }
}
