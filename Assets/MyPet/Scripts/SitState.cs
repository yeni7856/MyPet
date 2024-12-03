using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPet.AI
{
    public class SitState : State<AnimalController>
    {
        private Animator animator;

        //animator parametor
        protected int IsSitHash = Animator.StringToHash("IsSit");       //��Ʈ �ؽ������� ��ȯ
        public override void OnInitialized()
        {
            //����
            animator = context.GetComponent<Animator>();
            /*characterController = context.GetComponent<CharacterController>();
            agent = context.GetComponent<NavMeshAgent>(); */
        }
        public override void OnEnter()
        {
            animator.SetBool(IsSitHash, true);
        }
        public override void OnExit()
        {
            animator.SetBool(IsSitHash, false);
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
