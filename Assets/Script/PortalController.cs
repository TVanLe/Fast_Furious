using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject destination;
    AudioManager audioManager;
    GameObject player;
    Rigidbody2D playerRb;
    Animation playerAnim;
    MovementController movementController;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        movementController = player.GetComponent<MovementController>();
        playerRb = player.GetComponent<Rigidbody2D>();
        playerAnim = player.GetComponent<Animation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                StartCoroutine(PortalIn(0.5f));
            }
        }
    }

    IEnumerator PortalIn(float duration)
    {
        audioManager.PlaySFX(audioManager.portIn);//Audio
        playerRb.simulated = false;
        playerAnim.Play("PortalIn");
        StartCoroutine(MoveInPortal());
        yield return new WaitForSeconds(duration);    

        audioManager.PlaySFX(audioManager.portOut);//Audio
        player.transform.position = destination.transform.position;
        playerRb.velocity = Vector2.zero;
        playerAnim.Play("PortalOut");
        player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        movementController.moveDirection = 1f;

        yield return new WaitForSeconds(duration);
        destination.GetComponent<Collider2D>().enabled = false;
        playerRb.simulated = true;
    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while(timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, this.transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }
}
