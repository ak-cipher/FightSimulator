
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
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
        if (currentHealth < 0)
        {
            gameWin.Win("Player");
        }
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
