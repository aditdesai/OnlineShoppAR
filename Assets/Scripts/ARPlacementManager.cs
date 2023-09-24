using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementManager : MonoBehaviour
{
    ARRaycastManager m_ARRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    GameObject itemGameObject;

    #region UNITY Callback Methods
    private void Start()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();

        itemGameObject = GameObject.FindWithTag("Item");
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (m_ARRaycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))
        {
            itemGameObject.transform.position = hits[0].pose.position;
        }
    }
    #endregion
}
