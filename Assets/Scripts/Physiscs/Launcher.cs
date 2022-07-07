using UnityEngine;
using System.Collections.Generic;

public class Launcher : MonoBehaviour
{
    public Rigidbody projectile;
    public Vector3 offset = Vector3.forward;
    
    [Range(0, 100)] 
    public float velocity = 10;

    private Queue<Rigidbody> instantiates = new Queue<Rigidbody>();
    
    public void Fire()
    {
        Rigidbody body = Instantiate(
            projectile, 
            transform.TransformPoint(offset), 
            transform.rotation);
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
}