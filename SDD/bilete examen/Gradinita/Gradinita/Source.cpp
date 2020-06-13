#include<stdio.h>
#include<malloc.h>
#include<string.h>


struct Gradinita
{
	char* name;
	int capacitate;
	char* director;
	int classsrooms;
	int number;
};

struct Node
{
	Gradinita* info;
	Node* next;

};

struct ListNode {
	Gradinita* info;
	ListNode* next;
	ListNode* prev;
};
struct HashTable
{
	Node** buckets;
	int size;
	int noElements;
};

void initHashTable(HashTable& table, int size) {
	table.buckets = (Node**)malloc(sizeof(Node*)*size);
	memset(table.buckets, NULL, sizeof(Node*)*size);
	table.size = size;
	table.noElements = 0;
}

Node* createElement(Gradinita* gradinita) {
	Node* node =(Node*) malloc(sizeof(Node));
	
	node->info = gradinita;
	node->next = NULL;
	return node;
}

Gradinita* createGradinita(char* nume, int capacitate, char* director, int classroms, int numbe) {
	Gradinita* gradinita = (Gradinita*)malloc(sizeof(Gradinita));
	gradinita->name = (char*)malloc(strlen(nume) + 1);
	gradinita->director = (char*)malloc(strlen(director) + 1);
	strcpy(gradinita->name, nume);
	strcpy(gradinita->director, director);
	gradinita->capacitate = capacitate;
	gradinita->classsrooms = classroms;
	gradinita->number = numbe;
	return gradinita;
}





int hashFunction(char* name, int size) {
	int sum = 0;
	for (int i = 0; i < strlen(name); i++) {
		sum += name[i];
	}
	return sum % size;
}

void insertNode(Node*& list, Node* node) {
	if (list == NULL) {
		list = node;
	}
	else {
		Node* tmp = list;
		while (tmp->next) {
			tmp = tmp->next;
		}
		tmp->next = node;
	}
}
void insertElement(HashTable& table,Gradinita* gradinita) {
	Node* node = createElement(gradinita);
	int index = hashFunction(gradinita->name, table.size);

	insertNode(table.buckets[index], node);
	table.noElements++;

}
Gradinita* getElement(HashTable& table, const char* name) {
	Gradinita* value = NULL;
	char* newName = (char*)name;
	int index = hashFunction(newName, table.size);

	Node* list = table.buckets[index];
	Node* prevNode = NULL;
	while (list && strcmp(list->info->name, name) != 0) {
		prevNode = list;
		list = list->next;
	}
	if (strcmp(list->info->name, name) == 0) {
		value = list->info;
		if (prevNode == NULL) {
			//Node* tmp = list;
			//list = list->next;
			table.buckets[index] = list->next;
			free(list);
			table.noElements--;

		}
		else {
			prevNode->next = list->next;
			free(list);
			table.noElements--;
		}
	}
	return value;
}

	

void replaceKey(HashTable& table, const char* name,const char* newName) {
	Gradinita* gradinita = getElement(table, name);
	free(gradinita->name);
	gradinita->name = (char*)malloc(strlen(newName) + 1);
	strcpy(gradinita->name, newName);
	insertElement(table, gradinita);
}

ListNode* createListNode(char* nume, int capacitate, char* director, int classroms, int number) {
	ListNode* node = (ListNode*)malloc(sizeof(ListNode));
	node->info = (Gradinita*)malloc(sizeof(Gradinita));
	node->info->name = (char*)malloc(strlen(nume) + 1);
	node->info->director = (char*)malloc(strlen(director) + 1);
	strcpy(node->info->name, nume);
	strcpy(node->info->director, director);
	node->info->capacitate = capacitate;
	node->info->classsrooms = classroms;
	node->info->number = number;
	node->next = NULL;
	node->prev = NULL;
	return node;
}

void insertDoubleList(ListNode*& list, ListNode* node) {
	if (list == NULL) {
		list = node;
	}
	else {
		ListNode* tmp = list;
		while (tmp->next) {
			tmp = tmp->next;
		}
		node->prev = tmp;
		tmp->next = node;
	}
}


ListNode* copyToList(HashTable table, int key) {
	ListNode* doubleList = NULL;
	for (int i = 0; i < table.size; i++) {
		Node* hashList = table.buckets[i];
		while (hashList) {
			if (hashList->info->number > key) {
				ListNode* node = createListNode(hashList->info->name, hashList->info->capacitate, hashList->info->director, hashList->info->classsrooms, hashList->info->number);
				insertDoubleList(doubleList, node);
			}
			hashList = hashList->next;
		}
	}
	return doubleList;
}

void printList(ListNode* head) {
	if (head) {
		while (head) {
			printf("name: %s, director:%d, number: %d\n", head->info->name, head->info->director, head->info->number);
			head = head->next;
		}
	}
}

ListNode* breakList(ListNode* head, const char* name) {
	ListNode* newNode = NULL;
	while (head&& strcmp(head->info->name, name) != 0) {
		head = head->next;
	}
	if (strcmp(head->info->name, name) == 0) {
		newNode = head;
		head->prev->next = NULL;
		newNode->prev = NULL;
		
	}
	return newNode;
}

void freeListNode(ListNode* node) {
	free(node->info->name);
	free(node->info->director);
	free(node->info);
	free(node);
}

void deleteDoubleList(ListNode*& list) {
	while (list) {

		if (list != NULL) {
			if (list->next == NULL) {
				freeListNode(list);
				list = NULL;
			}
			else {
				ListNode* tmp = list;
				list = list->next;
				list->prev = NULL;
				free(tmp);
			}
		}
	}
	
}

void freeSimpleNode(Node* node) {
	free(node->info->name);
	free(node->info->director);
	free(node->info);
	free(node);
}
void deleteSimpleList(Node*& list) {
	while (list) {
		if (list->next == NULL) {
			freeSimpleNode(list);
			list = NULL;
		}
		else
		{
			Node* tmp = list;
			list = list->next;
			freeSimpleNode(tmp);
		}
	}
}

void deleteHashTable(HashTable& table) {
	for (int i = 0; i < table.size; i++) {
		deleteSimpleList(table.buckets[i]);
	}
	table.noElements = 0;
	free(table.buckets);
	table.buckets = NULL;
	table.size = 0;
}



void main() {
	FILE* file = fopen("Data.txt", "r");
	HashTable hashTable;
	initHashTable(hashTable, 6);
	if (file) {
		while (!feof(file))
		{
			char nume[50];
			int capacitate;
			char director[50];
			int classroms;
			int number;

			fscanf(file, "%s", nume);
			fscanf(file, "%d", &capacitate);
			fscanf(file, "%s", director);
			fscanf(file, "%d", &classroms);
			fscanf(file, "%d", &number);
			Gradinita* gradinita = createGradinita(nume, capacitate, director, classroms, number);
			insertElement(hashTable, gradinita);


		}
	}fclose(file);
	printf("%d\n", hashTable.noElements);
	replaceKey(hashTable, "Sofija", "TudorieMarius");
	printf("%d\n", hashTable.noElements);


	ListNode* copy = copyToList(hashTable, 10);
	printf("--------initial list------------\n");
	printList(copy);

	ListNode* breakedList = breakList(copy, "Funske");
	printf("--------initial list breaked------------\n");
	printList(copy);
	printf("--------braked list------------\n");
	printList(breakedList);

	deleteDoubleList(breakedList);
	printList(breakedList);

	deleteHashTable(hashTable);

}