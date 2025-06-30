using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

[ExecuteInEditMode] [RequireComponent(typeof(MeshRenderer),typeof(MeshFilter))]
public class PathCreator : MonoBehaviour
{
    [SerializeField] private float _baseWidth = 2;
    [SerializeField] private bool _stopGeneration = false;

    private void Update()
    {
        if(Application.isPlaying)
            Destroy(this);
        if(!_stopGeneration)
            CreatePathMesh();
    }
    

    [Button]
    public void CreatePathMesh()
    {
        //Get all children
        var points = GetComponentsInChildren<Transform>().ToList();
        points.RemoveAt(0);
        if(points.Count < 2) 
            return;

        //Create Mesh
        Mesh mesh = new Mesh();

        List<Vector3> verticesList = new();
        List<Vector2> uvList = new();
        List<int> trianglesList = new();
        verticesList.Add(points[0].localPosition + -points[0].right * points[0].localScale.x * _baseWidth);
        verticesList.Add(points[0].localPosition + points[0].right * points[0].localScale.x * _baseWidth);

        int lastStartIndex = 0;
        for (int i = 1; i < points.Count; i++)
        {
            //Create vertices 
            verticesList.Add(points[i].localPosition + -points[i].right * points[i].localScale.x * _baseWidth);
            verticesList.Add(points[i].localPosition + points[i].right * points[i].localScale.x * _baseWidth);
            
            //Create Triangles
            trianglesList.Add(lastStartIndex + 1);
            trianglesList.Add(lastStartIndex);
            trianglesList.Add(lastStartIndex + 2);
            
            trianglesList.Add(lastStartIndex + 3);
            trianglesList.Add(lastStartIndex + 1);
            trianglesList.Add(lastStartIndex + 2);

            lastStartIndex = verticesList.Count - 2;
        }

        //Get min and max points of the mesh
        float minX = verticesList[0].x;
        float minZ = verticesList[0].z;
        float maxX = verticesList[0].x;
        float maxZ = verticesList[0].z;
        foreach (var vertice in verticesList)
        {
            if (vertice.x < minX)
                minX = vertice.x;
            if (vertice.z < minZ)
                minZ = vertice.z;
            if (vertice.x > maxX)
                maxX = vertice.x;
            if (vertice.z > maxZ)
                maxZ = vertice.z;
        }

        maxX -= minX;
        maxZ -= minZ;
        
        //Add uvs
        foreach (var vertice in verticesList)
        {
            float x = (vertice.x - minX) / maxX;
            float z = (vertice.z - minZ) / maxZ;
            uvList.Add(new Vector2(x,z));
        }
        
        mesh.vertices = verticesList.ToArray();
        mesh.uv = uvList.ToArray();
        mesh.triangles = trianglesList.ToArray();

        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;

        //Apply material

    }

    [SerializeField] private Vector2 _baseSize;
    [EnableIf("_stopGeneration")]
    [Button]
    public void AddOuterColliders()
    {
        var collidersParent = new GameObject().transform;
        collidersParent.parent = transform;
        collidersParent.name = "GeneratedColliders";
        collidersParent.position = transform.position;
        var mesh = GetComponent<MeshFilter>().sharedMesh;

        for (int i = 2; i < mesh.vertices.Length; i++)
        {
            var child = new GameObject();
            child.transform.parent = collidersParent;
            
            var boxCollider = child.AddComponent<BoxCollider>();
            
            boxCollider.size = (Vector3)_baseSize + new Vector3(0,0,Vector3.Distance(mesh.vertices[i], mesh.vertices[i - 2]));

            Vector3 position =
                Vector3.Cross(
                    -Vector3.Cross(mesh.vertices[i - 2] - mesh.vertices[i], mesh.vertices[i - 1] - mesh.vertices[i]),
                    mesh.vertices[i - 2] - mesh.vertices[i]).normalized * boxCollider.size.x / 2 +
                collidersParent.position + (mesh.vertices[i - 2] + mesh.vertices[i]) / 2;
            
            child.transform.position = position; 


            child.transform.eulerAngles = new Vector3
                (0,
                    mesh.vertices[i-2].x - mesh.vertices[i].x > 0 ? Vector3.Angle(transform.forward, mesh.vertices[i-2] - mesh.vertices[i]) : -Vector3.Angle(transform.forward, mesh.vertices[i-2] - mesh.vertices[i]),
                0);
        }
    }

    [EnableIf("_stopGeneration")]
    [Button]
    public void ChangeAllCollidersTriggerStatus()
    {
        var children = gameObject.GetComponentsInChildren<Collider>();
        bool status = !children[0].isTrigger;
        foreach (var child in children)
            child.isTrigger = status;
    }
}
