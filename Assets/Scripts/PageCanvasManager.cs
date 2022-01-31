using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCanvasManager : MonoBehaviour
{
    [SerializeField]
    private Canvas bookCanvas;

    [SerializeField]
    private GameObject GenericVRPlayerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        bookCanvas.worldCamera = GenericVRPlayerPrefab.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
