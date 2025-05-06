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
        
        levelManager.instance.addPoints();
        levelManager.instance.decrementTargetsRemaining();
        levelManager.instance.checkGameOver();
        Destroy(gameObject);
    }

    private void Start()
    {
        levelManager.instance.incrementTargetsRemaining();
    }
}
