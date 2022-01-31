using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField]
    private RoomManager roomManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HomeSceneBooks"))
        {

            Text[] bookTexts = other.GetComponentsInChildren<Text>();

            ChosenBookInformation.title = bookTexts[0].text;
            ChosenBookInformation.targetURL = bookTexts[2].text;

            Debug.Log(ChosenBookInformation.title);
            Debug.Log(ChosenBookInformation.targetURL);

            roomManager.CreateBookRoomAndJoin();
        }
    }
}
