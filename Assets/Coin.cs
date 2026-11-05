using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 120f;
    [SerializeField] float bobAmplitude = 0.15f;
    [SerializeField] float bobSpeed = 2f;

    Transform root;
    float baseY;
    float phase;

    void Start()
    {
        root = transform.root;
        baseY = root.position.y;
        phase = Random.value * Mathf.PI * 2f;
    }

    void Update()
    {
        root.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);

        Vector3 pos = root.position;
        pos.y = baseY + Mathf.Sin(Time.time * bobSpeed + phase) * bobAmplitude;
        root.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.score += 1;
            Destroy(root.gameObject);
        }
    }
}
