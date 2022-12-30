using RoR2;
using UnityEngine;
namespace BokChoyItemPack.Items.Controllers
{
    public class ScreenController : MonoBehaviour
    {
        public static int killCount;
        void Start()
        {
            killCount = 0;
        }

        public static void incrementKillCount()
        {
            killCount++;
        }

        public static int getKillCount()
        {
            return killCount;
        }
    }
}