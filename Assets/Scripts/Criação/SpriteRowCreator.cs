using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpriteRowCreator : MonoBehaviour
{
    [SerializeField] public bool isRuntime;

    [SerializeField] public GameObject[] gameObjectToBeCreated; //GameObject To Be Created
    [SerializeField] public int howMany; //How many instances
    [SerializeField] public RowCreatorOptions rowCreatorOptions; //Kind of creation

    [SerializeField] public float minDistance; //Min Distance to a new Game Object position
    [SerializeField] public float maxDistance; //Max Distance to a new Game Object position
    [SerializeField] public float yVariance; //If you want some height variation
    [SerializeField] public float distance; //The distance from fixed distance

    [SerializeField] public bool hasStartTerminator; //If your sprite sequence have a first sprite
    [SerializeField] public bool hasEndTerminator; // If your sprite sequence have a defined last sprite
    [SerializeField] public GameObject startTerminator; //The first sprite when available
    [SerializeField] public GameObject endTerminator; //The last sprite when available
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    private float positionToNextInstance = 0;

    public void Start ()
    {
        if (isRuntime)
            CreateSprites ();
    }

	public void CreateSprites ()
    {
        int index;
		float lastPosition = 0;
		float nextPosition = 0;
		GameObject newInstance = null;

        for (int i = 0 ; i<howMany ; i++)
        {
            index = Random.Range(0, gameObjectToBeCreated.Length);
            switch(rowCreatorOptions)
            {
                case RowCreatorOptions.exactMatch:
                {
                    spriteRenderers = new SpriteRenderer [gameObjectToBeCreated.Length];
                    for (int j = 0 ; j<gameObjectToBeCreated.Length ; j++)
                        spriteRenderers[j] = gameObjectToBeCreated[j].GetComponent<SpriteRenderer>();

				    newInstance = Instantiate(gameObjectToBeCreated[index], transform.position + new Vector3 (i*spriteRenderers[index].sprite.bounds.size.x,0,0), gameObjectToBeCreated[index].transform.rotation) as GameObject;
                    break;
                }
                case RowCreatorOptions.atTheEndOfTheLastOne:
                {
                    newInstance = Instantiate(gameObjectToBeCreated[index], new Vector3 (positionToNextInstance,transform.position.y,0), gameObjectToBeCreated[index].transform.rotation) as GameObject;
                    positionToNextInstance = MajorBorder(newInstance);
                    break;
                }
                case RowCreatorOptions.fixedDistance:
                {
				    newInstance = Instantiate(gameObjectToBeCreated[index], transform.position + new Vector3 (i*distance,0,0), gameObjectToBeCreated[index].transform.rotation) as GameObject;
                    break;
                }
                case RowCreatorOptions.fixedDistanceWithHeightVariation:
                {
                    newInstance = Instantiate(gameObjectToBeCreated[index], transform.position + new Vector3 (i*distance,Random.Range(-yVariance,yVariance),0), gameObjectToBeCreated[index].transform.rotation) as GameObject;
                    break;
                }
                case RowCreatorOptions.variableDistance:
                {
    				nextPosition = lastPosition + Random.Range(minDistance, maxDistance);
    				newInstance = Instantiate(gameObjectToBeCreated[index], transform.position + new Vector3 (nextPosition,0,0), gameObjectToBeCreated[index].transform.rotation) as GameObject;
    				lastPosition = nextPosition;
                    break;
			    }
                case RowCreatorOptions.variableDistanceWithHeightVariation:
                {
                    nextPosition = lastPosition + Random.Range(minDistance, maxDistance);
                    newInstance = Instantiate(gameObjectToBeCreated[index], transform.position + new Vector3 (nextPosition,Random.Range(-yVariance,yVariance),0), gameObjectToBeCreated[index].transform.rotation) as GameObject;
                    lastPosition = nextPosition;
                    break;
                }
            }

            if (hasStartTerminator && i == 0)
                newInstance = ReplaceInstanceByNewOne (newInstance, startTerminator);

            if (hasEndTerminator && i == (howMany-1))
                newInstance = ReplaceInstanceByNewOne (newInstance, endTerminator);
            
                newInstance.transform.parent = transform;
        }
    }

    private GameObject ReplaceInstanceByNewOne (GameObject originalInstance, GameObject replacer)
    {
        Vector3 newInstancePosition;
        newInstancePosition = originalInstance.transform.position;
        DestroyImmediate (originalInstance.gameObject);
        return (Instantiate (replacer, newInstancePosition, replacer.transform.rotation) as GameObject);
    }

    public float MajorBorder (GameObject composedObject)
    {
        float champion = 0;
        SpriteRenderer[] severalSpriteRenderers = composedObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sR in severalSpriteRenderers)
        {
            if (champion < sR.sprite.bounds.size.x + sR.transform.position.x)
            {
                champion = sR.sprite.bounds.size.x + sR.transform.position.x;
            }
        }
        return champion;
    }
}

[System.Serializable]
public enum RowCreatorOptions
{
	exactMatch,
    atTheEndOfTheLastOne,
	fixedDistance,
	variableDistance,
    fixedDistanceWithHeightVariation,
    variableDistanceWithHeightVariation
}

#if UNITY_EDITOR
[CustomEditor(typeof(SpriteRowCreator))]
[CanEditMultipleObjects]
public class SpriteRowCreatorInspector : Editor
{
    SerializedProperty startSpriteToBeCreated;
    SerializedProperty endSpriteToBeCreated;
    SerializedProperty gameObjectToBeCreated;
    
    public void OnEnable ()
    {
        startSpriteToBeCreated = serializedObject.FindProperty("startTerminator");
        endSpriteToBeCreated = serializedObject.FindProperty("endTerminator");
        gameObjectToBeCreated = serializedObject.FindProperty ("gameObjectToBeCreated");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update(); //Update serialized object's representation.
        
        SpriteRowCreator myScript = (SpriteRowCreator)target;

        myScript.isRuntime = EditorGUILayout.Toggle("Is Runtime", myScript.isRuntime);

        //Creation Type
        myScript.rowCreatorOptions = (RowCreatorOptions)EditorGUILayout.EnumPopup("Creation type:",myScript.rowCreatorOptions);
        
        //StartTerminator
        myScript.hasStartTerminator = EditorGUILayout.Toggle("Start Terminator", myScript.hasStartTerminator);
        if (myScript.hasStartTerminator)
            EditorGUILayout.PropertyField(startSpriteToBeCreated, true);
        
        //EndTerminator
        myScript.hasEndTerminator = EditorGUILayout.Toggle("End Terminator", myScript.hasEndTerminator);
        if (myScript.hasEndTerminator)
            EditorGUILayout.PropertyField(endSpriteToBeCreated, true);
        
        //How many sprites will be created
        myScript.howMany = EditorGUILayout.IntField("How many:" ,myScript.howMany);
        
        //Creation Type variables
        switch (myScript.rowCreatorOptions)
        {
            case RowCreatorOptions.fixedDistance:
                myScript.distance = EditorGUILayout.FloatField("Distance:", myScript.distance);
                break;
            case RowCreatorOptions.variableDistance:
                myScript.minDistance = EditorGUILayout.FloatField("Min Distance:", myScript.minDistance);
                myScript.maxDistance = EditorGUILayout.FloatField("Max Distance:", myScript.maxDistance);
                break;
            case RowCreatorOptions.fixedDistanceWithHeightVariation:
                myScript.distance = EditorGUILayout.FloatField("Distance:", myScript.distance);
                myScript.yVariance = EditorGUILayout.FloatField("yVariance:", myScript.yVariance);
                break;
            case RowCreatorOptions.variableDistanceWithHeightVariation:
                myScript.minDistance = EditorGUILayout.FloatField("Min Distance:", myScript.minDistance);
                myScript.maxDistance = EditorGUILayout.FloatField("Max Distance:", myScript.maxDistance);
                myScript.yVariance = EditorGUILayout.FloatField("yVariance:", myScript.yVariance);
                break;
        }
        
        //Draw Sprite List
        EditorGUILayout.PropertyField(gameObjectToBeCreated, true);
        
        if(GUILayout.Button("Create Sprites"))
            myScript.CreateSprites();
        
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(myScript);
    }


}
#endif