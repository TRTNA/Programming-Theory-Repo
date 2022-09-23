using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private float _timeStep = 2f;
    [SerializeField] private Vector4 _spawnRect = new Vector4(-6f, 6f, -5f, 5f);
    [SerializeField] private float _spawnRectOffset = 2.0f;
    [SerializeField] private GameObject[] _foodPrefabs;

    public bool End { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (!End)
        {
            yield return new WaitForSeconds(_timeStep);
            float x = Random.Range(_spawnRect[0] + _spawnRectOffset, _spawnRect[1] - _spawnRectOffset);
            float y = Random.Range(_spawnRect[2] + _spawnRectOffset, _spawnRect[3] - _spawnRectOffset);
            Vector3 pos = new Vector3(x, y, 0f);
            Instantiate(_foodPrefabs[Random.Range(0, _foodPrefabs.Length)], pos, Quaternion.identity);
        }
    }
}
