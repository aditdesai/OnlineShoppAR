using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UIManager : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;
    ARPlacementManager m_ARPlacementManager;
    GameObject itemGameObject;

    public GameObject placeButton;
    public GameObject moveButton;
    public GameObject m_ARSessionOrigin;
    public GameObject scaleSlider;
    public GameObject rotationSlider;
    public GameObject scaleButton;
    public GameObject rotateButton;

    #region UNITY Callback Methods
    void Start()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        m_ARPlacementManager = GetComponent<ARPlacementManager>();

        placeButton.SetActive(true);
        moveButton.SetActive(false);

        scaleSlider.SetActive(false);
        rotationSlider.SetActive(false);

        itemGameObject = GameObject.FindWithTag("Item");
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

        scaleButton.SetActive(false);
        rotateButton.SetActive(false);

        scaleSlider.SetActive(false);
        rotationSlider.SetActive(false);
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

        scaleButton.SetActive(true);
        rotateButton.SetActive(true);

        scaleSlider.SetActive(false);
        rotationSlider.SetActive(false);
    }

    public void OnScaleButtonClicked()
    {
        rotationSlider.SetActive(false);
        scaleSlider.SetActive(true);
    }

    public void OnRotateButtonClicked()
    {
        rotationSlider.SetActive(true);
        scaleSlider.SetActive(false);
    }

    public void OnRotationSliderChanged(float val)
    {
        m_ARSessionOrigin.transform.rotation = Quaternion.Euler(0, val, 0);
    }

    public void OnScaleSliderChanged(float val)
    {
        m_ARSessionOrigin.transform.localScale = Vector3.one / val;
    }

    public void OnBackButtonClicked()
    {
        Debug.Log(itemGameObject == null);
        Destroy(itemGameObject);
        Debug.Log(itemGameObject == null);
        SceneLoader.Instance.LoadScene("Marketplace");
    }

    #endregion
}
