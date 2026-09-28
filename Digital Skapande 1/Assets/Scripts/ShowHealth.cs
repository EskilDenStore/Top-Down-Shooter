using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] TextMeshProUGUI text;
    float maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.health + "/" + maxHealth;
    }
}
