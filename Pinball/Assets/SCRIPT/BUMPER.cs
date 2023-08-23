using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUMPER : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public AUDIOMANAGER audioManager;
    public VFXMANAGER vfxManager;
    public ScoreManager scoreManager;
    public float score;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //ANIMASI
            animator.SetTrigger("HIT");

            //PLAY SFX
            audioManager.PlaySFX(collision.transform.position);

            //PLAY VFX
            vfxManager.PlayVFX(collision.transform.position);

            //SCORE ADD
            scoreManager.AddScore(score);
        }
    }
}
