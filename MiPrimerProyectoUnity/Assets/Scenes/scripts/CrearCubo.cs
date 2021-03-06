using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCubo : MonoBehaviour
{
     public GameObject prefabcubo;
    public List<GameObject> listadecubos;
    public float factordeescalamiento;
    public int numcubos = 0;

    // Start is called before the first frame update
    void Start()
    {
        listadecubos = new List<GameObject>();
    }
    private void Awake()
    {
        GameObject gameObject1 = Instantiate<GameObject>(prefabcubo);
        GameObject tempGameObject = gameObject1;
        tempGameObject.name = "CuboEnAwake";
        Color c = new Color(Random.value, Random.value, Random.value);
        tempGameObject.GetComponent<MeshRenderer>().material.color = c;
        tempGameObject.transform.position = Random.insideUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        numcubos++;
        GameObject tempGameObject = Instantiate<GameObject>(prefabcubo);
        tempGameObject.name = "CuboEnUpdate" + numcubos;
        Color c = new Color(Random.value, Random.value, Random.value);
        tempGameObject.GetComponent<MeshRenderer>().material.color = c;
        tempGameObject.transform.position = Random.insideUnitSphere;

        listadecubos.Add(tempGameObject);
        List<GameObject> ObjetosParaEliminar = new List<GameObject>();
        foreach (GameObject go in listadecubos)
        {
            float scale = go.transform.localScale.x;
            scale *= factordeescalamiento;
            go.transform.localScale = Vector3.one * scale;

            if (scale <= 0.1)
            {
                ObjetosParaEliminar.Add(go);
            }

        }
        foreach (GameObject go in ObjetosParaEliminar)
        {
            listadecubos.Remove(go);
            Destroy(go);
        }
    }
    private void OnEnable()
    {
        GameObject tempGameObject = Instantiate<GameObject>(prefabcubo);
        tempGameObject.name = "CuboEnOnEnable";
        Color c = new Color(Random.value, Random.value, Random.value);
        tempGameObject.GetComponent<MeshRenderer>().material.color = c;
        tempGameObject.transform.position = Random.insideUnitSphere;
    }
    private void OnDisable()
    {
        GameObject tempGameObject = Instantiate<GameObject>(prefabcubo);
        tempGameObject.name = "CuboEnOnDisable";
        Color c = new Color(Random.value, Random.value, Random.value);
        tempGameObject.GetComponent<MeshRenderer>().material.color = c;
        tempGameObject.transform.position = Random.insideUnitSphere;
    }
}
