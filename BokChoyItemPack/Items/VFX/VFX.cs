using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items.VFX
{
    public class VFX : MonoBehaviour
    {
        public static GameObject ExplosionEffect;

        public static void LoadVFX()
        {
            CreateExplosionVFX();
        }
        
        private static void CreateExplosionVFX()
        {
            ExplosionEffect = LoadEffect("ExplosionEffect.prefab", "", false);
            ContentAddition.AddEffect(ExplosionEffect);
        }

        private static GameObject LoadEffect(string resourceName, string soundName, bool parentToTransform)
        {
            GameObject newEffect = MainAssets.LoadAsset<GameObject>(resourceName);

            newEffect.AddComponent<DestroyOnTimer>().duration = 12;
            newEffect.AddComponent<NetworkIdentity>();
            newEffect.AddComponent<VFXAttributes>().vfxPriority = VFXAttributes.VFXPriority.Always;
            var effect = newEffect.AddComponent<EffectComponent>();
            effect.applyScale = false;
            effect.effectIndex = EffectIndex.Invalid;
            effect.parentToReferencedTransform = parentToTransform;
            effect.positionAtReferencedTransform = true;
            effect.soundName = soundName;

            return newEffect;
        }
    }
}