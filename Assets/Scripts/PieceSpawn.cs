using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawn : MonoBehaviour
{
    // Pieza a spawnear
    public GameObject pieceToSpawn;

    // Tiempo de spawn máximo y mínimo en segundos
    public float minSpawnSeconds;
    public float maxSpawnSeconds;

    // Velocidad de movimiento de la pieza spawneada máxima y mínima
    public float minFallingSpeed;
    public float maxFallingSpeed;

    // Tiempo de spawn en segundos
    private float spawnSeconds;

    // Tiempo actual de spawn en segundos
    private float spawnCurrentSeconds;

    // Velocidad de movimiento de la pieza spawneada
    private float fallingSpeed;

    // Lista de carriles a spawnear la pieza
    private List<Vector3> spawnLanes;
    private int spawnLanesPointer;

    // Lista de velocidades límite por posición a spawnear la pieza
    private List<float> fallingSpeedLimits;

    // Identificador de piezas spawneadas
    private int idSpawnPiece;

    // Mapa de spawnLane y lista de identificadores para dicho carril
    private Dictionary<int, List<int>> spawnPieceMap;

    // Start is called before the first frame update
    void Start()
    {
        // Protección del tiempo de spawn mínimo y máximo
        if (minSpawnSeconds < 1.0f)
        {
            minSpawnSeconds = 1.0f;
        }
        if (maxSpawnSeconds < 1.0f)
        {
            maxSpawnSeconds = 1.0f;
        }
        // Protección de la velocidad de movimiento de la pieza mínima y máxima
        if (minFallingSpeed < 1.0f)
        {
            minFallingSpeed = 1.0f;
        }
        if (maxFallingSpeed < 1.0f)
        {
            maxFallingSpeed = 1.0f;
        }
        // Asignación de las posibles carriles a spawnear la pieza
        spawnLanes = new List<Vector3>()
        {
            new Vector3(-4.0f, 0.5f, 0.0f),
            new Vector3(-2.0f, 0.5f, 0.0f),
            new Vector3(0.0f, 0.5f, 0.0f),
            new Vector3(2.0f, 0.5f, 0.0f),
            new Vector3(4.0f, 0.5f, 0.0f)
        };
        // Inicialización del limite de velocidades para cada una de las posiciones
        fallingSpeedLimits = new List<float>()
        {
            maxFallingSpeed,
            maxFallingSpeed,
            maxFallingSpeed,
            maxFallingSpeed,
            maxFallingSpeed
        };
        // Inicialización del identificador para las piezas spawnedas
        idSpawnPiece = -1;
        // Inicialización del mapa para las piezas spawneadas
        spawnPieceMap = new Dictionary<int, List<int>>
        {
            { 0, new List<int>() },
            { 1, new List<int>() },
            { 2, new List<int>() },
            { 3, new List<int>() },
            { 4, new List<int>() }
        };
        // Calcular los atributos
        CalculateAttibutes(true);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        // Comprobar si se puede spawnear una pieza
        if (spawnCurrentSeconds < spawnSeconds)
        {
            spawnCurrentSeconds += Time.deltaTime;
        }
        else
        {
            // En el caso de spawnear pieza, comprobar si existe prefab de la pieza a spawnear
            if (pieceToSpawn)
            {
                // Crear una instancia del prefab pieceToSpawn
                GameObject gObj = Instantiate(pieceToSpawn, spawnLanes[spawnLanesPointer], Quaternion.identity) as GameObject;
                // Pasarle los parámetros necesarios a la pieza spawneada
                ProvideParametersToSpawnPiece(gObj);
            }
            // Volver a calcular los atributos
            CalculateAttibutes(false);
        }
    }

    public void ProvideParametersToSpawnPiece(GameObject gObj)
    {
        // Agregar la nueva pieza instanciada al mapa de piezas instanciadas
        AddNewPieceToSpawnPieceMap();
        // Comprobar si la velocidad a proporcionar a la pieza spawneada supera o no el límite permitido de dicho carril
        float finalFallingSpeed = fallingSpeed;
        if (fallingSpeed <= fallingSpeedLimits[spawnLanesPointer])
        {
            // En el caso de que no lo supere asignarle la velocidad calculada
            if (fallingSpeed < fallingSpeedLimits[spawnLanesPointer])
            {
                // Ajustar la velocidad límite del carril a la velocidad calculada
                fallingSpeedLimits[spawnLanesPointer] = fallingSpeed;
            }
        }
        else
        {
            // En el caso de que lo supere asignarle la velocidad límite del carril
            finalFallingSpeed = fallingSpeedLimits[spawnLanesPointer];
        }
        gObj.GetComponent<PieceFalling>().RecieveParameter(idSpawnPiece, spawnLanesPointer, finalFallingSpeed, this);
    }

    public void AddNewPieceToSpawnPieceMap()
    {
        // Crear un identificador para la pieza spawneada e introducirlo en el mapa de spawnPieces
        idSpawnPiece++;
        spawnPieceMap.TryGetValue(spawnLanesPointer, out List<int> spawnPieceMapValue);
        spawnPieceMapValue.Add(idSpawnPiece);
    }

    public void RemovePieceFromSpawnPieceMap(int pieceId, int pieceLane)
    {
        // Obtener todas las piezas que se encuentran en el mismo carril que la propia pieza a eliminar
        spawnPieceMap.TryGetValue(pieceLane, out List<int> spawnPieceMapValue);
        // Eliminar la pieza
        spawnPieceMapValue.Remove(pieceId);
        // Comprobar si el carril se encuentra vacío
        if (spawnPieceMapValue.Count == 0)
        {
            // Modificar la velocidad límite del carril a la máxima posible
            fallingSpeedLimits[pieceLane] = maxFallingSpeed;
        }
    }

    public void CalculateAttibutes(bool firstTime)
    {
        // Calcular el tiempo de spawn de una nueva pieza junto con su carril de salida y su velocidad
        // Asignación de tiempo de spawn y tiempo actual en función de si es la primera vez que se llama o las siguientes
        spawnSeconds = Random.Range(minSpawnSeconds, maxSpawnSeconds);
        if (firstTime)
        {
            spawnCurrentSeconds = spawnSeconds;
        }
        else
        {
            spawnCurrentSeconds = 0.0f;
        }
        // Asignación de las posibles carriles a spawnear la pieza
        spawnLanesPointer = Random.Range(0, 5);
        // Asignación de velocidad de movimiento de la pieza a spawnear
        fallingSpeed = Random.Range(minFallingSpeed, maxFallingSpeed);
    }
}
