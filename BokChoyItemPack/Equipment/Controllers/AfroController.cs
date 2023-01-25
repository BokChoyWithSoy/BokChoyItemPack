using UnityEngine;
using RoR2;

namespace BokChoyItemPack.Items.Controllers
{
    public class AfroController : MonoBehaviour
    {
        EquipmentSlot equipmentSlot;
        bool hasTransformed = false;
        float timer;

        void Update()
        {
            timer += Time.deltaTime;
            if (timer > 0.5f && hasTransformed == false )
            {
                gameObject.GetComponent<CharacterMaster>().TransformBody("ElectricWormBody");
                hasTransformed = true;
            }
            if (timer > 30f)
            {
                gameObject.GetComponent<CharacterMaster>().TransformBody(BodyCatalog.GetBodyName(equipmentSlot.characterBody.bodyIndex));
                Destroy(gameObject.GetComponent<AfroController>());
            }
        }

        public void setSlot(EquipmentSlot slot)
        {
            equipmentSlot = Instantiate(slot);
        }
    }
}