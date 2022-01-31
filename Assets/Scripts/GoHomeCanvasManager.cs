using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeCanvasManager : MonoBehaviour
{
    public void LeaveRoomButton()
    {
        EnterLeaveManager.instance.LeaveRoomAndLoadHomeScene();
    }
}
