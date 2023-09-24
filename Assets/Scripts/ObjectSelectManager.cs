using UnityEngine;

public class ObjectSelectManager : MonoBehaviour
{
    public void OnItemClicked(int itemNumber)
    {
        Debug.Log("number = " + itemNumber);
        PlayerPrefs.SetInt("itemNumber", itemNumber); // local storage
        SceneLoader.Instance.LoadScene("AR Interface");
    }
}
