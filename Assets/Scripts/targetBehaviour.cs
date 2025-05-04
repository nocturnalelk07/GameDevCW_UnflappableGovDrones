using UnityEngine;

public class targetBehaviour : hittable
{
    public override void noHealth()
    {
        //play death effect
        gameObject.GetComponent<Animator>().SetTrigger(destroyTrigger);

        //give player points for killing this
        
    }

    protected override void afterDestroyComplete()
    {
        Destroy(gameObject);
        levelManager.instance.addPoints();
        levelManager.instance.decrementTargetsRemaining();
        levelManager.instance.checkGameOver();
    }

    private void Start()
    {
        levelManager.instance.incrementTargetsRemaining();
    }
}
