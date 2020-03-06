#include "stdio.h"
#include "malloc.h"
#include"string.h"


struct Student
{
	char* name;
	int year;
};

struct List
{
	Student* info;
	List* next;
};

void printArray(Student* arr, int dim) {
	for (int i = 0; i < dim; i++) {
		printf("Student: %s , year: %d\n", arr[i].name, arr[i].year);

	}
}

List* createNodeList(Student* student) {
	List* newNode = (List*)malloc(sizeof(List*));
	newNode->next = NULL;
		//golden rule : when you create a new element all connections should be set to null :))) (not that golden of you ask me)
	newNode->info = student;
	return newNode;
}

void isertNodeList(List** head, List* node){
	if (*head == NULL)
		*head = node;
	else
	{
		//insertion at the beggining of the list
		node->next = *head;
		*head = node;
	}
}

void main()
{
	FILE *pFile = fopen("data.txt", "r");
	Student* data = NULL;
	if (pFile) {
		int index = 0;
		int dim = 0;
		fscanf(pFile, "%d", &dim);
		data = (Student*)malloc(sizeof(Student)*dim);
		while (!feof(pFile))
		{
			// 1. read the name
			char buffer[50];
			fscanf(pFile, "%s", buffer);
			//2. read the year
			int year = 0;
			fscanf(pFile, "%d", &year);
			//3. Store  the student's data in the array of the index position

			data[index].name = (char*)malloc((strlen(buffer) + 1) * sizeof(char));
			strcpy(data[index].name, buffer);
			data[index].year = year;
			index++;

		}




		fclose(pFile);

		printArray(data, dim);

		List* head = NULL;

		for (int i = 0; i < dim; i++)
		{
			List* node  = createNodeList(&data[i]);
			isertNodeList(&head, node);

		}



	}



}