using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Health healthScript;
    [SerializeField] private TMPro.TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthScript = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + healthScript.GetHealth();
    }
}
