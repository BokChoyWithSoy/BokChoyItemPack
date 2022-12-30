﻿using System.Collections;
using UnityEngine;

namespace BokChoyItemPack.Items.Controllers
{
    public class RockController : MonoBehaviour
    {
        float timer;
        public static bool hasFired;

        void Start()
        {
            timer = 0;
            hasFired = false;
        }

        void Update()
        {
            timer += Time.deltaTime;
            if(timer > 10f)
            {
                hasFired = false;
                timer = 0;
            }
        }

        public static bool GetHasFired()
        {
            return hasFired;
        }        
        
        public static void setHasFiredTrue()
        {
            hasFired = true;
        }
    }
}