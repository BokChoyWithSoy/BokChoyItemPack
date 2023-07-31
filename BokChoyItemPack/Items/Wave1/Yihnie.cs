using BepInEx.Configuration;
using BokChoyItemPack.Items.Controllers;
using BokChoyItemPack.Utils;
using R2API;
using R2API.Networking.Interfaces;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items.Wave1
{
    public class Yihnie : ItemBase<Yihnie>
    {
        public override string ItemName => "FUCK Hat";

        public override string ItemLangTokenName => "YIHNIE_HAT";

        public override string ItemPickupDesc => "<style=cIsUtility>Doubles your damage...</style> <style=cDeath>BUT has a chance to fucking kill you</style>.";

        public override string ItemFullDescription => "Increase base Damage by <style=cIsUtility>100%</style> <style=cStack>(+100% per stack)</style>. <style=cDeath>There is a 20% chance</style> <style=cStack>(+5% per stack)</style> <style=cDeath>this item fucking kills you</style>.";

        public override string ItemLore => "fuck hat \r\n \r\n www.twitch.tv/yihnie";

        public override ItemTier Tier => ItemTier.Lunar;

        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("YihnieHatPickup.prefab");

        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Yihnie.png");

        public static GameObject itemBodyModelPrefab;

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
            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("YihnieHatDisplay.prefab");
            var itemDisplay = ItemBodyModelPrefab.AddComponent<RoR2.ItemDisplay>();
            itemDisplay.rendererInfos = ItemHelpers.ItemDisplaySetup(ItemBodyModelPrefab);

            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();

            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]
{
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00098F, 0.29943F, 0.06347F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00147F, 0.26512F, 0.0039F),
                    localAngles = new Vector3(344.8985F, 359.9485F, 0.02729F),
                    localScale = new Vector3(2F, 2F, 2.5F)
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00182F, 2.67212F, 0.80516F),
                    localAngles = new Vector3(294.0955F, 175.4067F, 1.39609F),
                    localScale = new Vector3(20F, 20F, 20F)
                }
            });
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.00043F, 0.69639F, 0.06464F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00081F, 0.15649F, 0.00137F),
                    localAngles = new Vector3(18.10128F, 0.10432F, 0.02039F),
                    localScale = new Vector3(1.5F, 1.5F, 1.5F)
                }
            });
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00092F, 0.21943F, 0.05259F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Eye",
                    localPos = new Vector3(-0.00081F, 0.78691F, -0.13864F),
                    localAngles = new Vector3(279.2276F, 191.0649F, 169.9629F),
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
                    localPos = new Vector3(-0.00105F, 0.19995F, 0.02278F),
                    localAngles = new Vector3(343.5126F, 359.9109F, 0.01311F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.01861F, -0.01737F, 0.89526F),
                    localAngles = new Vector3(290.4032F, 343.2201F, 193.0577F),
                    localScale = new Vector3(30F, 30F, 39F)
                }
            });
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.01452F, 0.19779F, 0.0321F),
                    localAngles = new Vector3(312.3539F, 359.1068F, 355.2534F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0F, 0F, 0F),
                    localAngles = new Vector3(0F, 0F, 0),
                    localScale = new Vector3(1F, 1F, 1F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00004F, 0.14242F, 0.01064F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2F, 2.5F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.03888F, 0.14606F, 0.00377F),
                    localAngles = new Vector3(337.2678F, 0.31544F, 10.15722F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });

            return rules;
        }

        public override void Hooks()
        {
            On.RoR2.CharacterBody.OnInventoryChanged += DeathCheck;
            RecalculateStatsAPI.GetStatCoefficients += AddBuff;
        }

        private void DeathCheck(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig(self);

            if(self)
            {
                var inventorycount = GetCount(self);
                if (self.inventory && inventorycount > 0)
                {
                    float deathcheck = Random.Range(0, 10);
                    HatController hatController;
                    if (!self.gameObject.GetComponent<HatController>())
                    {
                        hatController = self.gameObject.AddComponent<HatController>();
                    }
                    else
                    {
                        hatController = self.gameObject.GetComponent<HatController>();
                    }

                    if ((deathcheck < 2f + (inventorycount * 0.5f) && hatController.getCurrentStack() < GetCount(self)) || self.baseNameToken == "BROTHER_BODY_NAME")
                    {
                        self.healthComponent.Suicide();
                    }
                    hatController.setCurrentStack(GetCount(self));
                    self.RecalculateStats();
                }
            }
        }

        private void AddBuff(CharacterBody self, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (self.inventory && GetCount(self) > 0)
            {
                args.damageMultAdd += Mathf.Pow(2f, GetCount(self)) - 1f; ;
            }
        }
    }
}
