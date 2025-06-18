using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panel;
    private bool isInfoActive = false;
    public void ButtonClicked()
    {
        isInfoActive = !isInfoActive;
        panel.SetActive(isInfoActive);
    }
}
