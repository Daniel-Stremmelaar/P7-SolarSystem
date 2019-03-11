using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]

public class PlanetMaker : MonoBehaviour {

    [Header("Materials")]
    public Material surfaceMat;
    public Material cloudMat;
    public Material atmosphereMat;

    [Space]

    [Header("Surface Textures")]
    public Texture2D albedo;
    public Texture2D normal;
    public float normalStrength;
    public Texture2D specular;
    public Color specularColor;
    public float specularIntensity;

    [Space]

    [Header("Clouds")]
    public Texture2D cloudAlpha;
    [ColorUsage(true, true)]
    public Color cloudColor;
    [Space]
    [Tooltip("Degrees per second")]
    public Vector3 cloudRotation;
    public float cloudHeight;

    [Space]

    [Header("Atmosphere")]
    [ColorUsage(true,true)]
    public Color atmosphereColor;
    public float fresnelPower;

    [Space]

    [Header("Base Components")]
    public float planetSize;
    public Mesh planetMesh;
    [Space]
    public bool hasClouds;
    public bool hasAtmosphere;

    // Private and non-interactable values //

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private GameObject planetObject;
    private GameObject cloudsObject;
    private GameObject atmosphereObject;

    //[Space]

    //public bool executeInEditMode;



    private void Start()
    {
        Material surfaceMaterial = CreateSurfaceMaterial();

        CreatePlanet(planetMesh, planetSize, surfaceMaterial);

        if (hasClouds)
        {
            CreateClouds();
        }

        if (hasAtmosphere)
        {
            CreateAtmosphere();
        }
    }

    private void Update()
    {
        if (hasClouds)
        {
            cloudsObject.transform.Rotate(cloudRotation * Time.deltaTime);
            UpdateClouds();
        }

        if (hasAtmosphere)
        {
            UpdateAtmosphere();
        }

        UpdatePlanet(planetSize);
    }

    private Material CreateSurfaceMaterial()
    {
        Material m = new Material(surfaceMat);
        m.SetTexture("_Albedo", albedo);
        m.SetTexture("_Normal", normal);
        m.SetFloat("_NormalStrength", normalStrength);
        m.SetTexture("_SpecularMap", specular);
        m.SetColor("_SpecularColor", specularColor);
        m.SetFloat("_SpecularIntensity", specularIntensity);

        return m;
    }

    private void UpdateClouds()
    {
        GameObject c = cloudsObject;
        Material cMat = c.GetComponent<MeshRenderer>().material;

        float cloudScale = planetSize + cloudHeight;
        cloudsObject.transform.localScale = new Vector3(cloudScale, cloudScale, cloudScale);

        cMat.SetColor("_CloudColor", cloudColor);
        cMat.SetTexture("_Alpha", cloudAlpha);
    }

    private void UpdateAtmosphere()
    {
        GameObject a = atmosphereObject;

        float atmosScale = planetSize + cloudHeight + 0.01f;
        Material aMat = a.GetComponent<MeshRenderer>().material;
        a.transform.localScale = new Vector3(atmosScale, atmosScale, atmosScale);

        aMat.SetColor("_Color", atmosphereColor);
        aMat.SetFloat("_FresnelPower", fresnelPower);
    }

    private void UpdatePlanet(float size)
    {
        GameObject g = planetObject;

        g.transform.localScale = new Vector3(size, size, size);
        g.transform.localPosition = new Vector3(0, 0, 0);

        Material m = surfaceMat;

        m.SetTexture("_Albedo", albedo);
        m.SetTexture("_Normal", normal);
        m.SetFloat("_NormalStrength", normalStrength);
        m.SetTexture("_SpecularMap", specular);
        m.SetColor("_SpecularColor", specularColor);
        m.SetFloat("_SpecularIntensity", specularIntensity);
    }

    private void CreatePlanet(Mesh mesh, float size, Material material)
    {
        GameObject g = new GameObject("Surface");
        g.transform.SetParent(gameObject.transform);
        g.transform.localScale = new Vector3(size, size, size);
        g.transform.localPosition = new Vector3(0, 0, 0);

        g.AddComponent(typeof(MeshRenderer));
        meshRenderer = g.GetComponent<MeshRenderer>();
        g.AddComponent(typeof(MeshFilter));
        meshFilter = g.GetComponent<MeshFilter>();
        meshFilter.mesh = planetMesh;

        meshRenderer.material = material;

        planetObject = g;
    }

    private void CreateClouds()
    {
        cloudsObject = Instantiate(planetObject, gameObject.transform);
        Material cMat = new Material(cloudMat);
        cloudsObject.GetComponent<MeshRenderer>().material = cMat;
        float cloudScale = planetSize + cloudHeight;
        cloudsObject.transform.localScale = new Vector3(cloudScale, cloudScale, cloudScale);

        cMat.SetColor("_Color", cloudColor);
        cMat.SetTexture("_Alpha", cloudAlpha);
    }

    private void CreateAtmosphere()
    {
        atmosphereObject = Instantiate(planetObject, gameObject.transform);
        Material aMat = new Material(atmosphereMat);
        atmosphereObject.GetComponent<MeshRenderer>().material = aMat; 
        float atmosScale = planetSize + cloudHeight + 0.01f;
        atmosphereObject.transform.localScale = new Vector3(atmosScale, atmosScale, atmosScale);

        aMat.SetColor("_Color", atmosphereColor);
        aMat.SetFloat("_FresnelPower", fresnelPower);
    }
}
