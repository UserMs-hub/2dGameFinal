// using UnityEngine;
// using UnityEngine.UI;

// public class HUD : MonoBehaviour
// {

//     public enum InfoType { Exp, Level, Kill, Time, Health }
//     public InfoType type;

//     public Slider expSlider;
//     public Slider healthSlider;
//     public Text levelText;
//     public Text killText;
//     public Text timeText;

//     void Awake()
//     {
        
//     }  
    
//     void Start()
//     {
        
//     }

//     void LateUpdate()
//     {
        
//         switch (type)
//         {
//             case InfoType.Exp: 
//                     float curExp = GameManager.instance.exp;
//                     float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
//                     expSlider.value = curExp / maxExp;
                
//                     break;
//             case InfoType.Level:
//                 levelText.text = string.Format("Lv.{0:F0}", GameManager.instance.level);
//                 break;
//             case InfoType.Kill:
//                 killText.text = string.Format("{0:F0}", GameManager.instance.kill);
//                 break;
//             case InfoType.Time:
//                 float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
//                 int min = Mathf.FloorToInt(remainTime / 60);
//                 int sec = Mathf.FloorToInt(remainTime % 60);
//                 timeText.text = string.Format("{0:D2}:{1:D2}", min, sec);
//                 break;
//             case InfoType.Health:
//                 float curHealth = GameManager.instance.health;
//                 float maxHealth = GameManager.instance.maxHealth;
//                 healthSlider.value = curHealth / maxHealth;
//                 break;

//         }
//     }
// }
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Slider expSlider;
    private Slider healthSlider;
    private Text levelText;
    private Text timerText;

    void Awake()
    {
        // 각 오브젝트를 이름으로 찾아서 컴포넌트 할당
        expSlider = transform.Find("Exp")?.GetComponent<Slider>();
        levelText = transform.Find("Level")?.GetComponent<Text>();
        timerText = transform.Find("Timer")?.GetComponent<Text>();
        healthSlider = transform.Find("Health/HealthBar")?.GetComponent<Slider>();
    }

    void LateUpdate()
    {
        var gm = GameManager.instance;
        if (gm == null) return;

        if (expSlider)
        {
            float curExp = gm.exp;
            float maxExp = gm.nextExp[Mathf.Min(gm.level, gm.nextExp.Length - 1)];
            expSlider.value = curExp / maxExp;
        }

        // 레벨 텍스트
        if (levelText)
            levelText.text = $"Lv.{gm.level:0}";

        // 타이머
        if (timerText)
        {
            float remain = gm.maxGameTime - gm.gameTime;
            int min = Mathf.FloorToInt(remain / 60);
            int sec = Mathf.FloorToInt(remain % 60);
            timerText.text = $"{min:D2}:{sec:D2}";
        }

        // 체력 바
        if (healthSlider)
            healthSlider.value = gm.health / gm.maxHealth;
    }
}