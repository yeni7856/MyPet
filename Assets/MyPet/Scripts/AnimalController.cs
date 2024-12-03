using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyPet.AI
{
    /// <summary>
    /// ������ �����ϴ� Ŭ���� (�������� �θ� Ŭ����)
    /// </summary>
    public class AnimalController : MonoBehaviour
    {
        #region Variables
        protected StateMachine<AnimalController> stateMachine;

        //����
        protected Animator animator;   
        //protected CharacterController characterController;
        //protected NavMeshAgent agent;
        #endregion

        protected virtual void Start()
        {
            //stateMachine ����
            stateMachine = new StateMachine<AnimalController>(this, new IdleState());

            //����
            animator = GetComponent<Animator>();
            //characterController = GetComponent<CharacterController>();
            //agent = GetComponent<NavMeshAgent>();
        }
        protected virtual void Update()
        {
            //���� ������ ������Ʈ�� stateMachine�� ������Ʈ�� ���� ����
            stateMachine.Update(Time.deltaTime);
        }
        public R ChangeState<R>() where R : State<AnimalController>    //���� �ٲ��ֱ�
        {
            return stateMachine.ChangeState<R>();
        }
    }
}
