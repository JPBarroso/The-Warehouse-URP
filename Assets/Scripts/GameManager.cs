using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Coroutine cor;
    [Header("Character variables")]
    [SerializeField] float maxEnergy;
    [SerializeField] float remainingEnergy;
    [SerializeField] float maxStamina; 
    [SerializeField] float remainingStamina;

    [Header("Fixed items")]
    [SerializeField] GameObject[] roomLights;
    [SerializeField] Light depositLight;

    [Header("Mission status")]
    [SerializeField] List<Item._ItemType> itemsToDeliver = new List<Item._ItemType>();
    int positionInList;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DepositFlicker(bool isCorrect)
    {
        Color32 col;
        if (isCorrect)
        {
            col = Color.green;
        }
        else
        {
            col = Color.red;
        }
        //Make it sound or smth
        depositLight.color = col;
        depositLight.enabled = true;
        yield return new WaitForSeconds(0.25f);
        depositLight.enabled = false;
        cor = null;
    }
    void DepositedLight(bool isCorrect)
    {
        if (cor != null)
        {
            StopCoroutine(cor);
        }
        cor = StartCoroutine(DepositFlicker(isCorrect));
    }
    public void DepositedItem(Item._ItemType type)
    {
        if(type == itemsToDeliver[positionInList])
        {
            DepositedLight(true);
        }
        else
        {
            DepositedLight(false);
        }
        positionInList++;
        if(positionInList >= itemsToDeliver.Count)
        {
            //TESTING
            Debug.Log("WON!");
            positionInList = 0;
        }
        else
        {
            Debug.Log("KEEP GOING!");
        }
    }
}
