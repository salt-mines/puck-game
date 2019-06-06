using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PuckScript : MonoBehaviour
{
    public GameManager gameManager;

    public AudioClip collisionSound;
    public AudioClip scoreSound;

    internal GameObject previousPlayerTouched;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //vaihda kiekon väri pelaajan väriksi
            previousPlayerTouched = collision.gameObject;

            gameManager.ChangeMowerColor(gameObject, previousPlayerTouched.GetComponent<Player>().playerTeamColor);

            audioSource.PlayOneShot(collisionSound);
        }
    }

    internal void Score()
    {
        audioSource.PlayOneShot(scoreSound);
    }
}
