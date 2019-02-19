using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCtr : ICtr
{
    public GameObject BarNode_Prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void initialization()
    {
        base.initialization();
        CreatePrefab();
        SetupPanelWidth();
    }


    public void SetupPanelWidth() {
        float cellsizeX = this.GetComponent<GridLayoutGroup>().cellSize.x;
        float SpacingX = this.GetComponent<GridLayoutGroup>().spacing.x;
        float width = (cellsizeX + SpacingX) * ValueSheet.NodeList.Count;

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, this.GetComponent<RectTransform>().rect.height);
  
    }

    private void CreatePrefab() {

        for (int i = 0; i < ValueSheet.NodeList.Count; i++)
        {
           GameObject G =  Instantiate(BarNode_Prefabs);
            G.transform.SetParent(this.transform);
            G.transform.localScale = Vector3.one;
            G.transform.localRotation = Quaternion.Euler(Vector3.zero);
            G.transform.localPosition = Vector3.zero;
            G.GetComponent<BarNodeCtr>().initialization(ValueSheet.NodeList[i].ID);
        }
      
    }
}
