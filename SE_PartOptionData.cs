using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class SE_PartOptionData : MonoBehaviour
{
    public int parentPartIndex = -1;

    public int[] requiresVanilla1;
    public int[] requiresVanilla2;

    public int[] requiresDisabledVanilla1;
    public int[] requiresDisabledVanilla2;

    public List<CapsuleCollider> colliders;
    public int[] mastVanilla1;
    public int[] mastVanilla2;
    private List<Mast> masts;


    public void Awake()
    {
        colliders = GetComponentsInChildren<CapsuleCollider>().ToList();

        if (colliders.Count > 0)
        {
            masts = new List<Mast>();
            var opt = GetComponent<BoatPartOption>();
            foreach (var req in opt.requires)
            {
                if (req.GetComponent<Mast>() is Mast mast)
                {
                    masts.Add(mast);
                }
            }
            var partsList = GetComponentInParent<BoatCustomParts>().availableParts;

            if (mastVanilla1.Length == 2 && partsList[mastVanilla1[0]].partOptions[mastVanilla1[1]].GetComponent<Mast>() is Mast m1) masts.Add(m1);
            if (mastVanilla2.Length == 2 && partsList[mastVanilla2[0]].partOptions[mastVanilla2[1]].GetComponent<Mast>() is Mast m2) masts.Add(m2);
        }
    }

    public void OnEnable()
    {
        if (colliders.Count > 0 && masts.Count > 0)
        {
            foreach (var req in masts)
            {
                if (req.GetComponent<Mast>() is Mast mast)
                {
                    List<CapsuleCollider> mc = mast.mastCols.ToList();
                    mc.AddRange(colliders);
                    mast.mastCols = mc.ToArray();
                }
            }
        }
    }
    public void OnDisable()
    {
        if (colliders.Count > 0 && masts.Count > 0)
        {
            foreach (var req in masts)
            {
                if (req.GetComponent<Mast>() is Mast mast)
                {
                    List<CapsuleCollider> cols = mast.mastCols.ToList();
                    foreach (CapsuleCollider col in GetComponentsInChildren<CapsuleCollider>())
                    {
                        cols.Remove(col);
                    }
                    mast.mastCols = cols.ToArray();
                }
            }
        }
    }
}
