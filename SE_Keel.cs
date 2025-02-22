using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SE_Bridge
{
    public class SE_Keel : MonoBehaviour
    {
        private BoatKeel boatKeel;
        private Vector3 startCoM;
        public Vector3 localCoM = Vector3.zero;

        public void Awake()
        {
            boatKeel = GetComponentInParent<BoatKeel>();
            startCoM = boatKeel.centerOfMass;
        }
        public void OnEnable()
        {
            boatKeel.centerOfMass = localCoM;
        }
        public void OnDisable()
        {
            boatKeel.centerOfMass = startCoM;
        }
    }
}
