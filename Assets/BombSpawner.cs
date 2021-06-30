using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _bombPoints;
    [SerializeField] private GameObject _bombPrefab;
    
    private Vector3 _whereToSpawn;
   
    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < _bombPoints.Length; i++)
        {
            _whereToSpawn = new Vector3(_bombPoints[i].transform.position.x, _bombPoints[i].transform.position.y, _bombPoints[i].transform.position.z);
            Instantiate(_bombPrefab, _whereToSpawn, Quaternion.identity);
        }
    }

}
