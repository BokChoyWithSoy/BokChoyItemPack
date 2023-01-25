using BepInEx.Configuration;
using BokChoyItemPack.Items.Controllers;
using BokChoyItemPack.Utils;
using R2API;
using RoR2;
using UnityEngine;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items
{
    public class Cali : ItemBase<Cali>
    {
        public override string ItemName => "Mask of Plausible Deniability";

        public override string ItemLangTokenName => "CALI_MASK";

        public override string ItemPickupDesc => "Temporarily increase attack speed when attacking the same enemy.";

        public override string ItemFullDescription => "Temporarily increase attack speed by <style=cIsUtility>0.01%</style> <style=cStack>(0.01% per stack)</style> when attacking the same enemy.";

        public override string ItemLore => "";

        public override ItemTier Tier => ItemTier.Tier1;

        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("CaliMaskDisplay.prefab");

        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Cali.png");

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
            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("CaliMaskPickup.prefab");
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
                    localPos = new Vector3(-0.16252F, 0.26807F, 0.03364F),
                    localAngles = new Vector3(351.5074F, 270.2473F, 358.9519F),
                    localScale = new Vector3(12F, 12F, 12F)
                }
            });
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.10835F, 0.21099F, 0.03521F),
                    localAngles = new Vector3(349.6088F, 270.1852F, 17.03565F),
                    localScale = new Vector3(10F, 10F, 10F)
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(0.04177F, 0.84754F, 3.3571F),
                    localAngles = new Vector3(355.3048F, 355.1669F, 9.36942F),
                    localScale = new Vector3(100F, 100F, 100F)
                }
            });
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "MuzzleLeft",
                    localPos = new Vector3(-0.00059F, -0.18989F, -0.20413F),
                    localAngles = new Vector3(87.8506F, -0.00351F, -0.00364F),
                    localScale = new Vector3(20F, 20F, 20F)
                }
            });
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.09552F, 0.07127F, 0.01773F),
                    localAngles = new Vector3(359.8497F, 274.4516F, 359.3171F),
                    localScale = new Vector3(10F, 10F, 10F)
                }
            });
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.09571F, 0.17222F, 0.05742F),
                    localAngles = new Vector3(343.2863F, 273.6575F, 1.51722F),
                    localScale = new Vector3(10F, 10F, 10F)
                }
            });
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "FlowerBase",
                    localPos = new Vector3(0.19533F, 1.17015F, 0.37656F),
                    localAngles = new Vector3(356.0168F, 0F, 0.00001F),
                    localScale = new Vector3(30F, 30F, 30F)
                }
            });
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.11703F, 0.1565F, 0.02018F),
                    localAngles = new Vector3(340.8433F, 281.4026F, 356.0999F),
                    localScale = new Vector3(10F, 10F, 10F)
                }
            });
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00216F, 1.5904F, 1.39194F),
                    localAngles = new Vector3(349.5692F, 358.4866F, 179.807F),
                    localScale = new Vector3(100F, 100F, 100F)
                }
            });
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.01953F, 0.25053F, -0.00988F),
                    localAngles = new Vector3(300.9659F, 168.5096F, 179.6565F),
                    localScale = new Vector3(10F, 10F, 10F)
                }
            });
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00085F, 0.1965F, -0.03505F),
                    localAngles = new Vector3(294.3349F, 168.9082F, 356.8495F),
                    localScale = new Vector3(10F, 10F, 10F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.10518F, 0.10198F, -0.0227F),
                    localAngles = new Vector3(340.0681F, 75.95153F, 355.9662F),
                    localScale = new Vector3(10F, 10F, 10F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.17565F, 0.03278F, 0.02806F),
                    localAngles = new Vector3(9.54701F, 266.4821F, 55.24916F),
                    localScale = new Vector3(10F, 10F, 10F)
                }
            });

            return rules;
        }

        public override void Hooks()
        {
            On.RoR2.HealthComponent.TakeDamage += CheckTarget;
            RecalculateStatsAPI.GetStatCoefficients += AddBuffCalculate;
        }

        private void CheckTarget(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            orig(self, damageInfo);

            if(damageInfo.attacker)
            {
                if (damageInfo.attacker.GetComponent<CharacterBody>())
                {
                    if(damageInfo.attacker.GetComponent<CharacterBody>())
                    {
                        if (damageInfo.attacker.GetComponent<CharacterBody>().inventory && GetCount(damageInfo.attacker.GetComponent<CharacterBody>()) > 0)
                        {
                            MaskController maskController;
                            if (!damageInfo.attacker.gameObject.GetComponent<CharacterBody>().master.gameObject.GetComponent<MaskController>())
                            {
                                maskController = damageInfo.attacker.gameObject.GetComponent<CharacterBody>().master.gameObject.AddComponent<MaskController>();
                            }
                            else
                            {
                                maskController = damageInfo.attacker.gameObject.GetComponent<CharacterBody>().master.gameObject.GetComponent<MaskController>();
                            }

                            if (!maskController.GetCurrentTarget() || maskController.GetCurrentTarget() != self.gameObject.GetComponent<CharacterBody>())
                            {
                                maskController.SetCurrentTarget(self.gameObject.GetComponent<CharacterBody>());
                                maskController.resetCurrentHits();
                            }
                            else
                            {
                                maskController.IncrementCurrentHits();
                            }
                        }
                    }
                }
            }

            damageInfo.attacker.GetComponent<CharacterBody>().RecalculateStats();
        }

        private void AddBuffCalculate(CharacterBody self, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (self.inventory && GetCount(self) > 0)
            {
                MaskController maskController;
                if (!self.master.gameObject.GetComponent<MaskController>())
                {
                    maskController = self.master.gameObject.AddComponent<MaskController>();
                }
                else
                {
                    maskController = self.master.gameObject.GetComponent<MaskController>();
                }
                var buff = (0.01f * maskController.GetCurrentHits()) * GetCount(self);
                args.attackSpeedMultAdd += buff;
            }
        }
    }
}
