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

        public void IncrementKillCount()
        {
            killCount++;
        }

        public int GetKillCount()
        {
            return killCount;
        }
    }
}