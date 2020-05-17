#include "stdio.h"
#include "malloc.h"
#include "string.h"
struct Student
{
	char* name;
	int prioKey;
};

struct Heap
{
	Student* *elements = NULL;
	int size = 0;
	int noEl = 0;
};

void initHeap(Heap& heap, int dim)
{
	heap.size = dim;
	heap.noEl = 0;
	heap.elements = (Student**)malloc(sizeof(Student*)*dim);
	memset(heap.elements, 0, sizeof(Student*)* dim);
}

Student* createElement(char* name, int key)
{
	Student* student = (Student*)malloc(sizeof(Student));
	student->prioKey = key;
	student->name = (char*)malloc(strlen(name) + 1);
	strcpy(student->name, name);
	return student;
}
void ReheapUp(Heap& heap, int child)
{
	int parent;
	//recursive stop condition
	if (child > 0)
	{
		parent = (child - 1) / 2;
		if (heap.elements[child]->prioKey > heap.elements[parent]->prioKey)
		{
			//switch
			Student* aux = heap.elements[parent];
			heap.elements[parent] = heap.elements[child];
			heap.elements[child] = aux;
			ReheapUp(heap, parent);
		}
	}
}
void EnqueuePQ(Heap& heap, Student* value)
{
	if (heap.noEl < heap.size)
	{
		heap.elements[heap.noEl] = value;
		ReheapUp(heap, heap.noEl);
		heap.noEl++;
	}
}

void printPQ(Heap heap)
{
	for (int i = 0; i < heap.noEl; i++)
	{
		printf("Heap index: %3d <---> (Key: %3d, Value: %s)\n",
			i, heap.elements[i]->prioKey, heap.elements[i]->name);
	}
}
void ReheapDown(Heap*& heap, int parent)
{
	int maxChild;
	int leftChild = 2 * parent + 1;
	int rightChild = 2 * parent + 2;
	//recursive stop condition
	if (leftChild <= heap->noEl - 1)
	{
		if (leftChild == heap->noEl - 1)
			maxChild = leftChild;
		else
		{
			if (heap->elements[leftChild]->prioKey < heap->elements[rightChild]->prioKey)
				maxChild = rightChild;
			else
				maxChild = leftChild;
		}
		if (heap->elements[parent]->prioKey < heap->elements[maxChild]->prioKey)
		{
			Student* aux = heap->elements[parent];
			heap->elements[parent] = heap->elements[maxChild];
			heap->elements[maxChild] = aux;
			ReheapDown(heap, maxChild);
		}
	}
}
Student* DequeuePQ(Heap* heap)
{
	Student* result = NULL;
	if (heap->noEl > 0)
	{
		result = heap->elements[0];
		heap->noEl--;
		heap->elements[0] = heap->elements[heap->noEl];
		ReheapDown(heap, 0);
	}
	return result;
}
void main()
{
	FILE* pFile = fopen("Data.txt", "r");
	Student* data = NULL;
	if (pFile)
	{
		Heap priorityQueue;
		initHeap(priorityQueue, 100);

		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int key = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &key);
			//3.create useful info
			Student* stud = createElement(buffer, key);
			//4.insert Student into heap structure
			EnqueuePQ(priorityQueue, stud);
		}
		fclose(pFile);
		printPQ(priorityQueue);

		Student* value = NULL;
		while ((value = DequeuePQ(&priorityQueue)) != NULL)  //  O(n log n)
		{
			printf("Student: %3d <---> %s\n",
				value->prioKey, value->name);
		}
	}
}		