using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Utils
    {
        public static int FindNearest(Vector3 position, Transform[] transforms, int upperBound)
        {
            float min = float.MaxValue;
            int index = -1;
            for (int i = 0; i < upperBound; i++)
            {
                var dist = (position - transforms[i].position).sqrMagnitude;
                if (dist < min)
                {
                    min = dist;
                    index = i;
                }
            }
            return index;
        }
        public static int FindNearest(Vector3 position, Collider[] colliders, int upperBound)
        {
            float min = float.MaxValue;
            int index = -1;
            for (int i = 0; i < upperBound; i++)
            {
                var dist = (position - colliders[i].gameObject.transform.position).sqrMagnitude;
                if (dist < min)
                {
                    min = dist;
                    index = i;
                }
            }
            return index;
        }
    }
}