using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IHealthBar {

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

//    [SerializeField]
//    uint damageAmount;

    [SerializeField]
    float slowSpeed;

    [SerializeField]
    float freezeTimer;

	float healthTest = 1;

    float fillPercent { get { return (float)CurrentHealth / MaxHealth; } }

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

		healthBarFill.color = Color.Lerp(end, beggining, fillPercent);
		healthBarFill.fillAmount = fillPercent;

        if (freezeTimer <= 0)
        {
            healthBarSlowFill.fillAmount += (healthBarFill.fillAmount - healthBarSlowFill.fillAmount) / slowSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage();
        }
    }

	public void SetHealth (float percent){
		//CurrentHealth/MaxHealth = Percent/1;
		CurrentHealth = (uint)(Mathf.Clamp01(percent)*MaxHealth);
	}

	void takeDamage()
    {
        //CurrentHealth -= damageAmount;
		healthTest -= 0.1f;
		SetHealth(healthTest);
        freezeTimer = 0.5f;
    }
}
