using UnityEngine;

namespace FortyWorks.Player
{
    public class Camera : MonoBehaviour
    {
        public static Camera Instance { get; set; }

        private Animator animator;
        
        public void Awake()
        {
            Instance = this;

            animator = GetComponent<Animator>();
        }

        public void Shake()
        {
            animator.SetTrigger("Shake");
        }
    }
}