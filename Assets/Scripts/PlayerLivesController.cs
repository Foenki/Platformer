using UnityEngine;
using System.Collections;

public class PlayerLivesController : MonoBehaviour {

    static int nbLives = 3;

    public static int getNbLives()
    {
        return nbLives;
    }

    public static void gainLife()
    {
        nbLives++;
    }

    public static void loseLife()
    {
        nbLives--;
    }
}
