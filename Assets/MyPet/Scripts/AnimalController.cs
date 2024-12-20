using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyPet.AI
{
    /// <summary>
    /// 동물을 제어하는 클래스 (동물들의 부모 클래스)
    /// </summary>
    public class AnimalController : MonoBehaviour
    {
        #region Variables
        protected StateMachine<AnimalController> stateMachine;

        //참조
        protected Animator animator;   
        //protected CharacterController characterController;
        //protected NavMeshAgent agent;
        #endregion

        protected virtual void Start()
        {
            //stateMachine 생성
            stateMachine = new StateMachine<AnimalController>(this, new IdleState());

            //참조
            animator = GetComponent<Animator>();
            //characterController = GetComponent<CharacterController>();
            //agent = GetComponent<NavMeshAgent>();
        }
        protected virtual void Update()
        {
            //현재 상태의 업데이트를 stateMachine의 업데이트를 통해 실행
            stateMachine.Update(Time.deltaTime);
        }
        public R ChangeState<R>() where R : State<AnimalController>    //상태 바꿔주기
        {
            return stateMachine.ChangeState<R>();
        }
    }
}
