using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private List<int> data = new List<int>();
    public int dataCap;
    public int startingData;
    private int currentData;
    private float hp = 10;
    public float hpCap = 10;

    private bool nfc = false;

    [SerializeField]
    private int def = 0;

    private CorpseBehavior dataBank;

    public Canvas dataUI;

    Coroutine A;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startingData; i++)
        {
            data.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            hp--;
        }
        
        if (data.Count > dataCap)
        {
            data.RemoveAt(data.Count - 1);
            Debug.Log("you went over your data cap!");
        }

        if (hp > hpCap)
        {
            hp = hpCap;
            Debug.Log("can't have more life");
        }

        if (dataBank != null)
        {
            if (data.Count < dataCap)
            {
                if (dataBank.Data > 0)
                {
                    if (!nfc)
                    {
                        nfc = true;
                        A = StartCoroutine(DATAsteal(dataBank, 2f));
                    }
                }
                else
                {
                    dataBank = null;
                }
            }
        }

        if ((nfc) && (dataBank == null))
        {
            StopCoroutine(A);
            nfc = false;
            dataUI.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        }

        dataUI.transform.GetChild(1).GetChild(1).GetComponent<Image>().fillAmount = hp / hpCap;
        dataUI.transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount = (float)data.Count / dataCap;
    }

    IEnumerator DATAsteal(CorpseBehavior corpse, float time)
    {
        dataUI.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        float animationTime = 0;
        while (animationTime < time)
        {
            animationTime += 0.01f;
            dataUI.transform.GetChild(3).GetChild(0).GetComponent<Image>().fillAmount = animationTime / time;
            yield return new WaitForSeconds(0.01f);
        }
        corpse.Data--;
        data.Add(0);
        nfc = false;
        dataUI.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
    }

    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            value = value - def;
            hp = hp - value;
            if (hp <= 0)
            {
                Death();
            }
        }
    }

    public bool DataUsed (int value)
    {
        if (data.Count + value > 0)
        {
            for (int i = 0; i < value; i++)
            {
                currentData = data.FindLast(FindlastData);
                if (currentData == 0)
                {
                    data.RemoveAt(data.Count - 1);
                }
                if (currentData == 1)
                {
                    data.RemoveAt(data.Count - 1);
                    // corruption
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Death()
    {
        Debug.Log("Gameover");
        Destroy(gameObject);
    }

    private static bool FindlastData(int data)
    {
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cadavre")
        {
            dataBank = collision.gameObject.GetComponent<CorpseBehavior>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cadavre")
        {
            dataBank = null;
        }
    }
}
