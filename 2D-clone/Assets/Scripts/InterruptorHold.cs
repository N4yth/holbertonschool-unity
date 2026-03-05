using UnityEngine;

namespace utils
{
    public class InterruptorHold : InterruptorController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                door.ActivateSwitch();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                door.DeactivateSwitch();
            }
        }
    }
}