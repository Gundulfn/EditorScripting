using UnityEngine;
using System.Collections.Generic;

public class Launcher : MonoBehaviour, ISerializationCallbackReceiver
{
    public GameObject projectilePrefab;

    [HideInInspector]
    public Rigidbody projectile;
    
    public Vector3 offset = Vector3.forward;
    
    public float estimatedTime;
    public Color drawColor = Color.magenta;

    [Range(0, 100)] 
    public float velocity = 10;

    private Queue<Rigidbody> instantiates = new Queue<Rigidbody>();

    public void ValidateValues()
    {
        estimatedTime = Mathf.Max(estimatedTime, 0);
    }

    public void Fire()
    {
        Rigidbody body = Instantiate(projectile, transform.TransformPoint(offset), transform.rotation);
        body.velocity = transform.forward * velocity - transform.up * 9.8f;

        instantiates.Enqueue(body);
    }

    public void Delete()
    {
        int count = instantiates.Count;
        for(int i = 0; i < count; i++)
        {
            DestroyImmediate(instantiates.Dequeue().gameObject);
        }
    }

    public void OnBeforeSerialize()
    {
        projectile = projectilePrefab.GetComponent<Rigidbody>();
    }

    public void OnAfterDeserialize(){ }
}