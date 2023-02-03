using BepInEx.Configuration;
using BokChoyItemPack.Items.Controllers;
using BokChoyItemPack.Utils;
using R2API;
using RoR2;
using System.Reflection;
using UnityEngine;
using static BokChoyItemPack.Main;

namespace BokChoyItemPack.Items.Controllers
{
    public class DroidController : MonoBehaviour
    {
        float timer;
        bool spawned;
        CharacterBody body;

        void Start()
        {
            timer = 0;
            body = gameObject.GetComponent<CharacterBody>();
        }

        void Update()
        {
            timer = timer + Time.deltaTime;
            if(timer > 5)
            {
                SpawnDroid(body.transform);
            }
        }

        public void SpawnDroid(Transform self)
        {
            Object.Instantiate(MainAssets.LoadAsset<GameObject>("TeckDroidGamePrefab.prefab"), self);
        }
    }
}