using RoR2;
using UnityEngine;
namespace BokChoyItemPack.Items.Controllers
{
    public class HatController : MonoBehaviour
    {
        public int currentStack = 0;

        public void setCurrentStack(int stack)
        {
            currentStack = stack;
        }

        public int getCurrentStack()
        {
            return currentStack;
        }
    }
}