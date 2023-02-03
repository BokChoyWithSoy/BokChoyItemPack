using BokChoyItemPack.Items.Controllers;
using R2API.Networking.Interfaces;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace BokChoyItemPack.Items.Networking
{
    internal class RecalculateStatsNetworkRequest : INetMessage
    {
        NetworkInstanceId netID;

        public RecalculateStatsNetworkRequest()
        {

        }

        public RecalculateStatsNetworkRequest(NetworkInstanceId networkID)
        {
            netID = networkID;
        }

        public void Deserialize(NetworkReader reader)
        {
            netID = reader.ReadNetworkId();
        }

        public void OnReceived()
        {
            GameObject masterobject = Util.FindNetworkObject(netID);
            CharacterMaster charMaster = masterobject.GetComponent<CharacterMaster>();
            CharacterBody charBody = charMaster.GetBody();
            
            if(NetworkServer.active)
            {
                if (charBody)
                {
                    if (!charBody.master.gameObject.GetComponent<MaskController>())
                    {

                    }
                        charBody.RecalculateStats();
                }
            }
        }

        public void Serialize(NetworkWriter writer)
        {
            writer.Write(netID);
        }
    }
}