using UnityEngine;

namespace utils
{
    public class InterruptorOnce : InterruptorController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!used && collision.CompareTag("Player"))
            {
                used = true;
                door.ActivateSwitch();
            }
        }
    }
}