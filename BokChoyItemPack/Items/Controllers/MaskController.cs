using RoR2;
using UnityEngine;
namespace BokChoyItemPack.Items.Controllers
{
    public class MaskController : MonoBehaviour
    {
        public static CharacterBody currentTarget;
        public static int currentHits = 0; 

        public static void SetCurrentTarget(CharacterBody target)
        {
            currentTarget = target;
        }

        public static CharacterBody GetCurrentTarget()
        {
            return currentTarget;
        }

        public static void IncrementCurrentHits()
        {
            currentHits++;
        }

        public static void resetCurrentHits()
        {
            currentHits = 0;
        }

        public static int GetCurrentHits()
        {
            return currentHits;
        }
    }
}