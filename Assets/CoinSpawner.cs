using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject Coin;
    [SerializeField] float radius = 10f;
    [SerializeField] float minHeight = 1f;
    [SerializeField] float maxHeight = 2f;
    [SerializeField] float minDelay = 1f;
    [SerializeField] float maxDelay = 4f;
    [SerializeField] int minPerSpawn = 1;
    [SerializeField] int maxPerSpawn = 3;
    [SerializeField] int maxCoins = 8;

    readonly List<GameObject> coins = new List<GameObject>();

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            coins.RemoveAll(c => c == null);

            int amount = Random.Range(minPerSpawn, maxPerSpawn + 1);
            for (int i = 0; i < amount && coins.Count < maxCoins; i++)
                coins.Add(Instantiate(Coin, RandomPosition(), Quaternion.identity));
        }
    }

    Vector3 RandomPosition()
    {
        Vector2 p = Random.insideUnitCircle * radius;
        return new Vector3(p.x, Random.Range(minHeight, maxHeight), p.y);
    }
}
