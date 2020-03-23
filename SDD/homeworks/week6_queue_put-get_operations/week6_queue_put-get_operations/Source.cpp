#include "stdio.h"
#include "malloc.h"
#include "string.h"
struct Student
{
	char* name;
	int year;
};
struct ListNode
{
	ListNode* prev;
	Student* info;
	ListNode* next;
};

ListNode* createListNode(char*, int);
void insertListNodeFrontPtr(ListNode**, ListNode*);
void PutQueue(ListNode*& head, char*name, int year);
Student* GetQueue(ListNode*& head);

void main()
{
	FILE* pFile = fopen("Data.txt", "r");
	Student* data = NULL;
	if (pFile)
	{
		int dim = 0, index = 0;
		ListNode* head = NULL;
		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int year = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &year);
			ListNode* node = createListNode(buffer, year);
			insertListNodeFrontPtr(&head, node);
		}
		fclose(pFile);
		
		char nume[100];
		strcpy(nume, "Marius");
		PutQueue(head, nume, 2018);

		//Student* info = GetQueue(head);

		printf("\nList elements:\n");
		ListNode* tmp = head;
		do
		{
			printf("Node address: %X, Student address: %X, student name: %s \n", tmp, tmp->info, tmp->info->name);
			tmp = tmp->next;
		} while (tmp != head);
	}
}

void PutQueue(ListNode*& head, char*name, int year) {
	ListNode* newNode = createListNode(name, year);
	if (head == NULL) {
		head->next = head->prev = newNode;
	}
	else
	{
		head->prev->next = newNode;
		newNode->next = head;
		newNode->prev = head->prev;
	}
}

Student* GetQueue(ListNode*& head) {
	ListNode* tmp = head;
	Student* value;
	if (head->next == head && head->prev==head) {
		value = head->info;
		free(head);
	}
	else {
		value = tmp->info;
		tmp->next->prev = tmp->prev;
		tmp->prev->next = tmp->next;
		head = tmp->next;
		free(tmp);
		return value;
	}





	return value;
}




ListNode* createListNode(char* name, int year)
{
	ListNode* newNode = (ListNode*)malloc(sizeof(ListNode));

	Student* student = (Student*)malloc(sizeof(Student));
	student->name = (char*)malloc(strlen(name) + 1);
	strcpy(student->name, name);
	student->year = year;

	newNode->info = student;
	newNode->next = NULL;
	newNode->prev = NULL;

	return newNode;
}

void insertListNodeFrontPtr(ListNode** head, ListNode* node)
{
	//insertion at the begining of a circular doubly linked list
	if (*head == NULL)
	{
		node->next = node->prev = node;
	}
	else
	{
		//1. connect node  to structure
		node->next = *head;
		node->prev = (*head)->prev;
		//2. connect structure to node
		(*head)->prev->next = node;//1
		(*head)->prev = node;//2
	}
	*head = node;
}