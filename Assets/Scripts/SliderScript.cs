using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderScript : MonoBehaviour
{

    [Tooltip("Our level counter in seconds")] 
    [SerializeField] private float levelTimer = 10;
    private Slider _slider;

    private bool triggeredLevelFinished = false;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (triggeredLevelFinished) return;
        _slider.value = Time.timeSinceLevelLoad / levelTimer;

        bool isTimerExpire = (Time.timeSinceLevelLoad >= levelTimer);
        if (isTimerExpire)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
