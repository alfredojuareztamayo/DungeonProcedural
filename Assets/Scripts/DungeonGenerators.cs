using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerators : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 size;    // Tamaño de la cuadrícula del laberinto
    public int startPosition = 0; // Posición inicial en la cuadrícula
    public GameObject[] room; // Prefab de la habitación para instanciar
    public GameObject roomFake; // Prefab de la habitación para instanciar
    public Vector2 offset; //la distancia entre cada cuarto

    // Lista de celdas que representan la cuadrícula del laberinto
    List<Cell> board = new List<Cell>();
    void Start()
    {
        mazeGenerator();
    }

    // Método para generar el dungeon (laberinto) en el mundo 3D
    void GenerateDungeon()
    {
        // Itera a través de la cuadrícula del laberinto
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j * size.x)];
                GameObject roomRandom = room[Random.Range(0, 5)];
                // Si la celda ha sido visitada, instancia una habitación en la posición correspondiente
                if (currentCell.visited)
                {
                   
                    var newRoom = Instantiate(roomRandom, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehaviours>();
                    newRoom.updateRooms(board[Mathf.FloorToInt(i + j * size.x)].state);

                    newRoom.name += " " + i + "-" + j;
                }
                //else
                //{
                //   var newFake = Instantiate(roomFake, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform);
                //    newFake.name  += " " + i + "-" + j;
                //}
            }
        }
    }
    // Método para generar el laberinto usando el algoritmo de BFS
    void mazeGenerator()
    {
        // Inicializa la lista de celdas
        board = new List<Cell>();
        // Llena la cuadrícula con celdas sin visitar
        for (int i = 0; i<size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }
        // Inicializa la posición actual en la cuadrícula
        int currentCell = startPosition;

        // Cola que almacenará el camino durante la generación del laberinto
        Queue<int> path = new Queue<int>();

        // Variable para evitar bucles infinitos
        int k = 0;
        // Bucle principal para la generación del laberinto
        while (k < 1000)
        {
            k++;
            // Marca la celda actual como visitada
            board[currentCell].visited = true;
            // Verifica si se alcanzó la última celda de la cuadrícula
            if (currentCell == board.Count - 1)
            {
                break;
            }
            ///check the cells neighbors
            // Obtiene los vecinos de la celda actual
            List<int> neighbors = checkNeightboor(currentCell);
            // Si la celda no tiene vecinos disponibles
            if (neighbors.Count == 0) 
            {
                // Si hay un camino en la cola, retrocede al último punto de decisión
                if (path.Count == 0)
                {
                    break;
                    //esto es debido a que si se llega a 0 significa que llegamos a la ultima celda disponible muajaj
                }
                else
                {

                    currentCell = path.Dequeue();
                }
            }
            else
            {
                // Agrega la celda actual al camino
                path.Enqueue(currentCell);
                // Elige un nuevo vecino aleatorio
                int newCell = neighbors[Random.Range(0, neighbors.Count)];
                // Compara las posiciones para determinar la dirección del camino
                if (newCell > currentCell)
                {

                    //Verifica si las paredes deben de abrirse a la down o right
                    if(newCell -1 == currentCell)
                    {
                        board[currentCell].state[2] = true;
                        currentCell = newCell;
                        board[currentCell].state[3] = true;
                    }
                    else
                    {
                        board[currentCell].state[1] = true;
                        currentCell = newCell;
                        board[currentCell].state[0] = true;
                    }
                }
                else
                {
                    //Verifica si las paredes deben de abrirse a la up o left
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].state[3] = true;
                        currentCell = newCell;
                        board[currentCell].state[2] = true;
                    }
                    else
                    {
                        board[currentCell].state[0] = true;
                        currentCell = newCell;
                        board[currentCell].state[1] = true;
                    }
                }
            }
            
        }
        // Llama al método para generar el dungeon en el mundo 3D
        GenerateDungeon();
    }

    // Método para verificar los vecinos de una celda dada
    List<int> checkNeightboor(int cell)
    {
        List<int> neighbors = new List<int>();
        //check los vecinos up
        // Verifica los vecinos hacia arriba
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell-size.x)].visited)    //aqui reviso que el vecino no este fuera de mi grid, cell aparte de revisar que mi vecino no haya sido visitado
        { 
            neighbors.Add(Mathf.FloorToInt(cell-size.x));
        }
        //check los vecinos down
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited)    //aqui reviso que el vecino no este fuera de mi board, cell aparte de revisar que mi vecino no haya sido visitado
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }
        //check los vecinos right
        if ((cell+1) % size.x != 0 && !board[Mathf.FloorToInt(cell +1)].visited)    //
        { //tengo que revisar el residuo de cells por lo tanto Si el resto no es cero, significa que el vecino derecho no está al final de la fila.
          //
            neighbors.Add(Mathf.FloorToInt(cell + 1 ));
        }
        //check los vecinos left
        if (cell  % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)    //
        { //tengo que revisar el residuo de cells por lo tanto Si el resto no es cero, significa que el vecino izquirdo no está al final de la fila.
          //
            neighbors.Add(Mathf.FloorToInt(cell -1));
        }

        return neighbors;
    }
}
