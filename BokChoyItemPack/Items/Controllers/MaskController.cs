using RoR2;
using UnityEngine;
namespace BokChoyItemPack.Items.Controllers
{
    public class MaskController : MonoBehaviour
    {
        public CharacterBody currentTarget;
        public int currentHits = 0; 

        public void SetCurrentTarget(CharacterBody target)
        {
            currentTarget = target;
        }

        public CharacterBody GetCurrentTarget()
        {
            return currentTarget;
        }

        public void IncrementCurrentHits()
        {
            currentHits++;
        }

        public void resetCurrentHits()
        {
            currentHits = 0;
        }

        public int GetCurrentHits()
        {
            return currentHits;
        }
    }
}