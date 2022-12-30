using RoR2;
using UnityEngine;
namespace BokChoyItemPack.Items.Controllers
{
    public class HatController : MonoBehaviour
    {
        public static int currentStack = 0;

        public static void setCurrentStack(int stack)
        {
            currentStack = stack;
        }

        public static int getCurrentStack()
        {
            return currentStack;
        }
    }
}