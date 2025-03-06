using UnityEngine;
using UnityEngine.UI;
public class NPCManager : MonoBehaviour
{
 
    public static NPCManager instance;

    public int npcCount;
    public Text npcText; //UI text
    private bool allnpcCollect;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        npcText.text = "Npcs: " + npcCount.ToString();

        if (npcCount == 50 & !allnpcCollect)
        {
            allnpcCollect = true;
        }
    }

}