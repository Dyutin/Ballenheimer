using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] int countDownTime;
    [SerializeField] TextMeshProUGUI countDownText;
    [SerializeField] Player player;
    public List<NavMeshAgent> navMeshAgents;
    public List<AIShooter> aIShooters;
    public List<PlayerAI> playerAIs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownStarter());
    }

    IEnumerator CountDownStarter()
    {
        while(countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1);
            countDownTime--;
        }
        countDownText.text = "DODGE!";
        StartGame();
        yield return new WaitForSeconds(2);
        countDownText.gameObject.SetActive(false);
    }

    void StartGame()
    {
        player.enabled = true;
        foreach (var navMeshAgent in navMeshAgents)
        {
            navMeshAgent.enabled = true;
        }
        foreach (var aIShooter in aIShooters)
        {
            aIShooter.enabled = true;
        }
        foreach (var playerAI in playerAIs)
        {
            playerAI.enabled = true;
        }
    }
}
