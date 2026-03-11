using UnityEngine;

namespace utils
{
    public class InterruptorOnce : InterruptorController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!used && (collision.CompareTag("Player") || collision.CompareTag("Object")))
            {
                interruptorSprite.sprite = pressedSprite;
                used = true;
                door.ActivateSwitch();
            }
        }
    }
}