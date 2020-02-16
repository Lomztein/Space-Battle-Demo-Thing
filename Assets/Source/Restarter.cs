using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private bool _isRestarting;

    void FixedUpdate()
    {
        if (!_isRestarting)
        {
            if (FactionList.Instance.Factions.Count (x => x.GetMembers ().Length > 0) == 1)
            {
                Invoke("Restart", 5f);
                _isRestarting = true;
            }
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(0);
    }
}
