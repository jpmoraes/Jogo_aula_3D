using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float attackRange = 2.0f; // Distância para atacar o jogador
    public float chaseRange = 10.0f; // Distância para iniciar a perseguição
    public float moveSpeed = 3.0f; // Velocidade de movimento do inimigo

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Defina a velocidade do NavMeshAgent
        navMeshAgent.speed = moveSpeed;
    }

    void Update()
    {
        // Verifica a distância entre o inimigo e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Para o inimigo e ataca o jogador
            isAttacking = true;
            navMeshAgent.isStopped = true;
            animator.SetBool("isAttacking", true);
        }
        else if (distanceToPlayer <= chaseRange)
        {
            // Move-se em direção ao jogador
            isAttacking = false;
            navMeshAgent.isStopped = false;
            animator.SetBool("isAttacking", false);
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            // O jogador está fora do alcance, o inimigo para de perseguir
            isAttacking = false;
            navMeshAgent.isStopped = true;
            animator.SetBool("isAttacking", false);
        }
    }

    public void AttackPlayer()
    {
        // Lógica para realizar o ataque ao jogador
        // Você pode adicionar aqui as ações específicas do ataque do inimigo
        Debug.Log("Enemy attacking player!");
    }
}
