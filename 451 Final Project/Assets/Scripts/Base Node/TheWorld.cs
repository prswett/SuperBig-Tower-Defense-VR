using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour  {

    public SceneNode[] TheRoots;

    private void Start()
    {
        
    }

    private void Update()
    {
        Matrix4x4 i = Matrix4x4.identity;
        foreach (SceneNode node in TheRoots)
        {
            if (node != null)
            {
                node.CompositeXform(ref i);
            } 
        }
        
    }

    public void addSceneNode(SceneNode input)
    {
        SceneNode[] temp = new SceneNode[TheRoots.Length + 1];
        for (int i = 0; i < TheRoots.Length; i++)
        {
            temp[i] = TheRoots[i];
        }
        temp[temp.Length - 1] = input;
        TheRoots = temp;
    }
}
