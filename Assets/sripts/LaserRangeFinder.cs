using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LaserRangeFinder : MonoBehaviour
{
    [SerializeField] private Transform _raycastestartPoint;
    [SerializeField] private Text _rangeFinderDistance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RaycastHit hit;
            if (Physics.Raycast(_raycastestartPoint.position, _raycastestartPoint.TransformDirection(Vector3.forward), out hit, 1000f))
            {
                Debug.DrawRay(_raycastestartPoint.position, _raycastestartPoint.TransformDirection(Vector3.forward) * hit.distance, Color.green, 14f);
                _rangeFinderDistance.text = hit.distance.ToString();
            }
            else
            {
                Debug.DrawRay(_raycastestartPoint.position, _raycastestartPoint.TransformDirection(Vector3.forward) * 1000f, Color.yellow, 14f);
                _rangeFinderDistance.text = "9999";
            }
        }       
    }
}
