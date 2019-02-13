using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour
{
    public GameObject NodePrefab;

    public Transform M_Parent;

    NodeCtr tempnodeCtr;

    NodeCtr perviousCtr;

    NodeCtr nextCtr;
    public void CreateMainUI(Node node) {
       GameObject g =  Instantiate(NodePrefab);

        g.transform.SetParent(M_Parent);

        g.AddComponent<Node>();

        Node myNode = g.GetComponent<Node>();
        myNode.initialization(node.ID, node.MainTitle, node.videoPath, node.ImagePath);

        ValueSheet.NodeList.Add(myNode);


        //设置双向链表
        tempnodeCtr = g.AddComponent<NodeCtr>();

        if (node.ID > 0)
        {
            ValueSheet.nodeCtrs[node.ID - 1].NextNodeCtr = tempnodeCtr;
        }


        ValueSheet.nodeCtrs.Add(tempnodeCtr);


        ValueSheet.nodeCtrs[node.ID].PerviousNodeCtr = perviousCtr;


        perviousCtr = tempnodeCtr;
    }
}
