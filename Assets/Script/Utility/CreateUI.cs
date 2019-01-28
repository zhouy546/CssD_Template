using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour
{
    public GameObject NodePrefab;


    public void CreateMainUI(Node node) {
       GameObject g =  Instantiate(NodePrefab);

        g.AddComponent<Node>();

        Node myNode = g.GetComponent<Node>();
        myNode.initialization(node.ID, node.MainTitle, node.videoPath, node.ImagePath);

        ValueSheet.NodeList.Add(myNode);

        g.AddComponent<NodeCtr>();
    }
}
