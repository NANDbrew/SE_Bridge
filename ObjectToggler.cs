using UnityEngine;

namespace SE_Bridge
{
    public class ObjectToggler : MonoBehaviour
    {
        public GameObject[] offObjects = new GameObject[0];
        public GameObject[] onObjects = new GameObject[0];

        public void OnEnable()
        {
            ToggleArray(offObjects, false);
            ToggleArray(onObjects, true);

        }
        public void OnDisable()
        {
            ToggleArray(offObjects, true);
            ToggleArray(onObjects, false);
        }

        public static void ToggleArray(GameObject[] parts, bool state)
        {
            foreach (GameObject obj in parts)
            {
                obj.SetActive(state);
            }
        }
    }
}
