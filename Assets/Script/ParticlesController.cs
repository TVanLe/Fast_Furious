using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [Header("Movement Particle")]
    [SerializeField] ParticleSystem movementParticle;
    
    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 1f)]
    [SerializeField] float dustFormationPeriod;

    [Header("")]
    [SerializeField] ParticleSystem fallParticle;
    [SerializeField] ParticleSystem touchParticle;
    [SerializeField] ParticleSystem dieParticle;

    [SerializeField] Rigidbody2D playerRb;
    private bool isOnGround;

    AudioManager audioManager;

    float counter;
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        touchParticle.transform.parent = null;
    }
    private void Update()
    {
        counter += Time.deltaTime;

        if(isOnGround && Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            if(counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0; 
            }
        }
    }

    public void PlayTouchParticle(Vector3 pos)
    {
        audioManager.PlaySFX(audioManager.wallTouch);//Audio
        touchParticle.transform.position = pos;
        touchParticle.Play();
    }

    public void PlayFallParticle()
    {
        audioManager.PlaySFX(audioManager.fall);//Audio
        fallParticle.Play();
    }

    public void PlayDieParticle(Vector3 pos)
    {
        audioManager.PlaySFX(audioManager.death);//Audio
        dieParticle.transform.position = pos;
        dieParticle.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = true;
            PlayFallParticle();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
