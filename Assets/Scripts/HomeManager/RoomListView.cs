using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class RoomListView : MonoBehaviourPunCallbacks
{
    private const int MaxElements = 20;

    [SerializeField]
    private RoomListViewElement elementPrefab = default;

    private RoomList roomList = new RoomList();
    private List<RoomListViewElement> elementList = new List<RoomListViewElement>(MaxElements);
    private ScrollRect scrollRect;

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();

        // 取り敢えずMaxElements分、elementPrefabを作り、elementListに格納
        for(int i=0; i<MaxElements; i++)
        {
            var element = Instantiate(elementPrefab, scrollRect.content);
            element.Init();
            element.Hide();
            elementList.Add(element);
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> changedRoomList)
    {
        roomList.Update(changedRoomList);

        //存在するルームの数だけルームリスト要素を表示
        int index = 0;
        foreach(var roomInfo in roomList)
        {
            elementList[index++].Show(roomInfo);
        }

        //それ以降のルームリストは非表示
        for(int i = index; i < MaxElements; i++)
        {
            elementList[i].Hide();
        }
    }

    public override void OnJoinedLobby()
    {
        roomList.Clear();
    }

    public override void OnLeftLobby()
    {
        roomList.Clear();
    }
}
