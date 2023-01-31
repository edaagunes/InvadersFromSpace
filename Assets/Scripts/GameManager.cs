using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] allAliensSets;
    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(0, 10);
    public static GameManager instance;

    private void Start()
    {
        SpawnNewWave();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        if (currentSet != null)
        {
            Destroy(currentSet);
        }

        yield return new WaitForSeconds(3);
        currentSet = Instantiate(allAliensSets[Random.Range(0, allAliensSets.Length)], spawnPos, Quaternion.identity);
        UIManager.UpdateWave();
    }
}
