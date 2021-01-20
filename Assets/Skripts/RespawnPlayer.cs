using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _player;
    

    public void SpawnerPlayer()
    {
        Instantiate(_player, _spawnPoint.position, _spawnPoint.rotation);
    }
}
