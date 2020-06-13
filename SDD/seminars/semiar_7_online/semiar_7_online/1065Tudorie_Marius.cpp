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
//DummyNode
struct Queue
{
	ListNode* head = NULL;
	ListNode* tail = NULL;
};

ListNode* createListNode(char*, int);

void pushListNode(ListNode*& head, ListNode*);
Student* popListNode(ListNode*& headStack);
Student* peekListNode(ListNode*);

void putListNode(Queue&, ListNode*);
Student* getListNode(Queue&);
void main()
{
	FILE* pFile = fopen("Data.txt", "r");
	Student* data = NULL;
	if (pFile)
	{
		ListNode* head = NULL;
		Queue queue;
		ListNode* stack = NULL;


		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int year = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &year);
			ListNode* node = createListNode(buffer, year);
			pushListNode(stack, node);
			putListNode(queue, node);
			
		}
		fclose(pFile);
		

		/*while (stack)
		{

			Student* stud = peekListNode(stack);
			popListNode(stack);
			printf("Student %s \n", stud->name);
		}*/

		
		char* aux = queue.head->info->name;
		do {
			Student* stud = getListNode(queue);
			printf("Student %s \n", stud->name);
			ListNode* node = createListNode(stud->name, stud->year);
			putListNode(queue, node);
		} while (strcmp(aux, queue.head->info->name) != 0);
		

		
	}
}


Student* getListNode(Queue& queue) {
	Student* value = NULL;
	if (queue.head != NULL && queue.tail != NULL)
	{
		//if(queue.head = queue.tail) conditii identice
		if (queue.head->next == NULL) {
			value = queue.head->info;
			free(queue.head);
			queue.head = queue.tail = NULL;
			
		}
		else
		{
			ListNode* tmp = queue.head;
			queue.head = queue.head->next;
			queue.head->prev = NULL;
			value = tmp->info;
			free(tmp);
		}
	}
	return value;
}

void putListNode(Queue& queue, ListNode* node)
{
	if (queue.head == NULL && queue.tail == NULL)
	{
		queue.head = queue.tail = node;
	}
	else
	{
		node->prev = queue.tail;
		queue.tail->next = node;
		queue.tail = node;
	}

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
Student* peekListNode(ListNode* headStack) {
	Student* value = NULL;
	if (headStack)
		value = headStack->info;
	return value;
}

Student* popListNode(ListNode*& headStack)
{
	Student* value = NULL;
	if (headStack != NULL)
	{
		value = headStack->info;
		ListNode*tmp = headStack;
		headStack = headStack->next;
		if (headStack)
			headStack->prev = NULL;
		free(tmp);
	}
	return value;
}

void pushListNode(ListNode*& headStack, ListNode* node)
{
	if (headStack != NULL)
	{
		node->next = headStack;
		headStack->prev = node;
	}

	headStack = node;

}