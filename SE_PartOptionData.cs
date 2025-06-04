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

}
