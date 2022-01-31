using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;


public class RoomListViewElement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameLabel = default;

    [SerializeField]
    private TextMeshProUGUI playerCounter = default;

    private Button button;

    public void Init()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        PhotonNetwork.JoinRoom(nameLabel.text);
    }

    public void Show(RoomInfo roomInfo)
    {
        nameLabel.text = roomInfo.Name;
        playerCounter.SetText("{0}/{1}", roomInfo.PlayerCount, roomInfo.MaxPlayers);

        button.interactable = (roomInfo.PlayerCount < roomInfo.MaxPlayers);

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
}
