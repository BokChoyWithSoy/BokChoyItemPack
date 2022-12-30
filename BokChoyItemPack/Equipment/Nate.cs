using BepInEx.Configuration;
using BokChoyItemPack.Utils;
using R2API;
using RoR2;
using UnityEngine;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Equipment
{
    public class Nate : EquipmentBase
    {
        public override string EquipmentName => "Luscious Gnome Afro";

        public override string EquipmentLangTokenName => "NATE_AFRO";

        public override string EquipmentPickupDesc => "";

        public override string EquipmentFullDescription => "";

        public override string EquipmentLore => "";

        public override float Cooldown => 300;

        public override GameObject EquipmentModel => MainAssets.LoadAsset<GameObject>("NateAfroDisplay.prefab");

        public override Sprite EquipmentIcon => MainAssets.LoadAsset<Sprite>("Nate.png");

        public override void Init(ConfigFile config)
        {
            CreateConfig(config);
            CreateLang();
            CreateEquipment();
            Hooks();
        }

        protected override void CreateConfig(ConfigFile config)
        {

        }

        public override ItemDisplayRuleDict CreateItemDisplayRules()
        {
            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("NateAfroPickup.prefab");
            var itemDisplay = ItemBodyModelPrefab.AddComponent<ItemDisplay>();
            itemDisplay.rendererInfos = ItemHelpers.ItemDisplaySetup(ItemBodyModelPrefab);

            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();

            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]
{
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00032F, 0.13661F, 0.09281F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(3.0477F, 3.10744F, 2.78824F)
                }
            });
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00166F, 0.08541F, 0.00416F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2.45802F, 3F, 3F)
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.07314F, 2.8845F, 0.41208F),
                    localAngles = new Vector3(297.0275F, 179.998F, 359.8515F),
                    localScale = new Vector3(15F, 15F, 15F)
                }
            });
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.00086F, 0.46936F, 0.13165F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00693F, -0.01824F, -0.00885F),
                    localAngles = new Vector3(32.9002F, 0.19713F, 0.05783F),
                    localScale = new Vector3(1.77194F, 2.67186F, 3.04829F)
                }
            });
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00123F, -0.28774F, 0.18708F),
                    localAngles = new Vector3(345.9662F, 359.9387F, 0.00919F),
                    localScale = new Vector3(1.5F, 2F, 1.5F)
                }
            });
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "FlowerBase",
                    localPos = new Vector3(-0.07432F, 1.78561F, -0.16243F),
                    localAngles = new Vector3(2.66302F, 179.1156F, 179.9667F),
                    localScale = new Vector3(5F, 5F, 5F)
                }
            });
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00141F, 0.00198F, 0.04636F),
                    localAngles = new Vector3(14.98357F, 0.08102F, 0.01371F),
                    localScale = new Vector3(2.57926F, 2.68355F, 3F)
                }
            });
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.04315F, 5.78261F, -2.45363F),
                    localAngles = new Vector3(296.4661F, 357.8574F, 181.0335F),
                    localScale = new Vector3(20F, 20F, 20F)
                }
            });
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00172F, 0.02573F, 0.10293F),
                    localAngles = new Vector3(0.03374F, 350.4617F, 4.28059F),
                    localScale = new Vector3(2.15903F, 2.06026F, 2.46537F)
                }
            });
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00396F, 0.08673F, 0.05059F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.82388F, 1.97509F, 2.10335F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00172F, 0.02573F, 0.10293F),
                    localAngles = new Vector3(0.03374F, 350.4617F, 4.28059F),
                    localScale = new Vector3(2.15903F, 2.06026F, 2.46537F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.03627F, -0.03287F, 0.16465F),
                    localAngles = new Vector3(317.47F, 335.6373F, 5.83164F),
                    localScale = new Vector3(3.29986F, 4F, 4F)
                }
            });

            return rules;
        }

        protected override bool ActivateEquipment(EquipmentSlot slot)
        {
            return false;
        }


    }
}
