using BepInEx.Configuration;
using BokChoyItemPack.Utils;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using static BokChoyItemPack.Main;
using RoR2.Projectile;
using BokChoyItemPack.Items.Controllers;

namespace BokChoyItemPack.Items
{
    public class Kise : ItemBase<Kise>
    {
        public override string ItemName => "Normal Rocks";

        public override string ItemLangTokenName => "KISE_ROCK";

        public override string ItemPickupDesc => "Summon falling rocks which explode on taking damage.";

        public override string ItemFullDescription => "Every 10 seconds, getting hit causes exploding rocks to fall from the sky, dealing <style=cIsUtility>800% damage each</style>. Summons <style=cIsUtility>3 rocks</style> <style=cStack>(+2 per stack)</style> with a <style=cIsUtility>10m</style> radius.";

        public override string ItemLore => "Debris from [ ? ? ? ]. A grim reminder of the past so that you will never forget again.";

        public override ItemTier Tier => ItemTier.Tier3;

        public override GameObject ItemModel => MainAssets.LoadAsset<GameObject>("KiseRockDisplay.prefab");

        public override Sprite ItemIcon => MainAssets.LoadAsset<Sprite>("Kise.png");

        public static GameObject Projectile;

        public override ItemTag[] ItemTags => new ItemTag[1] { ItemTag.Damage };

        public bool hasFired;

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
            Projectile = PrefabAPI.InstantiateClone(RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Projectiles/mageFirebolt"), "rockProjectile");
            
            ProjectileImpactExplosion projectileImpactExplosion = Projectile.GetComponent<ProjectileImpactExplosion>();

            var rockExplosionEffect = VFX.VFX.ExplosionEffect;

            projectileImpactExplosion.impactEffect = rockExplosionEffect;
            projectileImpactExplosion.blastRadius = 10f;
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
            GameObject ghostPrefab = MainAssets.LoadAsset<GameObject>("Rocks.prefab");
            ghostPrefab.AddComponent<NetworkIdentity>();
            ghostPrefab.AddComponent<ProjectileGhostController>();
            rockController.ghostPrefab = ghostPrefab;

            ShakeEmitter shakeEmitter = rockExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitter.amplitudeTimeDecay = true;
            shakeEmitter.duration = 0.5f;
            shakeEmitter.radius = 200f;
            shakeEmitter.scaleShakeRadiusWithLocalScale = false;

            shakeEmitter.wave = new Wave
            {
                amplitude = 1f,
                frequency = 40f,
                cycleOffset = 0f
            };

            PrefabAPI.RegisterNetworkPrefab(Projectile);
            ContentAddition.AddProjectile(Projectile);
        }

        public override ItemDisplayRuleDict CreateItemDisplayRules()
        {
            var ItemBodyModelPrefab = MainAssets.LoadAsset<GameObject>("KiseRockPickup.prefab");
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
                    localPos = new Vector3(-0.00115F, 0.33513F, 0.04486F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00091F, 0.2532F, -0.05403F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.07527F, 3.77157F, -0.03942F),
                    localAngles = new Vector3(297.0275F, 179.998F, 359.8515F),
                    localScale = new Vector3(15F, 15F, 10F)
                }
            });
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Chest",
                    localPos = new Vector3(-0.00058F, 0.67983F, 0.08839F),
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
                    localPos = new Vector3(0.00607F, 0.14684F, 0.01838F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.2F, 1.5F, 2F)
                }
            });
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.00088F, 0.20689F, 0.09534F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.5F, 2F, 1.5F)
                }
            });
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Eye",
                    localPos = new Vector3(0F, 0.74847F, -0.14856F),
                    localAngles = new Vector3(303.9299F, 180F, 180F),
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
                    localPos = new Vector3(-0.00104F, 0.1978F, 0.02001F),
                    localAngles = new Vector3(0F, 0F, 0F),
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
                    localPos = new Vector3(0.00216F, 1.5904F, 1.39194F),
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
                    localPos = new Vector3(0.01007F, 0.24238F, 0.08414F),
                    localAngles = new Vector3(0F, 0F, 0F),
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
                    localPos = new Vector3(0.00158F, 0.19446F, 0.05007F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1.3F, 1.5F, 1.5F)
                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.00014F, 0.20156F, 0.02313F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(1F, 1F, 1F)
                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule
            {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.01432F, 0.14135F, 0.05609F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(2F, 2F, 2F)
                }
            });

            return rules;
        }

        public override void Hooks()
        {
            On.RoR2.HealthComponent.TakeDamage += FireProjectile;
        }

        public void FireProjectile(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            if (self)
            {
                if (damageInfo != null)
                {
                    if (self.gameObject.GetComponent<CharacterBody>())
                    {
                        var body = self.gameObject.GetComponent<CharacterBody>();
                        if (body.inventory && GetCount(body) > 0)
                        {
                            if (!self.gameObject.GetComponent<RockController>())
                            {
                                self.gameObject.AddComponent<RockController>();
                                hasFired = RockController.GetHasFired();
                            } else
                            {
                                hasFired = RockController.GetHasFired();
                            }

                            if (!hasFired)
                            {
                                if(GetCount(body) == 1)
                                {
                                    for (int i = 0; 3 > i; i++)
                                    {
                                        ProjectileManager.instance.FireProjectile(
                                            new FireProjectileInfo()
                                        {
                                            owner = body.gameObject,
                                            damage = body.damage * 8f,
                                            position = new Vector3(body.transform.position.x, body.transform.position.y + 30, body.transform.position.z),
                                            rotation = new Quaternion(UnityEngine.Random.Range(-25, 25), UnityEngine.Random.Range(65, 115), UnityEngine.Random.Range(-65, -115), 0),
                                            projectilePrefab = Projectile
                                        });
                                        RockController.setHasFiredTrue();
                                    }
                                }
                                else
                                {
                                    for (int i = 0; ((GetCount(body) - 1) * 2) + 3 > i; i++)
                                    {
                                        ProjectileManager.instance.FireProjectile(
                                        new FireProjectileInfo()
                                        {
                                            owner = body.gameObject,
                                            damage = body.damage * 8f,
                                            position = new Vector3(body.transform.position.x, body.transform.position.y + 30, body.transform.position.z),
                                            rotation = new Quaternion(0, UnityEngine.Random.Range(65, 115), UnityEngine.Random.Range(-65, -115), 0),
                                            projectilePrefab = Projectile
                                        });
                                        RockController.setHasFiredTrue();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            orig.Invoke(self, damageInfo);
        }

    }
}
