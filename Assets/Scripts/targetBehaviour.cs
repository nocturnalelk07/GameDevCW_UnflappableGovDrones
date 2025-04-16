using UnityEngine;

public class targetBehaviour : hittable
{
    public override void noHealth()
    {
        //targets play a death animation and destroy themselves

        //play death effect

        //give player points for killing this

        //destroy itself
        Destroy(gameObject);
    }
}
