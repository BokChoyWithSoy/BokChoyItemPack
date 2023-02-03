//using BepInEx.Configuration;
//using BokChoyItemPack.Items.Controllers;
//using BokChoyItemPack.Utils;
//using R2API;
//using RoR2;
//using System.Reflection;
//using UnityEngine;
//using static BokChoyItemPack.Main;

//namespace BokChoyItemPack.Items.Wave2
//{
//    public class Mukuro : ItemBase<Mukuro>
//    {
//        public override string ItemName => "Skull Pin";

//        public override string ItemLangTokenName => "MUKURO_SKULL";

//        public override string ItemPickupDesc => "";

//        public override string ItemFullDescription => "";

//        public override string ItemLore => "";

//        public override ItemTier Tier => ItemTier.Tier3;

//        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("MukuroSkullDisplay.prefab");

//        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Mukuro.png");

//        public override void Init(ConfigFile config)
//        {
//            CreateConfig(config);
//            CreateLang();
//            CreateItem();
//            Hooks();
//        }

//        public override void CreateConfig(ConfigFile config)
//        {
//            CreateLang();
//        }

//        public override ItemDisplayRuleDict CreateItemDisplayRules()
//        {
//            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("MukuroSkullPickup.prefab");
//            var itemDisplay = ItemBodyModelPrefab.AddComponent<ItemDisplay>();
//            itemDisplay.rendererInfos = ItemHelpers.ItemDisplaySetup(ItemBodyModelPrefab);

//            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();

//            rules.Add("mdlCommandoDualies", new ItemDisplayRule[]
//{
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Head",
//                    localPos = new Vector3(-0.02008F, 0.07771F, 0.04649F),
//                    localAngles = new Vector3(270F, 90F, 0F),
//                    localScale = new Vector3(21F, 15F, 15F)
//                }
//            });
//            rules.Add("mdlHuntress", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Head",
//                    localPos = new Vector3(0.00215F, 0.03171F, 0.01063F),
//                    localAngles = new Vector3(0F, 0F, 0F),
//                    localScale = new Vector3(1.5F, 1.5F, 1.5F)
//                }
//            });
//            rules.Add("mdlToolbot", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "UpperArmL",
//                    localPos = new Vector3(0.06362F, 3.11895F, -0.00353F),
//                    localAngles = new Vector3(357.1064F, 179.4894F, 180.4112F),
//                    localScale = new Vector3(10F, 13F, 10F)
//                }
//            });
//            rules.Add("mdlEngi", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Chest",
//                    localPos = new Vector3(-0.00059F, 0.43503F, 0.09059F),
//                    localAngles = new Vector3(0F, 0F, 0F),
//                    localScale = new Vector3(2F, 2.3F, 2.3F)
//                }
//            });
//            rules.Add("mdlMage", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Head",
//                    localPos = new Vector3(0.00715F, -0.09512F, 0.0161F),
//                    localAngles = new Vector3(0.05992F, 346.0045F, 359.84F),
//                    localScale = new Vector3(1F, 1F, 1F)
//                }
//            });
//            rules.Add("mdlMerc", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Head",
//                    localPos = new Vector3(0.00045F, -0.10752F, 0.03357F),
//                    localAngles = new Vector3(0F, 0F, 0F),
//                    localScale = new Vector3(1.5F, 2F, 1.8F)
//                }
//            });
//            rules.Add("mdlTreebot", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "FootBackL",
//                    localPos = new Vector3(0.01548F, 0.75085F, -0.00742F),
//                    localAngles = new Vector3(11.77976F, 46.5062F, 178.3706F),
//                    localScale = new Vector3(1.4F, 1.4F, 1.3F)
//                }
//            });
//            rules.Add("mdlLoader", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Head",
//                    localPos = new Vector3(0.00012F, -0.02171F, 0.0342F),
//                    localAngles = new Vector3(0F, 0F, 0F),
//                    localScale = new Vector3(1.4F, 1F, 1.6F)
//                }
//            });
//            rules.Add("mdlCroco", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "UpperArmR",
//                    localPos = new Vector3(0.31651F, 3.34172F, -0.33283F),
//                    localAngles = new Vector3(7.73062F, 165.8965F, 181.2848F),
//                    localScale = new Vector3(15F, 15F, 15F)
//                }
//            });
//            rules.Add("mdlCaptain", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Head",
//                    localPos = new Vector3(-0.00343F, -0.06697F, 0.06251F),
//                    localAngles = new Vector3(0F, 0F, 0F),
//                    localScale = new Vector3(1.5F, 1.5F, 1.5F)
//                }
//            });
//            rules.Add("mdlBandit2", new ItemDisplayRule[]
//            {
//                new ItemDisplayRule
//                {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Head",
//                    localPos = new Vector3(0.00324F, -0.06095F, 0.04272F),
//                    localAngles = new Vector3(0F, 0F, 0F),
//                    localScale = new Vector3(1.3F, 1.2F, 1.2F)
//                }
//            });
//            rules.Add("mdlRailGunner", new ItemDisplayRule[]{new ItemDisplayRule
//            {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "CalfL",
//                    localPos = new Vector3(0.01912F, 0.33807F, 0.01326F),
//                    localAngles = new Vector3(344.0036F, 90.03363F, 11.00515F),
//                    localScale = new Vector3(1F, 1F, 1F)
//                }
//            });
//            rules.Add("mdlVoidSurvivor", new ItemDisplayRule[]{new ItemDisplayRule
//            {
//                    ruleType = ItemDisplayRuleType.ParentedPrefab,
//                    followerPrefab = ItemBodyModelPrefab,
//                    childName = "Hand",
//                    localPos = new Vector3(0.00634F, -0.13051F, 0.0317F),
//                    localAngles = new Vector3(0F, 0F, 0F),
//                    localScale = new Vector3(1F, 1F, 1F)
//                }
//            });

//            return rules;
//        }

//        public override void Hooks()
//        {
//        }
//    }
//}
