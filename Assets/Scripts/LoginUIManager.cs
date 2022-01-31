using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject LoginOption;

    [SerializeField]
    private GameObject NameSetting;

    // Start is called before the first frame update
    void Start()
    {
        LoginOption.SetActive(true);
        NameSetting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
