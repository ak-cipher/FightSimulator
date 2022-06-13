
using UnityEngine;
using UnityEngine.UI;

public class AI_PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public int startHealth = 100;
    public int currentHealth;
    public GameWin gameWin;
    private void Start()
    {
        currentHealth = startHealth;
        SetHealth(startHealth);
    }


    private void Update()
    {
        Debug.Log(currentHealth);
        SetHealth(currentHealth);
        if(currentHealth<0)
        {
            gameWin.Win("AI_Player");
        }
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
