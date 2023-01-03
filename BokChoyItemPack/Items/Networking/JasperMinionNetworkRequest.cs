using BokChoyItemPack.Items;
using R2API.Networking.Interfaces;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using static BokChoyItemPack.Main;

namespace WispMod.Modules.Networking
{
    internal class JasperMinionNetworkRequest : INetMessage
    {
        NetworkInstanceId netID;
        Vector3 direction;
        double moveSpeedStat;

        public JasperMinionNetworkRequest()
        {

        }

        public JasperMinionNetworkRequest(NetworkInstanceId netID, Vector3 direction, double moveSpeedStat)
        {
            this.netID = netID;
            this.direction = direction;
            this.moveSpeedStat = moveSpeedStat;
        }

        public void Deserialize(NetworkReader reader)
        {
            netID = reader.ReadNetworkId();
            direction = reader.ReadVector3();
            moveSpeedStat = reader.ReadDouble();
        }

        public void Serialize(NetworkWriter writer)
        {
            writer.Write(netID);
            writer.Write(direction);
            writer.Write(moveSpeedStat);
        }

        public void OnReceived()
        {
            //Only server babyyyy
            if (NetworkServer.active)
            {
                SpawnWispClone();
            }
        }

        //Spawns the clone through method of Master Summoning.
        public void SpawnWispClone()
        {
            if (NetworkServer.active)
            {
                GameObject playerObj = Util.FindNetworkObject(netID);
                CharacterMaster playerMaster = playerObj.GetComponent<CharacterMaster>();
                CharacterBody body = playerMaster.GetBody();

                MasterSummon minionSummon = new MasterSummon();
                minionSummon.masterPrefab = MainAssets.LoadAsset<GameObject>("JasperMinion.prefab");
                minionSummon.ignoreTeamMemberLimit = true;
                minionSummon.teamIndexOverride = TeamIndex.Player;
                minionSummon.summonerBodyObject = playerObj;
                minionSummon.position = body.footPosition + (body.transform.forward * 2);
                minionSummon.rotation = Quaternion.LookRotation(direction);

                if (minionSummon != null)
                {
                    CharacterMaster master = minionSummon.Perform();
                    //Make it fuckin invincible and unmoveable
                    master.bodyInstanceObject.GetComponent<Rigidbody>().mass = 1000000;

                    summonCharacterMaster.Add(netID.Value.ToString(), master);
                }
            }
        }
    }
}