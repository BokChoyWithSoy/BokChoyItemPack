using R2API;
using RoR2;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack
{
    public class Buffs : MonoBehaviour
    {
        public static BuffDef maskBuff;
        public static BuffDef screenBuff;

        public static void LoadBuffs()
        {
            CreateBuffs();
        }
        
        private static void CreateBuffs()
        {
            maskBuff = AddNewBuff("Mask Buff", MainAssets.LoadAsset<Sprite>("Cali.png"), true, false, true);
            screenBuff = AddNewBuff("Screen Buff", MainAssets.LoadAsset<Sprite>("Blue.png"), true, false, true);
        }

        internal static BuffDef AddNewBuff(string buffName, Sprite buffIcon, bool canStack, bool isDebuff, bool isHidden)
        {
            BuffDef buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = buffName;
            buffDef.canStack = canStack;
            buffDef.isDebuff = isDebuff;
            buffDef.eliteDef = null;
            buffDef.iconSprite = buffIcon;
            buffDef.isHidden = isHidden;

            ContentAddition.AddBuffDef(buffDef);

            return buffDef;
        }
    }
}