using BepInEx.Configuration;
using BokChoyItemPack.Items.Controllers;
using BokChoyItemPack.Utils;
using R2API;
using RoR2;
using System.Reflection;
using UnityEngine;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items
{
    public class Derrick : ItemBase<Derrick>
    {
        public override string ItemName => "Puppy Scarf";

        public override string ItemLangTokenName => "DERRICK_SCARF";

        public override string ItemPickupDesc => "<style=cIsUtility>Slightly increase base damage and armour</style>.";

        public override string ItemFullDescription => "Increase base damage by <style=cIsUtility>1</style> <style=cStack>(+1 per stack)</style> and armour by <style=cIsUtility>1</style> <style=cStack>(+1 per stack)</style>..";

        public override string ItemLore => "Feel the warmth of thy scarf and RAWR hehe";

        public override ItemTier Tier => ItemTier.Tier1;

        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("DerrickScarfDisplay.prefab");

        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Derrick.png");

        public override ItemTag[] ItemTags => new ItemTag[1] { ItemTag.Damage };

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
            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("DerrickScarfPickup.prefab");
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
                    localPos = new Vector3(-0.00008F, 0.03563F, 0.02467F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2.1F, 2F, 2F)
                }
            });
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00215F, 0.03171F, 0.01063F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.5F, 1.5F, 1.5F)  
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "UpperArmL",
                    localPos = new Vector3(0.06362F, 3.11895F, -0.00353F),
                    localAngles = new Vector3(357.1064F, 179.4894F, 180.4112F),
                    localScale = new Vector3(10F, 13F, 10F)
                }
            });
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.00059F, 0.43503F, 0.09059F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2.3F, 2.3F)
                }
            });
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00715F, -0.09512F, 0.0161F),
                    localAngles = new Vector3(0.05992F, 346.0045F, 359.84F),
                    localScale = new Vector3(1F, 1F, 1F)
                }
            });
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00045F, -0.10752F, 0.03357F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.5F, 2F, 1.8F)
                }
            });
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "FootBackL",
                    localPos = new Vector3(0.01548F, 0.75085F, -0.00742F),
                    localAngles = new Vector3(11.77976F, 46.5062F, 178.3706F),
                    localScale = new Vector3(1.4F, 1.4F, 1.3F)
                }
            });
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00012F, -0.02171F, 0.0342F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.4F, 1F, 1.6F)
                }
            });
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "UpperArmR",
                    localPos = new Vector3(0.31651F, 3.34172F, -0.33283F),
                    localAngles = new Vector3(7.73062F, 165.8965F, 181.2848F),
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
                    localPos = new Vector3(-0.00343F, -0.06697F, 0.06251F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.5F, 1.5F, 1.5F)
                }
            });
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00324F, -0.06095F, 0.04272F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.3F, 1.2F, 1.2F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "CalfL",
                    localPos = new Vector3(0.01912F, 0.33807F, 0.01326F),
                    localAngles = new Vector3(344.0036F, 90.03363F, 11.00515F),
                    localScale = new Vector3(1F, 1F, 1F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Hand",
                    localPos = new Vector3(0.00634F, -0.13051F, 0.0317F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1F, 1F, 1F)
                }
            });

            return rules;
        }

        public override void Hooks()
        {
            RecalculateStatsAPI.GetStatCoefficients += AddBuff;
        }

        private void AddBuff(CharacterBody self, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (self.inventory && GetCount(self) > 0)
            {
                args.baseDamageAdd += self.damage * (GetCount(self) * 0.01f);
            }
        }
    }
}
