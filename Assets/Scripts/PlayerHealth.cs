using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {


    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;

    [SerializeField] Text healthText;

    [SerializeField] AudioClip playerDamageSFX;

    private void Start()
    {
        healthText.text = health.ToString(); // para fazer o texto UI "andar junto" com o programado
    }


    private void OnTriggerEnter(Collider collider)
    {
        health = health - healthDecrease;
        healthText.text = health.ToString(); // repetido aqui pra ele se atualizar junto com os danos

        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
    }
}
