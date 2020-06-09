#include "stdio.h"
#include "malloc.h"
#include "string.h"
struct Student
{
	char* name;
	int regNo;
};
struct ListNode
{
	Student* info;
	ListNode* next;
};
struct AdjacencyList
{
	ListNode* neighbours;
};
struct Graph
{
	AdjacencyList* vertices;
	int noVertices;
};
ListNode* createNode(Student* stud)
{
	ListNode* node = (ListNode*)malloc(sizeof(ListNode));
	node->info = stud;
	node->next = NULL;
	return node;
}
Student* createElement(char* name, int regNo)
{
	Student* stud = NULL;
	stud = (Student*)malloc(sizeof(Student));
	stud->regNo = regNo;
	stud->name = (char*)malloc(strlen(name) + 1);
	strcpy(stud->name, name);
	return stud;
}
Graph* initGraph(int noNode)
{
	Graph* graph = (Graph*)malloc(sizeof(Graph));
	graph->noVertices = noNode;
	graph->vertices = (AdjacencyList*)malloc(sizeof(AdjacencyList)*graph->noVertices);
	memset(graph->vertices, NULL, sizeof(AdjacencyList)*graph->noVertices);
	return graph;
}
void addEdge(Graph* graph, Student* start, Student* stop)
{
	ListNode* startN = createNode(start);
	ListNode* stopN = createNode(stop);
	//e.g edge (start:0 - stop:1)
	stopN->next = graph->vertices[start->regNo].neighbours;
	graph->vertices[start->regNo].neighbours = stopN;
	//e.g edge (start:1 - stop:0)
	startN->next = graph->vertices[stop->regNo].neighbours;
	graph->vertices[stop->regNo].neighbours = startN;
}
int** loadAdjMat(Graph* graph, int noNodes) {
	int** adjMat = (int**)malloc(sizeof(int*)*noNodes);
	for (int i = 0; i < noNodes; i++) {
		adjMat[i] = (int*)malloc(sizeof(int)*noNodes);
		memset(adjMat[i], 0, sizeof(int)*noNodes);
	}
	for (int j = 0; j < noNodes; j++) {
		ListNode* tmp = graph->vertices[j].neighbours;
		while (tmp != NULL) {
			adjMat[j][tmp->info->regNo] = 1;
			tmp = tmp->next;
		}

	}


	return adjMat;
}

void printAdjMat(int** adjMatrix, int noVertices) {
	for (int i = 0; i < noVertices; i++) {
		for (int j = 0; j < noVertices; j++) {
			printf("%2d", adjMatrix[i][j]);
		}
		printf("\n");
	}
}

void BF(int** adjMatrix, int noNodes, int StartVertex) {
	int* visited = NULL;
	int* queue = NULL;
	int first = 0;
	int last = -1;
	visited = (int*)malloc(sizeof(int)*noNodes);
	queue = (int*)malloc(sizeof(int)*noNodes);
	memset(visited, 0, sizeof(int)*noNodes);
	visited[StartVertex] = 1;
	queue[++last] = StartVertex;
	while (last >= first) {
		for (int i = 0; i < noNodes; i++) {
			if (visited[i] == 0 && adjMatrix[i][queue[first]] == 1) {
				visited[i] = 1;
				queue[++last] = i;
			}
		}
		printf("%2d", queue[first++]);

	}


}

void main()
{
	FILE* pFile = fopen("Data.txt", "r");
	Student** students = NULL;
	Graph* graph = NULL;
	if (pFile)
	{
		int noVertices = 0;
		fscanf(pFile, "%d", &noVertices);
		students = (Student**)malloc(sizeof(Student*)*noVertices);
		memset(students, NULL, sizeof(Student*)*noVertices);
		graph = initGraph(noVertices);
		int index = 0;
		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int regNo = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &regNo);
			Student* student = createElement(buffer, regNo);
			//3.insert student into array
			students[index++] = student;
		}
		fclose(pFile);
		addEdge(graph, students[0], students[1]);
		addEdge(graph, students[0], students[4]);
		addEdge(graph, students[1], students[3]);
		addEdge(graph, students[1], students[5]);
		addEdge(graph, students[1], students[6]);
		addEdge(graph, students[2], students[3]);
		addEdge(graph, students[2], students[4]);
		addEdge(graph, students[2], students[6]);
		addEdge(graph, students[3], students[5]);


		int** adjMatrix = loadAdjMat(graph, noVertices);
		printAdjMat(adjMatrix, noVertices);

		for (int i = 0; i < noVertices; i++) {
			printf("\n Traveelsar for a graph starting from : %d", i);
			BF(adjMatrix, noVertices, i); //parcurgere breth first
		}
	}
}