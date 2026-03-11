using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace utils
{
    public class ActiveTeleporterHandler : MonoBehaviour
    {
        [SerializeField] private int requiredSwitches = 1;
        [SerializeField] protected GameObject door;

        private int currentSwitches = 0;

        public void ActivateSwitch()
        {
            currentSwitches++;

            CheckDoor();
        }

        public void DeactivateSwitch()
        {
            currentSwitches--;

            CheckDoor();
        }

        private void CheckDoor()
        {
            if (currentSwitches >= requiredSwitches)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }

        void OpenDoor()
        {
            door.SetActive(true);
        }

        void CloseDoor()
        {
            door.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                StartCoroutine(Exit());
            }
        }

        private IEnumerator Exit()
        {
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}