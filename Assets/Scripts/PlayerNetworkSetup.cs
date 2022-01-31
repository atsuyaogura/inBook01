using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{

    public GameObject LocalXROriginGameObject;
    public GameObject MainAvatarGameObject;

    public GameObject AvatarHeadGameObject;
    public GameObject AvatarBodyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            //The player is local
            LocalXROriginGameObject.SetActive(true);

            SetLayerRecursively(AvatarHeadGameObject, 3);
            SetLayerRecursively(AvatarBodyGameObject, 3);

            MainAvatarGameObject.AddComponent<AudioListener>();

        }

        else
        {
            LocalXROriginGameObject.SetActive(false);

            SetLayerRecursively(AvatarHeadGameObject, 0);
            SetLayerRecursively(AvatarBodyGameObject, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
