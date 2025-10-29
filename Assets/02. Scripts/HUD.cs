using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

    Text myText;
    private Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        // if (mySlider == null)
        // {
        //     Debug.LogWarning($"HUD Slider not found!");
        //     mySlider = GetComponentInChildren<Slider>(true);
        // }
        // if (mySlider == null)
        // {
        //     Slider[] sliders = GetComponentsInChildren<Slider>(true);
        //     if (sliders.Length > 0)
        //     {
        //         mySlider = sliders[0];
        //     }
        //     else
        //     {
        //         Debug.LogWarning("HUD Slider not found in children!");
        //     }
        // }
        var sliders = GetComponentsInChildren<Slider>();
            for (int i = 0; i < sliders.Length; i++)
            {
                if (sliders[i].name == "HUD")
                {
                    mySlider = sliders[i];
                }
                Debug.Log("Slider found: " + sliders[i].name);
            }
    }  
    
    void Start()
    {
        // Debug.LogWarning($"HUD ({type}) Slider not found!");
    }

    void LateUpdate()
    {
        
        switch (type)
        {
            case InfoType.Exp:
                if (mySlider == null)
                {
                   Debug.LogWarning($"(Switch) HUD Slider not found!");
                }
                else
                {
                    float curExp = GameManager.instance.exp;
                    float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
                    mySlider.value = curExp / maxExp;
                }
                    break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.instance.level);
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill);
                break;
            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;

        }
    }
}
