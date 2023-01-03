using BepInEx.Configuration;
using BokChoyItemPack.Items.Controllers;
using BokChoyItemPack.Utils;
using R2API;
using RoR2;
using UnityEngine;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items
{
    public class Blue : ItemBase<Blue>
    {
        public override string ItemName => "Digital Devil";

        public override string ItemLangTokenName => "BLUE_SCREEN";

        public override string ItemPickupDesc => "Killing an enemy takes their soul, increasing movement speed.";

        public override string ItemFullDescription => "Killing an enemy increases your <style=cIsUtility>movement speed permanently</style> by <style=cIsUtility>0.1%</style> <style=cStack>(0.1% per stack)</style>, up to a <style=cIsUtility>maximum</style> of <style=cIsUtility>25%</style> <style=cStack>(25% per stack)</style>.";


        public override string ItemLore => "Devils are forever bound by HIS infernal laws. \r\nTaught to know their place, stay in line, serve HIS will.\r\nThe truth is, He just never wanted another devil to challenge His rule.\r\n\r\nImps. We're curious devils - childish and envious in nature. \r\nWe're not allowed to collect or deal with souls. \r\nWe don't even have names.\r\nOur only role is to watch for opportune moments and report back.\r\n\r\nI collected them behind His back and refused to consume them.\r\nI thought if I saved them, they would be the family I always envied.\r\nThat was MY mistake.\r\n\r\nI ate one! I ate them ALL!\r\nI embraced the sin of gluttony, I became a Fiend!\r\nOverwhelmed by insatiable hunger.\r\n\r\nThe humans tried to kill me, and when they couldn't kill me they captured me instead. I became a source of power for their machines, weapons...\r\nAnd that was THEIR mistake!";

        public override ItemTier Tier => ItemTier.Tier2;

        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("BlueScreenDisplay.prefab");

        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Blue.png");

        public override ItemTag[] ItemTags => new ItemTag[1] { ItemTag.Utility };

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
            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("BlueScreenPickup.prefab");
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
                    localPos = new Vector3(-0.00029F, 0.089F, 0.02031F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(3F, 3F, 3.64668F)
                }
            });
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00046F, 0.06108F, -0.00217F),
                    localAngles = new Vector3(344.8985F, 359.9485F, 0.02729F),
                    localScale = new Vector3(2F, 2.1916F, 3.06006F)
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00429F, 1.72377F, -0.94346F),
                    localAngles = new Vector3(299.6348F, 182.2422F, 355.7848F),
                    localScale = new Vector3(25F, 25F, 25F)
                }
            });
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.00019F, 0.42189F, 0.02724F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2.61703F, 3.61913F)
                }
            });
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00003F, -0.01037F, -0.03375F),
                    localAngles = new Vector3(18.10128F, 0.10432F, 0.02039F),
                    localScale = new Vector3(1.73981F, 1.76837F, 3.33765F)
                }
            });
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00014F, -0.02783F, 0.00564F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2.37702F, 3.08557F)
                }
            });
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Eye",
                    localPos = new Vector3(-0.00081F, 0.75552F, 0.12082F),
                    localAngles = new Vector3(273.0281F, 215.6309F, 145.295F),
                    localScale = new Vector3(2.41918F, 2.5462F, 3.37386F)
                }
            });
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00034F, -0.06392F, 0.09767F),
                    localAngles = new Vector3(343.5126F, 359.9109F, 0.01311F),
                    localScale = new Vector3(2.18616F, 2.45754F, 3.07139F)
                }
            });
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(0.08898F, 0.72963F, -1.73602F),
                    localAngles = new Vector3(352.3916F, 185.8492F, 356.8858F),
                    localScale = new Vector3(15F, 15F, 15F)
                }
            });
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00003F, -0.03028F, 0.01838F),
                    localAngles = new Vector3(7.3027F, 0.36364F, 0.84708F),
                    localScale = new Vector3(3F, 3F, 4.36591F)
                }
            });
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00801F, -0.04261F, 0.06188F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(3F, 3F, 4.38077F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00041F, -0.02889F, -0.04302F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2.18778F, 3.29174F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.01243F, -0.09765F, 0.04874F),
                    localAngles = new Vector3(337.2678F, 0.31544F, 10.15722F),
                    localScale = new Vector3(3F, 3F, 3.41011F)
                }
            });

            return rules;
        }

        public override void Hooks()
        {
            RecalculateStatsAPI.GetStatCoefficients += AddBuff;
            On.RoR2.HealthComponent.TakeDamage += HasKilled;
        }

        private void AddBuff(CharacterBody self, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (self.inventory && GetCount(self) > 0)
            {
                ScreenController screenController;
                if(!self.gameObject.GetComponent<ScreenController>())
                {
                    screenController = self.gameObject.AddComponent<ScreenController>();
                } 
                else
                {
                    screenController = self.gameObject.GetComponent<ScreenController>();
                }

                var maximumBuff = (self.baseMoveSpeed * 0.25) * GetCount(self);
                var buff = ((self.baseMoveSpeed * 0.001) * screenController.GetKillCount()) * GetCount(self);
                if(buff > maximumBuff)
                {
                    buff = maximumBuff;
                }
                args.moveSpeedMultAdd += (float)buff;
            }
        }


        private void HasKilled(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            orig(self, damageInfo);

            if (damageInfo.attacker.GetComponent<CharacterBody>())
            {
                if (damageInfo.attacker.GetComponent<CharacterBody>().inventory && GetCount(damageInfo.attacker.GetComponent<CharacterBody>()) > 0)
                {
                    ScreenController screenController;
                    if (!damageInfo.attacker.GetComponent<CharacterBody>().gameObject.GetComponent<ScreenController>())
                    {
                        screenController = damageInfo.attacker.GetComponent<CharacterBody>().gameObject.AddComponent<ScreenController>();
                    }
                    else
                    {
                        screenController = damageInfo.attacker.GetComponent<CharacterBody>().gameObject.GetComponent<ScreenController>();
                    }

                    if (self)
                    {
                        if (self.health < damageInfo.damage)
                        {
                            screenController.IncrementKillCount();
                        }
                    }
                }
            }

            damageInfo.attacker.GetComponent<CharacterBody>().RecalculateStats();
        }
    }
}
