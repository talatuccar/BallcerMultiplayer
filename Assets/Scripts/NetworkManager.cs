using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        RoomOptions options = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom("Room1", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room joined!");

        Vector2 spawnPos = PhotonNetwork.IsMasterClient ? new Vector2(-2, 0) : new Vector2(2, 0);


        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("PlayerClient", spawnPos, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Player2", spawnPos, Quaternion.identity);
        }
    }
}
