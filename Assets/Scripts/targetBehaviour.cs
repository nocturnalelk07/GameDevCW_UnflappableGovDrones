using UnityEngine;

public class targetBehaviour : hittable
{
    public override void noHealth()
    {
        //play death effect

        //give player points for killing this

        //destroy itself
        Destroy(gameObject);
    }
}
