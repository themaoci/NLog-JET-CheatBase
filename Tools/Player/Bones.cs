using Cheat.Base.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cheat.Base.Tools.Player
{
    public static class Bones
    {
        public enum PlayerSkeletor {
            Head = 133,
            Neck = 132,
            Pelvis = 14,
            Left_Calf = 17,
            Left_Foot = 18,
            Left_Upperarm = 90,
            Left_Forearm = 91,
            Left_Palm = 94,
            Right_Calf = 22,
            Right_Foot = 23,
            Right_Upperarm = 111,
            Right_Forearm = 112,
            Right_Palm = 115
        }

        public enum BodyPart
        {
            Null = 0,
            Pelvis = 14,
            LeftThigh1 = 15,
            LeftThigh2 = 16,
            LeftCalf = 17,
            LeftFoot = 18,
            LeftToe = 19,
            RightThigh1 = 20,
            RightThigh2 = 21,
            RightCalf = 22,
            RightFoot = 23,
            RightToe = 24,
            Bear_Feet = 25,
            USEC_Feet = 26,
            BEAR_feet_1 = 27,
            Spine1 = 29,
            Gear1 = 30,
            Gear2 = 31,
            Gear3 = 32,
            Gear4 = 33,
            Gear4_1 = 34,
            Gear5 = 35,
            Spine2 = 36,
            Spine3 = 37,
            Ribcage = 66,
            LeftCollarbone = 89,
            LeftUpperarm = 90,
            LeftForearm1 = 91,
            LeftForearm2 = 92,
            LeftForearm3 = 93,
            LeftPalm = 94,
            RightUpperarm = 111,
            RightForearm1 = 112,
            RightForearm2 = 113,
            RightForearm3 = 114,
            RightPalm = 115,
            Neck = 132,
            Head = 133
        }

        public static List<Vector3> GetPlayerBonePositions(EFT.Player player) 
        {
            var bones = Enum.GetValues(typeof(PlayerSkeletor)).Cast<int>();
            List<Vector3> boneReturn = new List<Vector3>();
            IEnumerator<int> e = bones.GetEnumerator();
            while(e.MoveNext())
            {
                boneReturn.Add(GetBoneById(player, e.Current));
            }
            return boneReturn;
        }

        public static List<Vector3> GetPlayerBonePositions_inW2S(EFT.Player player) {
            List<Vector3> bones = GetPlayerBonePositions(player);
            var e = bones;
            List<Vector3> toReturn = new List<Vector3>();
            for (int i = 0; i < bones.Count; i++) {
                toReturn.Add(LocalGameWorld.MainCamera.WorldToScreenPoint(bones[i]));
            }
            return toReturn;
        }
        /*
        public static Vector3 FinalVector(Diz.Skinning.Skeleton skeletor, int BoneId)
        {
            try
            {
                return skeletor.Bones.ElementAt(BoneId).Value.position;
            }
            catch 
            {
                return Vector3.zero;
            }
        }
        */
        /* for debugging only
        public static string BoneName(Diz.Skinning.Skeleton sko, int id)
        {
            return sko.Bones.ElementAt(id).Key.ToString();
        }*/
        private static Vector3 GetBoneById(EFT.Player player, int BoneId)
        {
            return player.PlayerBody.SkeletonRootJoint.Bones.ElementAt(BoneId).Value.position; // sometimes throw an error...
        }
        /*public static Vector3 GetBoneById(EFT.Player player, BodyPart BoneId)
        {
            return player.PlayerBody.SkeletonRootJoint.Bones.ElementAt((int)BoneId).Value.position; // additional override not used now
        }*/
    }
}
