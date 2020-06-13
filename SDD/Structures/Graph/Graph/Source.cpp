#include<stdio.h>
#include<malloc.h>
#include<string.h>

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

Student* createStudent(char* name, int reg) {
	Student* stud = (Student*)malloc(sizeof(Student));
	stud->name = (char*)malloc(strlen(name) + 1);
	strcpy(stud->name, name);
	stud->regNo = reg;
	return stud;
}

Graph* initGraph(int noVertices) {
	Graph* graph = (Graph*)malloc(sizeof(Graph));
	graph->noVertices = noVertices;
	graph->vertices = (AdjacencyList*)malloc(sizeof(AdjacencyList)* noVertices);
	memset(graph->vertices, NULL, sizeof(AdjacencyList)* noVertices);
	return graph;
}

ListNode* createNode(Student* stud) {
	ListNode* node = (ListNode*)malloc(sizeof(ListNode));
	node->info = stud;
	node->next = NULL;
	return node;
}
void addEdge(Graph* graph, Student* start, Student* stop) {
	ListNode* startN = createNode(start);
	ListNode* stopN = createNode(stop);
	stopN->next = graph->vertices[start->regNo].neighbours;
	graph->vertices[start->regNo].neighbours = stopN;

	startN->next = graph->vertices[stop->regNo].neighbours;
	graph->vertices[stop->regNo].neighbours = startN;
}

void main() {
	FILE* file = fopen("Data.txt", "r");
	Student** students = NULL;
	Graph* graph = NULL;
	int index = 0;
	if (file) {
		int noVertices = 0;
		fscanf(file, "%d", &noVertices);
		students = (Student**)malloc(sizeof(Student*)*noVertices);
		memset(students, NULL, sizeof(Student*)*noVertices);
		graph = initGraph(noVertices);
		while (!feof(file))
		{
			char buffer[50];
			int regNo;
			fscanf(file, "%s", buffer);
			fscanf(file, "%d", &regNo);
			Student* stud = createStudent(buffer, regNo);
			students[index++] = stud;
		}
	}fclose(file);

	addEdge(graph, students[0], students[1]);
	addEdge(graph, students[0], students[4]);
	addEdge(graph, students[1], students[3]);
	addEdge(graph, students[1], students[5]);
	addEdge(graph, students[1], students[6]);
	addEdge(graph, students[2], students[3]);
	addEdge(graph, students[2], students[4]);
	addEdge(graph, students[2], students[6]);
	addEdge(graph, students[3], students[5]);
}