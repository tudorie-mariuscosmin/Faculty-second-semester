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
	Student* info;
	ListNode* next;
	ListNode* prev;
};

ListNode* createListNode(char*, int);
void insertListNodeFrontPtr(ListNode**, ListNode*);
void insertListNodeFrontRef(ListNode*&, ListNode*);
ListNode* insertListNodeBack(ListNode*, ListNode*);
void deleteListNode(ListNode** ptrHead);
void printCircularList(ListNode *head);
Student* deleteNodeByStudentName(ListNode*& head, const char* key);

void main()
{
	FILE* pFile = fopen("Data.txt", "r");
	Student* data = NULL;
	if (pFile)
	{
		ListNode* head = NULL;
		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int year = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &year);
			ListNode* node = createListNode(buffer, year);
			//insertListNodeFrontPtr(&head, node);
			//insertListNodeFrontRef(head, node);
			head = insertListNodeBack(head, node);
		}
		fclose(pFile);

		printCircularList(head);
		
		 Student* info = deleteNodeByStudentName(head, "Georgescu");
		 printf("Student %s was deleted!", info->name);
		while (head)
		{
			deleteListNode(&head);
		}
		
		printCircularList(head);

	}
}

Student* deleteNodeByStudentName(ListNode* &head, const char* key) {
	ListNode *tmp = head;
	Student* value;
		do
		{
			tmp = tmp->next;

		} while (tmp != head && strcmp(tmp->info->name, key) != 0);
		if (strcmp(tmp->info->name, key) == 0)
		{
			value = tmp->info;
			tmp->prev->next = tmp->next;
			tmp->next->prev = tmp->prev;
			free(tmp);
		}
		
		
		return value;


}

void printCircularList( ListNode *head) {
	ListNode* tmp = head;
	if (tmp) {

		do {
			printf("Node address: %X, Student address: %X, student name: %s \n", tmp, tmp->info, tmp->info->name);
			tmp = tmp->next;
		} while (tmp != head);
	}
}


void freeListNode(ListNode*node){
	free(node->info->name);
	free(node->info);
	free(node);
}

void deleteListNode(ListNode** ptrHead)
{
	if (*ptrHead != NULL) {
		if ((*ptrHead)->next == (*ptrHead) && (*ptrHead)->prev == (*ptrHead))
		{
			ListNode* temp = *ptrHead;
			freeListNode(temp);
			*ptrHead = NULL;
		}
		else
		{
			ListNode *tmp = *ptrHead;
			tmp->next->prev = tmp->prev;
			tmp->prev->next = tmp->next;
			*ptrHead = tmp->next;
			freeListNode(tmp);

		}
	}
	
}

ListNode* insertListNodeBack(ListNode* head, ListNode* node) //tema
{
	if (head == NULL) {
		head = node;
		head->next = node;
		head->prev = node;
	}
	else
	{
		node->next = head;
		node->prev = head->prev;

		head->prev->next = node;
		head->prev = node;


		/*ListNode* tmp = head;       this is't needed any more;
		while (tmp->next != NULL)
			tmp = tmp->next;
		tmp->next = node;*/
	}
	return head;
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
	//insertion at the begining of a circular double linked list
	if (*head == NULL) {
		node->next = node->prev = node;
	}
	else {
		//1.CONNECTING NODE TO STRUCTURE
		node->next = *head;
		node->prev = (*head)->prev;
		//2.CONNECTING STRUCTURE TO NODE
		(*head)->prev->next = node;
		(*head)->prev = node;
	}
	*head = node;
}

void insertListNodeFrontRef(ListNode*& head, ListNode* node)//tema
{
	//insertion at the begining of a circular double linked list using pointer reference
	if (head == NULL) {
		node->next = node->prev = node;
	}
	else {
		node->next = head;
		node->prev = head->prev;

		head->prev->next = node;
		head->prev = node;
	}
	head = node;

}