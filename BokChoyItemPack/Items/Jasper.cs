using BepInEx.Configuration;
using BokChoyItemPack.Utils;
using R2API;
using R2API.Networking.Interfaces;
using RoR2;
using UnityEngine;
using WispMod.Modules.Networking;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items
{
    public class Jasper : ItemBase<Jasper>
    {
        public override string ItemName => "Bartender Tie";

        public override string ItemLangTokenName => "JASPER_TIE";

        public override string ItemPickupDesc => "";

        public override string ItemFullDescription => "";

        public override string ItemLore => "";

        public override ItemTier Tier => ItemTier.Tier1;

        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("JasperTieDisplay.prefab");

        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Jasper.png");

        public override void Init(ConfigFile config)
        {
            CreateConfig(config);
            CreateLang();
            CreateItem();
            Hooks();
        }

        public override void CreateConfig(ConfigFile config)
        {
            CreateLang();
        }

        public override ItemDisplayRuleDict CreateItemDisplayRules()
        {
            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("JasperTiePickup.prefab");
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
                    localPos = new Vector3(0.00046F, 0.006F, 0.23138F),
                    localAngles = new Vector3(325.9371F, 359.8319F, 0.12396F),
                    localScale = new Vector3(0.71432F, 1F, 1F)
                }
            });
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.06056F, -0.10049F, 0.14169F),
                    localAngles = new Vector3(352.3251F, 29.70493F, 351.7478F),
                    localScale = new Vector3(1.02906F, 1.21655F, 2.09218F)
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.24264F, 1.05105F, -2.08931F),
                    localAngles = new Vector3(278.1268F, 14.11348F, 164.5831F),
                    localScale = new Vector3(10.14159F, 15F, 10F)
                }
            });
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(0.01154F, 0.24602F, 0.2704F),
                    localAngles = new Vector3(346.1733F, 0.0112F, 359.9075F),
                    localScale = new Vector3(0.88497F, 1.45344F, 2F)
                }
            });
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00225F, -0.21518F, 0.18363F),
                    localAngles = new Vector3(335.8175F, 359.863F, 0.02548F),
                    localScale = new Vector3(0.55577F, 1.5F, 2F)
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
                    childName = "ClavicleL",
                    localPos = new Vector3(0.08032F, 0.59188F, -0.50553F),
                    localAngles = new Vector3(303.0591F, 125.2848F, 51.51829F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00007F, -0.2814F, 0.19076F),
                    localAngles = new Vector3(339.3887F, 359.8865F, 0.02129F),
                    localScale = new Vector3(1.22917F, 2F, 0.80785F)
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
                    localPos = new Vector3(-0.03149F, -0.31649F, 0.12962F),
                    localAngles = new Vector3(0.91342F, 327.6772F, 2.44034F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.11807F, -0.2418F, 0.03748F),
                    localAngles = new Vector3(340.9702F, 82.22382F, 351.5323F),
                    localScale = new Vector3(1.3F, 1.5F, 1.5F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00086F, -0.15316F, 0.08309F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1F, 1F, 1F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.06354F, -0.21217F, 0.35633F),
                    localAngles = new Vector3(317.47F, 335.6373F, 5.83164F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });

            return rules;
        }

        public override void Hooks()
        {
            On.RoR2.CharacterBody.OnInventoryChanged += SpawnMinion;
        }

        private void SpawnMinion(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody body)
        {
            new JasperMinionNetworkRequest(body.masterObjectId, body.transform.position, 0f).Send(R2API.Networking.NetworkDestination.Clients);
        }
    }
}
