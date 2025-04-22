using UnityEngine;

public class targetBehaviour : hittable
{
    public override void noHealth()
    {
        //play death effect


        //give player points for killing this
        levelManager.instance.addPoints();
        levelManager.instance.decrementTargetsRemaining();
        levelManager.instance.checkGameOver();
        //destroy itself

        Destroy(gameObject);
    }

    private void Awake()
    {
        levelManager.instance.incrementTargetsRemaining();
    }
}
