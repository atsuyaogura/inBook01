using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenBookInformation: MonoBehaviour
{
    // Following will be changed by PortalTrigger.OnTriggerEnter
    // Title will be passed to RoomManager.CreateAndJoinRoom for RoomName
    // URL will be passed to PageInstantiateManager for Scraping


    public static string bookID;
    public static string title;
    public static string targetURL;
}
