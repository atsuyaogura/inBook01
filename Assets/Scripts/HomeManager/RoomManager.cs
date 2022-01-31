using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {

        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnectedAndReady)
        {
            if(LoginManager.instance.playerName != null)
            {
                PhotonNetwork.NickName = LoginManager.instance.playerName;
            }

            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.JoinLobby();
        }
    }

    #region CreateBookRoom
    public void CreateBookRoomAndJoin()
    {
        string roomName = ChosenBookInformation.title + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("A room is creted with the name: " + PhotonNetwork.CurrentRoom.Name);

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("The Local player: " + PhotonNetwork.NickName + " Joined to " + PhotonNetwork.CurrentRoom.Name + " Player count " + PhotonNetwork.CurrentRoom.PlayerCount);

        PhotonNetwork.LoadLevel("BookScene");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(returnCode);
        Debug.Log(message); 
    }

    #endregion

    #region Join Oculus choice room

    public void JoinExistingRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
    }


    #endregion

    #region Join before Oculus

    public void CreateTestBookRoomAndJoin()
    {
        ChosenBookInformation.title = "‰J‚É‚à•‰‚¯‚¸";
        ChosenBookInformation.targetURL = "https://www.aozora.gr.jp/cards/000081/files/45630_23908.html";

        string roomName = ChosenBookInformation.title + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    #endregion
}
