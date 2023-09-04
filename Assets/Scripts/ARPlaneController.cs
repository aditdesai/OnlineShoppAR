using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneController : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;
    ARPlacementManager m_ARPlacementManager;

    public GameObject placeButton;
    public GameObject moveButton;
    public Transform chairGameObject;

    #region UNITY Callback Methods
    void Start()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        m_ARPlacementManager = GetComponent<ARPlacementManager>();

        placeButton.SetActive(true);
        moveButton.SetActive(false);
    }

    
    void Update()
    {
        
    }
    #endregion

    #region UI Callback Methods

    public void OnPlaceButtonClicked()
    {
        m_ARPlacementManager.enabled = false;
        m_ARPlaneManager.enabled = false;

        foreach (var plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        placeButton.SetActive(false);
        moveButton.SetActive(true);
    }

    public void OnMoveButtonClicked()
    {
        m_ARPlacementManager.enabled = true;
        m_ARPlaneManager.enabled = true;

        foreach (var plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(true);
        }

        placeButton.SetActive(true);
        moveButton.SetActive(false);
    }

    public void OnRotationSliderChanged(float val)
    {
        Debug.Log(val);
        if (chairGameObject != null)
            chairGameObject.rotation = Quaternion.Euler(chairGameObject.rotation.x, val, chairGameObject.rotation.z);
    }

    #endregion
}
