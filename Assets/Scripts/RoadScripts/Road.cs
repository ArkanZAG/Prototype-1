using UnityEngine;

namespace RoadScripts
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private Transform upperPoint;
        [SerializeField] private Transform middlePoint;

        public Transform UpperPoint => upperPoint;
        public Transform MiddlePoint => middlePoint;
    }
}