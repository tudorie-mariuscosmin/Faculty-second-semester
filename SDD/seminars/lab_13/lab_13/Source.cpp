#include<stdio.h>
#include<malloc.h>
#include<string.h>
#include<memory.h>


struct Student {
	char* name;
	int regNO;
};



struct ListNode {
	Student* info;
	ListNode* next;
};


struct AdjacencyList {
	ListNode* neighbours;
};



struct Graph {
	AdjacencyList* vertices;
	int noVertices;
};
Student* createElement(char* name, int no) {
	Student* stud = (Student*)malloc(sizeof(Student));
	stud->name = (char*)malloc(sizeof(strlen(name)));
	strcpy(stud->name, name);
	stud->regNO = no;
	return stud;

}

Graph* initGraph(int noNodes) {
	Graph* graph = (Graph*)malloc(sizeof(Graph));
	graph->vertices = (AdjacencyList*)malloc(sizeof(AdjacencyList)*noNodes);
	graph->noVertices = noNodes;
	memset(graph->vertices, NULL, sizeof(AdjacencyList)*noNodes);
}
ListNode* createNode(Student* stud) {
	ListNode* node =(ListNode*)malloc(sizeof(ListNode));
	node->info = stud;
	node->next = NULL;
	return node;
}

void addEdge(Graph* graph, Student* startStud, Student* endStud) {//pt graf orientat
	
	
	ListNode * end = createNode(endStud); //0 (nod1)
	ListNode* start = createNode(startStud);//2(nod3)
	if(graph->vertices[startStud->regNO - 1].neighbours == NULL)
		graph->vertices[startStud->regNO - 1].neighbours = start;
	
	
	if (graph->vertices[startStud->regNO - 1].neighbours->next !=NULL) {
		end->next = graph->vertices[startStud->regNO - 1].neighbours->next;
		graph->vertices[startStud->regNO - 1].neighbours->next = end;
	}
	else {
		graph->vertices[startStud->regNO - 1].neighbours->next = end;
		end->next = graph->vertices[startStud->regNO - 1].neighbours;
	}
	

}

Student* createElement(char* name, int no) {
	Student* stud =(Student*) malloc(sizeof(Student));
	stud->name = (char*)malloc(sizeof(strlen(name)));
	strcpy(stud->name, name);
	stud->regNO = no;
	return stud;

}
void main() {
	Graph *graph = initGraph(7);
	FILE* pFile = fopen("Text.txt", "r");
	if (pFile)
	{
		Student** students = NULL;
		
		int noVertices = 0;
		fscanf(pFile,"%d" ,&noVertices);
		int index = 0;
		students =(Student**) malloc(sizeof(Student*)*noVertices);
		memset(students, NULL, sizeof(Student*)*noVertices);

		
		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int key = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &key);
			Student* student = createElement(buffer, key);
			//3.insert element 
			students[index++] = student;
			
		}
		fclose(pFile);

		addEdge(graph, students[0], students[2]);
		addEdge(graph, students[0], students[4]);
		addEdge(graph, students[0], students[5]);
		addEdge(graph, students[1], students[4]);
		addEdge(graph, students[2], students[3]);
		addEdge(graph, students[2], students[4]);
		addEdge(graph, students[2], students[5]);
		addEdge(graph, students[3], students[4]);

		int** adjMat = (int**)malloc(sizeof(int*)*graph->noVertices);
		for (int i = 0; i < graph->noVertices; i++) {
			adjMat[i] = (int*)malloc(sizeof(int)*graph->noVertices);
			memset(adjMat[i], 0, sizeof(int)*graph->noVertices);
		}
		for (int i = 0; i < graph->noVertices; i++) {
			ListNode* tmp = graph->vertices[i].neighbours;
			if (tmp) {
				do {
					adjMat[i][tmp->info->regNO - 1] = 1;

				}
			}
		}
		
		
	}
}