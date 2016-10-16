using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Image fillObject;
    [SerializeField]
    private Color fillColorMax;
    [SerializeField]
    private Color fillColorMin;

    // Custom value for animSpeed
    [SerializeField]
    private float animSpeed;
    // Used for Mathf.Lerp t value
    private float delta = 0;

    // Initial value for health
    [SerializeField]
    private int initialHealth;
    private int health;

    // Use this for initialization
    void Start()
    {
        health = initialHealth;
        healthBar.value = initialHealth;
        fillObject.color = Color.Lerp(fillColorMin, fillColorMax, initialHealth / 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("health=" + health);
        //Debug.Log("sliderval=" + healthBar.value);
        AnimateHealth();
    }

    /// <summary>
    /// Health is from values 0 to 100 integer only
    /// </summary>
    /// <param name="value"></param>
    public void UpdateHealth(int value)
    {
        health = (int) healthBar.value + value;

        // hmmm...
        // checking making sure values are ok
        health = health > 100 ? 100 : health;
        health = health < 0 ? 0 : health;

        delta = 0;
    }

    /// <summary>
    /// Method to animate the health, should be called within update
    /// </summary>
    private void AnimateHealth()
    {
        //if (value < 0 || value > 100)
        //    throw new System.Exception("value for the HealthBar must be integer from 0 to 100");

        //healthBar.value = health;
        //Debug.Log(delta);
        if (health != healthBar.value)
        {
            healthBar.value = Mathf.Lerp(healthBar.value, health, delta);      
            fillObject.color = Color.Lerp(fillColorMin, fillColorMax, healthBar.value / 100.0f);
            delta += 0.005f * animSpeed;
        }

    }
}
