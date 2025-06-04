using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SE_Bridge
{
    internal class SE_Bulwark : MonoBehaviour
    {
        public BoatDamage damage;
        public WaveSplashZone[] splashZones;
        public float[] splashOffsets;
        public float offset;

        public void Awake()
        {
            damage = GetComponentInParent<BoatDamage>();
            splashZones = damage.gameObject.GetComponentsInChildren<WaveSplashZone>();
            splashOffsets = new float[splashZones.Length];
            for (int i = 0; i < splashZones.Length; i++)
            {
                splashOffsets[i] = splashZones[i].verticalOffset;
            }
        }
        public void OnEnable()
        {
            for (int i = 0; i < splashZones.Length; i++)
            {
                splashZones[i].verticalOffset = splashZones[i].verticalOffset + offset;
            }
        }
        public void OnDisable()
        {
            for (int i = 0; i < splashZones.Length; i++)
            {
                splashZones[i].verticalOffset = splashOffsets[i];
            }
        }
    }
}
