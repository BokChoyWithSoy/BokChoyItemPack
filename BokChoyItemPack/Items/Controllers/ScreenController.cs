using RoR2;
using UnityEngine;
namespace BokChoyItemPack.Items.Controllers
{
    public class ScreenController : MonoBehaviour
    {
        public int killCount;
        void Start()
        {
            killCount = 0;
        }

        public void IncrementKillCount(int itemCount)
        {
            killCount += itemCount  ;
        }

        public int GetKillCount()
        {
            return killCount;
        }
    }
}