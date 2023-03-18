using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    private void CreateController()
    {
        Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MPPlayer"), spawnpoint.position, spawnpoint.rotation); 
    }
}
