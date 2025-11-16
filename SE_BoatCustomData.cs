using UnityEngine;
using System.Collections.Generic;
namespace SE_Bridge
{
    [ExecuteInEditMode]
    public class SE_BoatCustomData : MonoBehaviour
    {
        public SE_PartData[] parts;
        public SE_PartOptionData[] options;
        public Mesh embarkColMesh;
        public Mast[] masts;
        public WindClothSimple[] flags;
        public SE_LadderData[] ladders;
        public GPButtonTrapdoor[] doors;
        public MeshSwapper[] meshSwappers;
        public GPButtonSteeringWheel[] tillers;
        public Transform walkCol;
        public GameObject[] tabletops;
        public int firstAvailableIndex;
        public bool Validate;

        private void OnValidate()
        {
            masts = GetComponentsInChildren<Mast>();
            flags = GetComponentsInChildren<WindClothSimple>();
            ladders = GetComponentsInChildren<SE_LadderData>();
            doors = GetComponentsInChildren<GPButtonTrapdoor>();
            meshSwappers = GetComponentsInChildren<MeshSwapper>();
            tillers = GetComponentsInChildren<GPButtonSteeringWheel>();

            firstAvailableIndex = 0;
            int highest = 0;
            for (int i = 0; i < masts.Length; i++)
            {
                if (masts[i].orderIndex >= firstAvailableIndex)
                {
                    firstAvailableIndex = masts[i].orderIndex + 1;
                }
                if (masts[i].orderIndex == highest)
                {
                    firstAvailableIndex = highest;
                    Validate = true;
                    return;
                }
            }
            Validate = false;
        }
    }
}
