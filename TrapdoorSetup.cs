using UnityEngine;

namespace SE_Bridge
{
    internal class TrapdoorSetup : MonoBehaviour
    {
        public void OnCollisionEnter(Collider other)
        {
            if (other.CompareTag("EmbarkCol"))
            {
                var embarkCol = other.GetComponent<BoatEmbarkCollider>();
                var trapdoor = GetComponent<GPButtonTrapdoor>();
                if (trapdoor != null && trapdoor.importedActualBoat == null)
                {
                    trapdoor.importedActualBoat = embarkCol.transform.parent.parent.GetComponent<BoatRefs>().boatModel;
                    trapdoor.embarkCol = embarkCol;
                }
                trapdoor.gameObject.SetActive(true);
                this.enabled = false;
            }
        }
    }
}
