using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float spawnRateMin = 0.5f;
    [SerializeField] private float spawnRateMax = 3.0f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    private void Awake()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            // 누적 타이머 초기화
            timeAfterSpawn = 0f;

            // 총알 생성 후 player 바라보도록
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            // 다음번 생성 간격은 랜덤으로
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
