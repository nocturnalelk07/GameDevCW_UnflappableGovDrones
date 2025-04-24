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

    private void Start()
    {
        levelManager.instance.incrementTargetsRemaining();
    }
}
