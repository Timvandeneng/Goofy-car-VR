using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booklet_Pages_Manager : MonoBehaviour
{
    private int currentPage = 0;
    [SerializeField] private GameObject[] pages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handlePageControl();
        handlePagesDisplay();
    }

    void handlePageControl()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentPage != 0)
        {
            --currentPage;
        }
        if(Input.GetKeyDown(KeyCode.Mouse1) && currentPage != pages.Length - 1)
        {
            ++currentPage;
        }
    }

    void handlePagesDisplay()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (i != currentPage)
                pages[i].SetActive(false);

            if (i == pages.Length)
                i = 0;
        }
        pages[currentPage].SetActive(true);
    }
}
