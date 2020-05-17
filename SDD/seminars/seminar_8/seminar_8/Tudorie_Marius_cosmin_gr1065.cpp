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
};

struct HashTable
{
	ListNode** buckets = NULL;
	int size = 0;
	int noElements = 0;
};

void initHashTable(HashTable& hashtable, int dim)
{
	hashtable.size = dim;
	hashtable.noElements = 0;
	hashtable.buckets = (ListNode**)malloc(sizeof(ListNode*)*dim);
	memset(hashtable.buckets, NULL, sizeof(ListNode*)*dim);// initializam vectorul cu NULL
}
int fHash( char* key, int dim)
{
	int indexLoc = key[0] % dim;
	return indexLoc;
}

ListNode* createElement(Student* info)
{
	ListNode* node = (ListNode*)malloc(sizeof(ListNode));
	node->info = info;
	node->next = NULL;
	return node;
}

void insertElement(ListNode*& list, ListNode* node)
{
	if (list != NULL)
		node->next = list;
	list = node;
}

void insertHT(HashTable* hashTable, Student* student)
{
	//1. get the index position for inserting the student
	int index = fHash(student->name, hashTable->size);

	//2. create a new element to be inserted
	ListNode* node = createElement(student);

	//3. insert the newly created element into HT
	ListNode* list = hashTable->buckets[index];
	insertElement(list, node);
	hashTable->noElements++;

}

Student* getHT(HashTable& hashTable,  char* key)
{
	/*int index = key[0] % hashTable.size;
	Student* student = hashTable.buckets[index]->info;
	return student;
*/
	Student *value = NULL;
	int index = fHash(key, hashTable.size);
	
	ListNode* proxyList = hashTable.buckets[index];

	while (proxyList && strcmp(proxyList->info->name, key) != 0) {
		proxyList = proxyList->next;
	}
	if (proxyList)
		value = proxyList->info;
	return value;




}

void main()
{
	FILE* pFile = fopen("Data.txt", "r");
	Student* data = NULL;
	if (pFile)
	{
		int dim = 0, index = 0;
	
		HashTable hashTable;

		initHashTable(hashTable, 7);

		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int year = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &year);

			Student* student = (Student*)malloc(sizeof(Student));
			student->year = year;
			student->name = (char*)malloc(strlen(buffer) + 1);
			strcpy(student->name, buffer);

			insertHT(&hashTable, student);
			
			
		}

		Student*info = getHT(hashTable, "Ionescu");
		if(info)
			printf("Student %s, year%d\n", info->name, info->year);
		fclose(pFile);

		
	}
}



