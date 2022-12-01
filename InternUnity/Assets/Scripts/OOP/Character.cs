using UnityEngine;

public class Character : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        Movement();
    }

    public virtual void Movement()
    {
        Debug.Log("Character move"); 
    }
}
