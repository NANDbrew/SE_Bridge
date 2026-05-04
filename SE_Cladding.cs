using System;
using UnityEngine;

namespace SE_Bridge
{
    public class SE_Cladding: MonoBehaviour
    {
        public CleanableObject cleanableObject;
        public BoatDamage boatDamage;
        private float baseDurabilityDays;
        private float baseImpactThreshold;
        private float baseImpactMultiplier;
        public float damageModifier = 3f;
        private int basePrice;

        public void Awake()
        {
            if (!boatDamage) boatDamage = GetComponentInParent<BoatDamage>();
            baseDurabilityDays = boatDamage.durabilityDays;
            baseImpactThreshold = boatDamage.minimumImpactVelocity;
            baseImpactMultiplier = boatDamage.impactDamageMult;
            basePrice = this.GetComponent<BoatPartOption>().basePrice;
            gameObject.layer = 2;
        }
        public class Args : EventArgs
        {
            public int arg;
        }
        public void SetPriceModifier(Args args)
        {
            this.GetComponent<BoatPartOption>().basePrice = basePrice * args.arg;
        }


        public void OnEnable()
        {
            Material[] mats = new Material[2] { cleanableObject.GetComponent<Renderer>().materials[0], GetComponent<Renderer>().materials[1] };

            this.GetComponent<Renderer>().materials = mats;


            boatDamage.durabilityDays = baseDurabilityDays * damageModifier;
            boatDamage.minimumImpactVelocity = baseImpactThreshold * damageModifier;
            boatDamage.impactDamageMult = baseImpactMultiplier / damageModifier;
        }

        public void OnDisable()
        {
            boatDamage.durabilityDays = baseDurabilityDays;
            boatDamage.minimumImpactVelocity = baseImpactThreshold;
            boatDamage.impactDamageMult = baseImpactMultiplier;
        }

    }
}
