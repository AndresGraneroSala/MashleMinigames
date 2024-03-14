using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    public void Restart()
    {
        Levels._sharedInstance.Loose();
    }
}
