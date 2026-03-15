using UnityEngine;
using System.Collections;
using TMPro;

namespace utils
{
    public class InterruptorTimer : InterruptorController
    {
        [SerializeField] private float Timer = 5f;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private GameObject timer;
        private bool started = false;
        private float timeLeft = 0f;
        

        void Update()
        {
            if(started)
            {
                timeLeft -= Time.deltaTime;
                timerText.text = timeLeft.ToString("F2");
                if (timeLeft <= 0f)
                {
                   started = false;
                   timerEnded();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Object"))
            {
                timeLeft = Timer;
                timer.SetActive(true);
                started = true;
                interruptorSprite.sprite = pressedSprite;
                door.ActivateSwitch();
            }
        }

        private void timerEnded()
        { 
            interruptorSprite.sprite = defaultSprite;
            door.DeactivateSwitch();
            timer.SetActive(false);
        }
    }
}