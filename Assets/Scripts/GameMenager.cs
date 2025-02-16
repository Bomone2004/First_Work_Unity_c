using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    PrimitiveType primitiveToPlace;

    Vector3 nextShapePreviewPos = new Vector3(-7, 1, 1);

    GameObject previewObject;
    

    private void Start()
    {
        GenerateNextShape();
    }

    void GenerateNextShape()
    {
        string objectTag = null;

        switch (Random.Range(0, 4)) //0..3 (4 è escluso)
        {
            case 0:
                primitiveToPlace = PrimitiveType.Cube;
                objectTag = "Block1"; break;
            case 1:
                primitiveToPlace = PrimitiveType.Sphere;
                objectTag = "Block2"; break;
            case 2:
                primitiveToPlace = PrimitiveType.Capsule;
                objectTag = "Block3"; break;
            case 3: 
                primitiveToPlace = PrimitiveType.Cylinder;
                objectTag = "Block4"; break;
            default: 
                primitiveToPlace = PrimitiveType.Cube;
                objectTag = "Block1"; break;

        }

        if (previewObject) Destroy(previewObject);

        previewObject = GameObject.CreatePrimitive(primitiveToPlace);
        previewObject.name = "Preview shape";
        previewObject.tag = objectTag;
        previewObject.transform.position = nextShapePreviewPos;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject go = GameObject.CreatePrimitive(primitiveToPlace);

                go.tag = previewObject.tag;
                go.transform.localScale = Vector3.one * 0.3f;
                go.transform.position += hit.point + new Vector3(0, 1f, 0);
                go.transform.rotation = Random.rotation;

                //Block block = go.AddComponent<Block>();

                switch (primitiveToPlace)
                {
                    case PrimitiveType.Cube: go.name = "5"; break;
                    case PrimitiveType.Sphere: go.name = "10"; break;
                    case PrimitiveType.Capsule: go.name = "15"; break;
                    case PrimitiveType.Cylinder: go.name = "20"; break;
                }

                go.AddComponent<Rigidbody>();

                Color randomColor = Random.ColorHSV();

                float H, S, V;
                Color.RGBToHSV(randomColor, out H, out S, out V);

                S = 0.8f;
                V = 0.8f;

                randomColor = Color.HSVToRGB(H, S, V);

                go.GetComponent<MeshRenderer>().material.color = randomColor;

                Texture texture = Resources.Load<Texture>("wood_texture");

                Debug.Log(texture);

                go.GetComponent<MeshRenderer>().material.mainTexture = texture;
                go.AddComponent<DestroyOnFall>();
                go.AddComponent<DragWithMouse>();
                go.AddComponent<StopContrast>();

                GenerateNextShape();
            }
        }
    }
}
