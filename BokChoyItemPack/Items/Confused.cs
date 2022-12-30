using BepInEx.Configuration;
using BokChoyItemPack.Utils;
using R2API;
using R2API.Networking;
using R2API.Networking.Interfaces;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items
{
    public class Confused : ItemBase<Confused>
    {
        public override string ItemName => "Confused and Crazy";

        public override string ItemLangTokenName => "CONFUSED_CRAZY";

        public override string ItemPickupDesc => "Increase the number of interactables per stage... <style=cDeath>BUT speed up difficulty scaling</style>.";

        public override string ItemFullDescription => "Increase the <style=cIsUtility>number of interactables</style> per stage by <style=cIsUtility>15%</style> <style=cStack>(15% per stack)</style>. <style=cDeath>Increase difficulty scaling by 15%</style> <style=cStack>(5% per stack)</style>.";

        public override string ItemLore => "";

        public override ItemTier Tier => ItemTier.Lunar;

        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("ConfusedFaceDisplay.prefab");

        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Confused.png");

        public override ItemTag[] ItemTags => new ItemTag[1] { ItemTag.AIBlacklist };

        public static float extraDifficultyTime = 0f;
        public static bool calculatingDifficultyCoefficient = false;
        public static int totalItemCount = 0;
        public static float onlineSyncTimer = 0f;
        public static float onlineSyncDuration = 60f;

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
            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("ConfusedFacePickup.prefab");
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
                    localPos = new Vector3(-0.01863F, 0.2443F, 0.18189F),
                    localAngles = new Vector3(0F, 180F, 0F),
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
                    localPos = new Vector3(0.00281F, 0.21313F, 0.11369F),
                    localAngles = new Vector3(344.8985F, 359.9485F, 0.02729F),
                    localScale = new Vector3(2.5F, 2.5F, 2.5F)
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.13803F, 3.47065F, -0.68655F),
                    localAngles = new Vector3(304.0519F, 171.3752F, 2.36194F),
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
                    localPos = new Vector3(0.02085F, 0.52908F, 0.17084F),
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
                    localPos = new Vector3(0.01515F, 0.03944F, 0.11293F),
                    localAngles = new Vector3(353.5081F, 359.9777F, 0.00917F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.01274F, 0.10753F, 0.16558F),
                    localAngles = new Vector3(348.6611F, 359.9515F, 0.00356F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Eye",
                    localPos = new Vector3(0.02408F, 0.84709F, 0.03569F),
                    localAngles = new Vector3(273.0476F, 308.7502F, 57.25411F),
                    localScale = new Vector3(7F, 7F, 7F)
                }
            });
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.02132F, 0.07169F, 0.11884F),
                    localAngles = new Vector3(357.4632F, 359.9868F, 0.00104F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.20601F, 1.52408F, 1.2463F),
                    localAngles = new Vector3(10.41218F, 353.6105F, 176.5758F),
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
                    localPos = new Vector3(-0.00292F, 0.04913F, 0.13044F),
                    localAngles = new Vector3(359.0236F, 354.7773F, 7.93179F),
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
                    localPos = new Vector3(0.01363F, 0.01337F, 0.12611F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00004F, 0.07467F, 0.10872F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2F, 2.5F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.01527F, 0.06843F, 0.14791F),
                    localAngles = new Vector3(337.2678F, 0.31544F, 10.15722F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });

            return rules;
        }

        public override void Hooks()
        {
            On.RoR2.Run.Start += StartRun;
            On.RoR2.Run.RecalculateDifficultyCoefficentInternal += RecalculateDifficulty;
            On.RoR2.Run.GetRunStopwatch += ScaleDifficulty;
            On.RoR2.Run.FixedUpdate += AddDifficulty;
            SceneDirector.onPrePopulateSceneServer += IncreaseInteractables;
            On.RoR2.CharacterBody.OnInventoryChanged += InventoryChanged;
        }

        private void StartRun(On.RoR2.Run.orig_Start orig, Run self)
        {
            orig(self);
            extraDifficultyTime = 0f;
        }

        private void RecalculateDifficulty(On.RoR2.Run.orig_RecalculateDifficultyCoefficentInternal orig, Run self)
        {
            calculatingDifficultyCoefficient = true;
            orig(self);
            calculatingDifficultyCoefficient = false;
        }

        private float ScaleDifficulty(On.RoR2.Run.orig_GetRunStopwatch orig, Run self)
        {
            return orig(self) + (calculatingDifficultyCoefficient ? extraDifficultyTime : 0);
        }

        private void AddDifficulty(On.RoR2.Run.orig_FixedUpdate orig, Run self)
        {
            orig(self);
            if (totalItemCount > 0)
            {
                if (!self.isRunStopwatchPaused)
                    extraDifficultyTime += Time.fixedDeltaTime * (15f / 100f) + (5f / 100f * (float)(totalItemCount - 1));

                if (NetworkServer.active)
                {
                    onlineSyncTimer -= Time.fixedDeltaTime;
                    if (onlineSyncTimer <= 0f)
                    {
                        onlineSyncTimer = onlineSyncDuration;
                        new SyncTimer(extraDifficultyTime).Send(NetworkDestination.Clients);
                    }
                }
            }
        }

        private void IncreaseInteractables(SceneDirector obj)
        {
            int itemCount = 0;
            foreach (var player in PlayerCharacterMasterController.instances)
            {
                itemCount += player.master.inventory.GetItemCount(ItemBase<Confused>.instance.ItemDef);
                if (itemCount > 0)
                {
                    float creditMult = 0.2f * (float)itemCount;
                    obj.interactableCredit = (int)(obj.interactableCredit * creditMult);
                }
            }
        }

        private void InventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, RoR2.CharacterBody self)
        {
            orig(self);

            int newTotalItemCount = 0;
            for (int team = 0; team < (int)TeamIndex.Count; team++)
            {
                newTotalItemCount += Util.GetItemCountForTeam((TeamIndex)team, ItemBase<Confused>.instance.ItemDef.itemIndex, true);
            }
            if (totalItemCount > 0 && newTotalItemCount == 0 && NetworkServer.active)
            {
                new SyncTimer(extraDifficultyTime).Send(NetworkDestination.Clients);
            }
            totalItemCount = newTotalItemCount;
        }

        public class SyncTimer : INetMessage
        {
            float time;

            public SyncTimer()
            {
            }

            public SyncTimer(float time)
            {
                this.time = time;
            }

            public void Deserialize(NetworkReader reader)
            {
                time = reader.ReadSingle();
            }

            public void OnReceived()
            {
                if (NetworkServer.active) return;
                extraDifficultyTime = time;
            }

            public void Serialize(NetworkWriter writer)
            {
                writer.Write(time);
            }
        }
    }
}
