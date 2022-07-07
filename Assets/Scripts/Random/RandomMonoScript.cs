using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomMonoScript : MonoBehaviour 
{
    [ContextMenuItem("Trim Number", "Trim")]
    public float number;
    public GameObject ballPrefab;

    private AudioSource audioSource;
    private AudioClip audioClip;
    
    private const float RANDOM_MAX_INCLUSIVE = 5;

    public float SquareRoot
    {
        get { return Mathf.Sqrt(number); }
    }

    public void InstantiateBall()
    {
        if(!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load("AudioClips/Alert") as AudioClip;
            audioSource.playOnAwake = false;
        }

        audioSource.Play();
        Instantiate(ballPrefab, GetRandomVector3(), Quaternion.identity);
    }

    public static Vector3 GetRandomVector3()
    {
        return new Vector3(Random.Range(0f, RANDOM_MAX_INCLUSIVE), Random.Range(0f, RANDOM_MAX_INCLUSIVE), Random.Range(0f, RANDOM_MAX_INCLUSIVE));
    }

    [ContextMenu("Reset Number")]
    private void ResetNumber()
    {
        number = 0;
    }

    private void Trim()
    {
        number = (int)number;
    }
}