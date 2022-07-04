using UnityEngine;
using UnityEditor;

public class RandomMonoScript : MonoBehaviour 
{
    public float number;
    public GameObject ballPrefab;

    private const float MAX_INCLUSIVE = 5;

    public float SquareRoot
    {
        get { return Mathf.Sqrt(number); }
    }

    public void InstantiateBall()
    {
        Instantiate(ballPrefab, GetRandomVector3(), Quaternion.identity);
    }

    public static Vector3 GetRandomVector3()
    {
        return new Vector3(Random.Range(0f, MAX_INCLUSIVE), Random.Range(0f, MAX_INCLUSIVE), Random.Range(0f, MAX_INCLUSIVE));
    }
}