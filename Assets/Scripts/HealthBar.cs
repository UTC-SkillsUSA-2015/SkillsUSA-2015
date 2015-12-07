using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    Color beggining;

    [SerializeField]
    Color end;

    [SerializeField]
    Image healthBarFill;

    [SerializeField]
    Image healthBarSlowFill;

    [SerializeField]
    uint MaxHealth;

    [SerializeField]
    uint CurrentHealth;

    [SerializeField]
    uint damageAmount;

    [SerializeField]
    float slowSpeed;

    [SerializeField]
    float freezeTimer;

    float Percent { get { return (float)CurrentHealth / MaxHealth; } }

    //float slowPercent { get { return (float)CurrentHealthSlow / MaxHealth; } }

    void Start()
    {
        healthBarFill.color = beggining;
        CurrentHealth = MaxHealth;
        healthBarSlowFill.fillAmount = healthBarFill.fillAmount;
    }

    void Update()
    {
        if (freezeTimer > 0)
        {
            freezeTimer -= Time.deltaTime;
        }

        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        healthBarFill.color = Color.Lerp(end, beggining, Percent);
        healthBarFill.fillAmount = Percent;

        if (freezeTimer <= 0)
        {
            healthBarSlowFill.fillAmount += (healthBarFill.fillAmount - healthBarSlowFill.fillAmount) / slowSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage();
        }
    }

    void takeDamage()
    {
        CurrentHealth -= damageAmount;
        freezeTimer = 0.5f;
    }
}
