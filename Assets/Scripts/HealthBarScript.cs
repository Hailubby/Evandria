using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider healthBar;

    // Custom value for animSpeed
    public float animSpeed;
    // Used for Mathf.Lerp t value
    private float delta = 0;

    // Initial value for health
    public static int health = 50;

    // Use this for initialization
    void Start()
    {
        healthBar.value = health;
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
        delta = 0;

        // If health reaches below threshold of 20, then they game over. 
        if (health < 20)
        {
            EvandriaUpdate.level = -1;
        }
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
            delta += 0.005f * animSpeed;
        }

    }
}
