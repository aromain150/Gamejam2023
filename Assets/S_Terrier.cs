using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Terrier : MonoBehaviour
{
    [SerializeField] string team;
    [SerializeField] MMF_Player Feedback;

    // Start is called before the first frame update
    public void SendScore(int score)
    {
        ScoreManager.Instance.AddScore(score,team);
        Feedback?.PlayFeedbacks();
    }

}
