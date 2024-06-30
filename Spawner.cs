using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _pipes;
    [SerializeField] private GameObject[] _heart;

    void Update()
    {

    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            var pos = new Vector2(transform.position.x, Random.Range(0f, 1f));
            var pipe = Instantiate(_pipes[Random.Range(0, _pipes.Length)], pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2.0f, 3.5f));
            Destroy(pipe, 5f);
        }
    }

    public IEnumerator HeartSpawn()
    {
        while (true)
        {
            var heartPos = new Vector2(transform.position.x, Random.Range(0.5f, 2.5f));
            var heart = Instantiate(_heart[Random.Range(0, _heart.Length)], heartPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            Destroy(heart, 2f);
        }
    }

    
}