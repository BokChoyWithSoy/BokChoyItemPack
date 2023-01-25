using BepInEx.Configuration;
using BokChoyItemPack.Utils;
using R2API;
using RoR2;
using RoR2.Projectile;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items
{
    public class Sol : ItemBase<Sol>
    {
        public override string ItemName => "Fox Eyes";

        public override string ItemLangTokenName => "SOL_EYES";

        public override string ItemPickupDesc => "Activating your Secondary skill also throws a exploding eyeball.";

        public override string ItemFullDescription => "Activating your <style=cIsUtility>Secondary skill</style> also throws an <style=cIsDamage>eyeball which explodes</style>, dealing <style=cIsDamage>200%</style> <style=cStack>(100% per stack)</style> base damage.";

        public override string ItemLore => "Mysterious eye. Not much known about it. Except it knows and sees. Careful not to throw it around too carelessly. An arm was all the was found of the last person that tried it :D";

        public override ItemTier Tier => ItemTier.Tier2;

        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("SolEyeDisplay.prefab");

        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Sol.png");

        public override ItemTag[] ItemTags => new ItemTag[1] { ItemTag.Damage };

        public static GameObject Projectile;

        public override void Init(ConfigFile config)
        {
            CreateConfig(config);
            CreateLang();
            CreateProjectile();
            CreateItem();
            Hooks();
        }

        public override void CreateConfig(ConfigFile config)
        {
            CreateLang();
        }

        private void CreateProjectile()
        {
            Projectile = PrefabAPI.InstantiateClone(RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Projectiles/mageFirebolt"), "eyeProjectile");

            ProjectileImpactExplosion projectileImpactExplosion = Projectile.GetComponent<ProjectileImpactExplosion>();

            var eyeExplosionEffect = VFX.VFX.ExplosionEffect;

            projectileImpactExplosion.impactEffect = eyeExplosionEffect;
            projectileImpactExplosion.blastRadius = 6f;
            projectileImpactExplosion.destroyOnEnemy = true;
            projectileImpactExplosion.lifetime = 12f;
            projectileImpactExplosion.timerAfterImpact = true;
            projectileImpactExplosion.lifetimeAfterImpact = 0f;
            projectileImpactExplosion.GetComponent<ProjectileDamage>().damageType = DamageType.Generic;
            projectileImpactExplosion.blastDamageCoefficient = 1f;
            projectileImpactExplosion.blastProcCoefficient = 1f;
            projectileImpactExplosion.bonusBlastForce = Vector3.zero;
            projectileImpactExplosion.destroyOnEnemy = false;
            projectileImpactExplosion.falloffModel = RoR2.BlastAttack.FalloffModel.None;
            projectileImpactExplosion.fireChildren = false;
            projectileImpactExplosion.lifetimeRandomOffset = 0f;
            projectileImpactExplosion.offsetForLifetimeExpiredSound = 0f;

            ProjectileController rockController = Projectile.GetComponent<ProjectileController>();
            GameObject ghostPrefab = MainAssets.LoadAsset<GameObject>("Eye.prefab");
            ghostPrefab.AddComponent<NetworkIdentity>();
            ghostPrefab.AddComponent<ProjectileGhostController>();
            rockController.ghostPrefab = ghostPrefab;

            ShakeEmitter shakeEmitter = eyeExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitter.amplitudeTimeDecay = true;
            shakeEmitter.duration = 0.5f;
            shakeEmitter.radius = 200f;
            shakeEmitter.scaleShakeRadiusWithLocalScale = false;

            PrefabAPI.RegisterNetworkPrefab(Projectile);
            ContentAddition.AddProjectile(Projectile);
        }

        public override ItemDisplayRuleDict CreateItemDisplayRules()
        {
            GameObject itemDisplayPrefab = PrefabAPI.InstantiateClone(new GameObject("eyeFollowPoint"), "eyeFollowPoint", false);
            itemDisplayPrefab.AddComponent<ItemDisplay>();
            itemDisplayPrefab.GetComponent<ItemDisplay>().rendererInfos = ItemHelpers.ItemDisplaySetup(itemDisplayPrefab);
            ItemFollower follower = itemDisplayPrefab.AddComponent<ItemFollower>();
            follower.followerPrefab = MainAssets.LoadAsset<GameObject>("SolEyePickup.prefab");
            follower.distanceDampTime = 0.15f;
            follower.distanceMaxSpeed = 20f;
            follower.targetObject = itemDisplayPrefab;
            var ItemBodyModelPrefab = itemDisplayPrefab;

            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();

            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]
{
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.50407F, 0.52629F, 0.05417F),
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
                    childName = "Chest",
                    localPos = new Vector3(0.3478F, 0.34813F, 0.33723F),
                    localAngles = new Vector3(354.9215F, 305.8669F, 2.7062F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(5.24465F, 4.27963F, 2.94829F),
                    localAngles = new Vector3(4.12093F, 350.3547F, 358.152F),
                    localScale = new Vector3(5F, 5F, 5F)
                }
            });
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.81561F, 0.19597F, -0.14833F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(4F, 4F, 4F)
                }
            });
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.59045F, 0.30802F, 0.02766F),
                    localAngles = new Vector3(359.9302F, 10.45833F, 1.32019F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.50952F, 0.4337F, 0.0235F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Base",
                    localPos = new Vector3(-1.94013F, 0.7869F, -1.0097F),
                    localAngles = new Vector3(279.2276F, 191.0649F, 169.9629F),
                    localScale = new Vector3(7F, 7F, 7F)
                }
            });
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.73186F, 0.41279F, 0.03966F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(7.1008F, 1.76311F, 2.69569F),
                    localAngles = new Vector3(308.8328F, 179.039F, 1.08281F),
                    localScale = new Vector3(5F, 5F, 5F)
                }
            });
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.61245F, 0.6059F, 0.42146F),
                    localAngles = new Vector3(358.769F, 29.72679F, 1.49985F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.24352F, 0.5509F, -0.43054F),
                    localAngles = new Vector3(351.5227F, 282.0768F, 9.50319F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.34276F, 0.10924F, -0.58982F),
                    localAngles = new Vector3(328.5874F, 301.0266F, 16.92865F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.66162F, 0.33654F, -0.41528F),
                    localAngles = new Vector3(327.8964F, 349.8671F, 19.4578F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });

            return rules;
        }

        public override void Hooks()
        {
            On.RoR2.CharacterBody.OnSkillActivated += FireProjectile;
        }

        private void FireProjectile(On.RoR2.CharacterBody.orig_OnSkillActivated orig, CharacterBody self, GenericSkill skill)
        {
            if(skill && self)
            {
                if (self.inventory && GetCount(self) > 0)
                {
                    if (skill.skillNameToken == self.skillLocator.secondary.skillNameToken)
                    {
                        float stackedDamage = 0;
                        if(GetCount(self) > 1)
                        {
                            stackedDamage = (self.damage * 1f) * GetCount(self);
                        }
                        ProjectileManager.instance.FireProjectile(
                        new FireProjectileInfo()
                        {
                            owner = self.gameObject,
                            damage = (self.damage * 2f) + stackedDamage,
                            position = self.corePosition,
                            rotation = Util.QuaternionSafeLookRotation(self.inputBank.aimDirection),
                            crit = self.RollCrit(),
                            projectilePrefab = Projectile
                        });
                    }
                }
            }
            orig(self, skill);
        }
    }
}
