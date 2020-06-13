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

void ReHeapDown(Heap& heap, int parentIndex) {
	int maxChild;
	int leftChild = 2 * parentIndex + 1;
	int rightChild = 2 * parentIndex + 2;
	if (leftChild <= heap.noElements - 1) { // we pick the smaller child;
		if (leftChild == heap.noElements - 1)
			maxChild = leftChild; // if it has only one child
		else {
			if (heap.elements[leftChild]->pKey <= heap.elements[rightChild]->pKey) 
				maxChild = rightChild;
			else
				maxChild = leftChild;
		}
		if (heap.elements[parentIndex]->pKey < heap.elements[maxChild]->pKey) {
			Student* aux = heap.elements[parentIndex];
			heap.elements[parentIndex] = heap.elements[maxChild];
			heap.elements[maxChild] = aux;
			ReHeapDown(heap, maxChild);
		}
	}
}
Student* Dequeue(Heap& heap) {
	Student* value = NULL;
	if (heap.noElements > 0) {
		value = heap.elements[0];
		heap.noElements--;
		heap.elements[0] = heap.elements[heap.noElements];
		ReHeapDown(heap, 0);
	}
	return value;

}

void PrintHeap(Heap heap) {
	for (int i = 0; i < heap.noElements; i++) {
		printf("Student %s <==> %d || HeapIndex: %d \r\n", heap.elements[i]->name, heap.elements[i]->pKey, i);
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
	}fclose(file);
	PrintHeap(priorityQue);

	Student* value = NULL;
	while ((value = Dequeue(priorityQue)) != NULL)  //  O(n log n)
	{
		printf("Student: %3d <---> %s\n",
			value->pKey, value->name);
	}
}