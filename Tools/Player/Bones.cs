using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NLog_CheatBase.Tools.Player
{
    public static class Bones
    {
        // As a refference !!!!
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
            List<Vector3> boneReturn = new List<Vector3>();
            // well i preffer to have a static list then dynamic ...
            boneReturn.Add(GetBoneById(player, 133));
            boneReturn.Add(GetBoneById(player, 132));
            boneReturn.Add(GetBoneById(player, 14));
            boneReturn.Add(GetBoneById(player, 17));
            boneReturn.Add(GetBoneById(player, 18));
            boneReturn.Add(GetBoneById(player, 90));
            boneReturn.Add(GetBoneById(player, 91));
            boneReturn.Add(GetBoneById(player, 94));
            boneReturn.Add(GetBoneById(player, 22));
            boneReturn.Add(GetBoneById(player, 23));
            boneReturn.Add(GetBoneById(player, 111));
            boneReturn.Add(GetBoneById(player, 112));
            boneReturn.Add(GetBoneById(player, 115));

            return boneReturn;
        }
        private static Vector3 _tempBonePos;
        public static List<Vector3> GetPlayerBonePositions_inW2S(EFT.Player player) {
            List<Vector3> bones = GetPlayerBonePositions(player);
            List<Vector3> toReturn = new List<Vector3>();
            for (int i = 0; i < bones.Count; i++) {
                _tempBonePos = LocalGameWorld.W2S(bones[i]);
                toReturn.Add(_tempBonePos);
            }
            return toReturn;
        }

        private static List<Vector3> ReturnDrawPart(int index, List<Vector3> AllBoneList) {
            if(AllBoneList.Count != 12) return new List<Vector3>() { Vector3.zero, Vector3.zero };

            switch (index) {
                // propably this list creation isnt very performant tbh... (better will be to move that to 1 variable as list in list
                case 0: return new List<Vector3>() { AllBoneList[0],    AllBoneList[1]  }; // Neck, Pelvis
                case 1: return new List<Vector3>() { AllBoneList[4],    AllBoneList[5]  }; // L-UpperArm, L-ForeArm
                case 2: return new List<Vector3>() { AllBoneList[9],    AllBoneList[10] }; // R-UpperArm, R-ForeArm
                case 3: return new List<Vector3>() { AllBoneList[5],    AllBoneList[6]  }; // L-ForeArm, L-Palm
                case 4: return new List<Vector3>() { AllBoneList[10],   AllBoneList[11] }; // R-ForeArm, R-Palm
                case 5: return new List<Vector3>() { AllBoneList[9],    AllBoneList[4]  }; // R-UpperArm, L-UpperArm
                case 6: return new List<Vector3>() { AllBoneList[2],    AllBoneList[1]  }; // L-Calf, Pelvis
                case 7: return new List<Vector3>() { AllBoneList[7],    AllBoneList[1]  }; // R-Calf, Pelvis
                case 8: return new List<Vector3>() { AllBoneList[2],    AllBoneList[3]  }; // L-Calf, L-Foot
                case 9: return new List<Vector3>() { AllBoneList[7],    AllBoneList[8]  }; // R-Calf, R-Foot
               default: return new List<Vector3>() { Vector3.zero,      Vector3.zero    }; // default out of range
            }
        }
        private static List<Vector3> _TwoBones;
        public static void DrawBones(List<Vector3> boneList)
        {
            for (int i = 0; i < boneList.Count; i++)
            {
                _TwoBones = ReturnDrawPart(i, boneList);
                DrawSystem.Bone.Draw(_TwoBones[0], _TwoBones[1], Color.white, 1f);
            }
        }
        private static Vector3 GetBoneById(EFT.Player player, int BoneId)
        {
            return player.PlayerBody.SkeletonRootJoint.Bones.ElementAt(BoneId).Value.position; // sometimes throw an error...
        }
    }
}
