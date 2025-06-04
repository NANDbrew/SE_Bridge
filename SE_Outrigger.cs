using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Crest;

namespace SE_Bridge
{
    internal class SE_Outrigger : MonoBehaviour
    {
        public FloaterForcePoints[] points;
        private float[] weights;
        public int[] pointIndices;
        public BoatProbes boatProbes;

        public void Awake()
        {
            boatProbes = GetComponentInParent<BoatProbes>();
            //points = new FloaterForcePoints[] { source[12], source[13], source[14] };
            weights = new float[points.Length];
/*            for (int i = 0; i < points.Length; i++)
            {
                weights[i] = points[i]._weight;
            }*/
            for (int i = 0; i < pointIndices.Length; i++)
            {
                weights[i] = boatProbes._forcePoints[pointIndices[i]]._weight;
            }
        }
        public void OnEnable()
        {
            /*var points2 = boatProbes._forcePoints;
            boatProbes._forcePoints = points2.*/
/*            for (int i = 0; i < points.Length; i++)
            {
                points[i]._weight = weights[i];
            }*/
            for (int i = 0; i < pointIndices.Length; i++)
            {
                boatProbes._forcePoints[pointIndices[i]]._weight = weights[i];
            }
        }
        public void OnDisable()
        {
            /*var points2 = boatProbes._forcePoints;
            boatProbes._forcePoints = points2.*/
/*            foreach (var point in points)
            {
                point._weight = 0f;
            }*/
            for (int i = 0; i < pointIndices.Length; i++)
            {
                boatProbes._forcePoints[pointIndices[i]]._weight = 0;
            }
        }
    }
}
