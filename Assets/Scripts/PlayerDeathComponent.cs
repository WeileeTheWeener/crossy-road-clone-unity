using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathComponent : MonoBehaviour
{
    public bool isAlive;
    [SerializeField] UnityEvent onPlayerDeath;

    private void OnEnable()
    {
        isAlive = true;
    }
    private void OnDisable()
    {
        isAlive = false;
    }

    public void HandleDeath()
    {
  
       if (!isAlive)
       {
            onPlayerDeath.Invoke();
            Debug.Log("on player death invoked");
       }
    }
}
