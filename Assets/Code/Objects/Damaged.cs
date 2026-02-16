using UnityEngine;

public class Damaged : MonoBehaviour
{
    public int life = 5;

    public Transition transition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            transition.Blackscreen();
        }
    }
}
