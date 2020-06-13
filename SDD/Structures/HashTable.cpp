#include<stdio.h>
#include<malloc.h>
#include<string.h>

struct Student {
	char* name;
	int age;
};

struct Node {
	Student* info;
	Node* next;
};
struct HashTable
{
	Node** buckets = NULL;
	int size = 0;
	int noElem = 0;
};

void initHashTable(HashTable& hashTable, int size) {
	hashTable.size = size;
	hashTable.noElem = 0;
	hashTable.buckets = (Node**)malloc(sizeof(Node*)*size);
	memset(hashTable.buckets, NULL, sizeof(Node*)*size);
}
int HashFunction(char* key, int hashTableSize) {
	int sum = 0;
	for (int i = 0; i < strlen(key); i++) {
		sum += key[i];
	}
	return sum % hashTableSize;
	//return key[0] % hashTableSize;
}

Node* createNode(Student* student) {
	Node* node = (Node*)malloc(sizeof(Node));
	node->info = student;
	node->next = NULL;
	return node;
}
Student* createStudent(char* name, int age) {
	Student* student = (Student*)malloc(sizeof(Student));
	student->name = (char*)malloc(strlen(name) + 1);
	strcpy(student->name, name);
	student->age = age;
	return student;
}
void AddNode(Node*&list, Node* node) {
	if (list == NULL)
		list = node;
	else
	{
		Node* tmp = list;
		while (tmp->next) {
			tmp = tmp->next;
		}
		tmp->next = node;
	}
}
void AddToHashTable(HashTable& hashTable, Student* student) {
	//1.get the index from a hashFunction
	int index = HashFunction(student->name, hashTable.size);
	//2. create a node for the information
	Node* node = createNode(student);
	//3.insert the new node in table at the corect index;
	AddNode(hashTable.buckets[index], node);
	hashTable.noElem++;
}


Student* getHashTable(HashTable hashTable, const char* key) {
	Student* val = NULL;
	char* newKey =  (char*)key;
	int index = HashFunction(newKey, hashTable.size);
	Node* list = hashTable.buckets[index];
	while (list && strcmp(list->info->name, key) != 0) {
		list = list->next;
	}
	if (strcmp(list->info->name, key) == 0) {
		val = list->info;
	}
	return val;
}

//int main() {
//	FILE* pfile = fopen("Data.txt", "r");
//	HashTable hashTable;
//	initHashTable(hashTable, 5);
//	if (pfile) {
//		while (!feof(pfile))
//		{
//			char buffer[50];
//			int age;
//			fscanf(pfile, "%s", buffer);
//			fscanf(pfile, "%d", &age);
//			Student* student = createStudent(buffer, age);
//			AddToHashTable(hashTable, student);
//		}
//	}fclose(pfile);
//
//	Student* info = getHashTable(hashTable, "TudorieMarius");
//	printf("%s : %d \r\n", info->name, info->age);
//	info = getHashTable(hashTable, "BerdeiIoana");
//	printf("%s : %d \r\n", info->name, info->age);
//
//}