#include<stdio.h>
#include<malloc.h>
#include<string.h>

struct Student
{
	char* name;
	int pKey;
};

struct Heap
{
	Student** elements = NULL;
	int size = 0;
	int noElements = 0;
};

void initHeap(Heap& heap, int size) {
	heap.size = size;
	heap.noElements = 0;
	heap.elements = (Student**)malloc(sizeof(Student*)*size);
	memset(heap.elements, NULL, sizeof(Student*)*size);
}

Student* createStudent(char* name, int key) {
	Student* student = (Student*)malloc(sizeof(Student));
	student->name = (char*)malloc(strlen(name) + 1);
	strcpy(student->name, name);
	student->pKey = key;
	return student;
}
//from a big value to smaller values
void ReHeapUp(Heap& heap, int lastIndex) {
	//upreheaping it is maked from the parents down and the parent need to pe computed |i-1/2|
	if (lastIndex > 0) {
		int parentIndex = (lastIndex - 1) / 2;
		if (heap.elements[parentIndex]->pKey < heap.elements[lastIndex]->pKey) {
			Student* aux = heap.elements[parentIndex];
			heap.elements[parentIndex] = heap.elements[lastIndex];
			heap.elements[lastIndex] = aux;
			ReHeapUp(heap, parentIndex);
		}
	}
}

void Enqueue(Heap& heap, Student* student) {
	if (heap.noElements < heap.size) {
		heap.elements[heap.noElements] = student;
		ReHeapUp(heap, heap.noElements);
		heap.noElements++;
	}
}


int main() {
	FILE* file = fopen("Data.txt", "r");
	Heap priorityQue;
	initHeap(priorityQue, 10);
	if (file) {
		while (!feof(file))
		{
			char buffer[50];
			int key;
			fscanf(file, "%s", buffer);
			fscanf(file, "%d", &key);
			Student* student = createStudent(buffer, key);
			Enqueue(priorityQue, student);
		}
	}
}