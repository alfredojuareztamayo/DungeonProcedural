using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerators : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 size;    // Tama�o de la cuadr�cula del laberinto
    public int startPosition = 0; // Posici�n inicial en la cuadr�cula
    public GameObject room; // Prefab de la habitaci�n para instanciar
    public GameObject roomFake; // Prefab de la habitaci�n para instanciar
    public Vector2 offset; //la distancia entre cada cuarto

    // Lista de celdas que representan la cuadr�cula del laberinto
    List<Cell> board = new List<Cell>();
    void Start()
    {
        mazeGenerator();
    }

    // M�todo para generar el dungeon (laberinto) en el mundo 3D
    void GenerateDungeon()
    {
        // Itera a trav�s de la cuadr�cula del laberinto
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j * size.x)];
                // Si la celda ha sido visitada, instancia una habitaci�n en la posici�n correspondiente
                if (currentCell.visited)
                {
                    var newRoom = Instantiate(room, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehaviours>();
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
    // M�todo para generar el laberinto usando el algoritmo de BFS
    void mazeGenerator()
    {
        // Inicializa la lista de celdas
        board = new List<Cell>();
        // Llena la cuadr�cula con celdas sin visitar
        for (int i = 0; i<size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }
        // Inicializa la posici�n actual en la cuadr�cula
        int currentCell = startPosition;

        // Cola que almacenar� el camino durante la generaci�n del laberinto
        Queue<int> path = new Queue<int>();

        // Variable para evitar bucles infinitos
        int k = 0;
        // Bucle principal para la generaci�n del laberinto
        while (k < 1000)
        {
            k++;
            // Marca la celda actual como visitada
            board[currentCell].visited = true;
            // Verifica si se alcanz� la �ltima celda de la cuadr�cula
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
                // Si hay un camino en la cola, retrocede al �ltimo punto de decisi�n
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
                // Compara las posiciones para determinar la direcci�n del camino
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
        // Llama al m�todo para generar el dungeon en el mundo 3D
        GenerateDungeon();
    }

    // M�todo para verificar los vecinos de una celda dada
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
        { //tengo que revisar el residuo de cells por lo tanto Si el resto no es cero, significa que el vecino derecho no est� al final de la fila.
          //
            neighbors.Add(Mathf.FloorToInt(cell + 1 ));
        }
        //check los vecinos left
        if (cell  % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)    //
        { //tengo que revisar el residuo de cells por lo tanto Si el resto no es cero, significa que el vecino izquirdo no est� al final de la fila.
          //
            neighbors.Add(Mathf.FloorToInt(cell -1));
        }

        return neighbors;
    }
}
