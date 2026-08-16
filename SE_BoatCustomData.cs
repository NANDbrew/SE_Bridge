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
        public string embarkColName;
        public Mast[] masts;
        public WindClothSimple[] flags;
        public SE_LadderData[] ladders;
        public GPButtonTrapdoor[] doors;
        public MeshSwapper[] meshSwappers;
        public GPButtonSteeringWheel[] tillers;
        public Transform walkCol;
        public GameObject[] tabletops;
        public BilgePump[] pumps;
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
            pumps = GetComponentsInChildren<BilgePump>();

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

            foreach (var winch in GetComponentsInChildren<GPButtonRopeWinch>())
            {
                if (winch.transform.localEulerAngles.x % 90 == 0)
                {
                    float rot = UnityEngine.Random.Range(-1, 1) < 0 ? -0.2f : 0.2f;
                    //winch.transform.Rotate(rot, 0f, 0f);
                    winch.transform.localEulerAngles = new Vector3(winch.transform.localEulerAngles.x + 0.1f, winch.transform.localEulerAngles.y, winch.transform.localEulerAngles.z);
                    Debug.Log("rotated " + winch.name + " by " + rot);
                }
            }

            Validate = false;
        }
    }
}
