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
        public float materialQuantity;

        public void Awake()
        {
            if (!boatDamage) boatDamage = GetComponentInParent<BoatDamage>();
            baseDurabilityDays = boatDamage.durabilityDays;
            baseImpactThreshold = boatDamage.minimumImpactVelocity;
            baseImpactMultiplier = boatDamage.impactDamageMult;
            //materialQuantity = GetComponent<BoatPartOption>().basePrice;
            GetComponent<BoatPartOption>().mass = Mathf.RoundToInt(260 * materialQuantity);
            gameObject.layer = 2;
        }
        public class Args : EventArgs
        {
            public int arg;
        }
        public void SetPriceModifier(Args args)
        {
            this.GetComponent<BoatPartOption>().basePrice = Mathf.RoundToInt(materialQuantity * args.arg);
        }

        public void OnEnable()
        {
            var children = GetComponentsInChildren<Renderer>();
            Material[] mats = new Material[2] { cleanableObject.GetComponent<Renderer>().materials[0], children[0].materials[1] };

            for (int c = 0; c < children.Length; c++)
            {
                children[c].materials = mats;
            }

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
