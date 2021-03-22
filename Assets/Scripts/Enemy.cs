namespace FortyWorks.Player
{
    public class Enemy : BaseBehaviour
    {
        public void OnHitAttack()
        {
            SetHitStop(7f);
            
            _animator.CrossFade("Damage", 0);
        }
    }
}