using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SE_Bridge
{
    public class SE_ClothColToggler : MonoBehaviour
    {
        float[] radii;
        public CapsuleCollider[] cols;

        public void Awake()
        {
            if (cols == null) cols = GetComponentsInChildren<CapsuleCollider>();
            radii = new float[cols.Length];
            for (int i = 0; i < cols.Length; i++)
            {
                radii[i] = cols[i].radius;
            }
            //radius = col.radius;
        }
        public void OnEnable()
        {
            for (int i = 0;i < cols.Length; i++)
            {
                cols[i].radius = radii[i];
            }
            //col.radius = radius;
        }
        public void OnDisable()
        {
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i].radius = 0;
            }
            //col.radius = 0;
        }
    }
}
