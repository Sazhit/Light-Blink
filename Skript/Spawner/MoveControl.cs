using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(0, -Spawn.speed * Time.deltaTime, 0); 
    }
}
