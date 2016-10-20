using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Image fillObject;

    // For Color.Lerp
    // http://answers.unity3d.com/questions/861100/unity-46-how-to-change-slider-color-via-script.html
    //[SerializeField]
    private Color fillColorMax = Color.green;
    //[SerializeField]
    private Color fillColorHalf = new Color(1.0f, 0.47f, 0);
    //[SerializeField]
    private Color fillColorMin = Color.red;

    // Custom value for animSpeed
    [SerializeField]
    private float animSpeed;
    // Used for Mathf.Lerp t value
    private float delta = 0;

    // Initial value for health
    public static int health = 50;

    // Use this for initialization
    void Start()
    {
        healthBar.value = health;
        fillObject.color = Color.Lerp(fillColorMin, fillColorMax, healthBar.value / 100.0f);
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
            fillObject.color = Color.Lerp(fillColorMin, fillColorMax, healthBar.value / 100.0f);
            delta += 0.005f * animSpeed;
        }

    }

    private void SetColor()
    {
        if (healthBar.value > 60)
        {
            fillObject.color = Color.green;
        }
        else if (healthBar.value < 40)
        {
            fillObject.color = Color.Lerp(fillColorMin, fillColorHalf, healthBar.value / 20.0f);
        }
        else if (healthBar.value >= 40)
        {
            fillObject.color = Color.Lerp(fillColorHalf, fillColorMax, healthBar.value / 40.0f);
        }
    }
}
