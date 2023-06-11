using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab;             // Prefab dari zombie

    public int numberOfZombies = 10;            // Jumlah total zombie yang akan di-spawn
    public float spawnInterval = 2f;            // Waktu antara setiap spawn
    public Transform[] spawnPoints;             // Titik-titik spawn untuk zombie

    private int zombiesSpawned = 0;             // Jumlah zombie yang sudah di-spawn

    void Start()
    {
        // Memulai spawn zombie
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while (zombiesSpawned < numberOfZombies)
        {
            // Menunggu selama spawnInterval sebelum melanjutkan
            yield return new WaitForSeconds(spawnInterval);

            // Memilih titik spawn secara acak
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Membuat zombie baru di titik spawn yang dipilih
            GameObject newZombie = Instantiate(zombiePrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
            zombiesSpawned++;

            // Menempatkan zombie baru di dalam parent (untuk organisasi)
            newZombie.transform.parent = transform;
        }
    }
}