#include "stdio.h"
#include"stdlib.h"
#include"string.h"

struct Student
{
	int pKey;
	char* name;
};

struct Heap
{
	Student* *elements = NULL;
	int size = 0;
	int noEl = 0;
};

void InitHeap(Heap* heap, int dim)
{
	heap->noEl = 0;
	heap->size = dim;
	heap->elements = (Student**)malloc(sizeof(Student*)*dim);
	memset(heap->elements, NULL, sizeof(Student*)*dim);

} 

Student* createElement(int key, char*name) {

	Student* stud = (Student*)malloc(sizeof(Student));
	stud->pKey = key;
	stud->name = (char*)malloc(strlen(name) + 1);
	strcpy(stud->name, name);
	return stud;
}


void ReHeapUp(Heap& heap, int last) {
	//rehepificarea in sus pleaca de la copil la parinte, trb calulat parinte
	//cand fac in jos trb sa calc descendentii
	//ca sa aflam parinte form e modul de i-1/2;

	int parent;
	if (last > 0) {
		parent = (last - 1) / 2;
		if (heap.elements[parent]->pKey < heap.elements[last]->pKey)
		{
			Student * aux = heap.elements[parent];
			heap.elements[parent] = heap.elements[last];
			heap.elements[last] = aux;
			ReHeapUp(heap, parent);
		}
	}

}
void Enqueue(Heap& heap, Student* value)
{
	if (heap.noEl < heap.size)
	{
		heap.elements[heap.noEl] = value;
		ReHeapUp(heap, heap.noEl);
		heap.noEl++;
	}

}

void printHeap(Heap heap) {
	for (int i = 0; i < heap.noEl; i++) {
		printf("Heap index: %2d <--> (key: %2s, value: sd \n", i, heap.elements[i]->pKey, heap.elements[i]->name);
	}
}

void ReheapDown(Heap& heap, int first)
{
	int minChild;
	int leftChild = 2 * first + 1;
	int rightChild = 2 + first + 2;
	if (leftChild <= heap.noEl-1 )
	{
		if (leftChild == heap.noEl-1) 
			minChild = leftChild;
		else
		{
			if (heap.elements[leftChild]->pKey <= heap.elements[rightChild]->pKey)
				minChild = leftChild;
			else
				minChild = rightChild;
		}
		if (heap.elements[first]->pKey > heap.elements[minChild]->pKey)
		{
			Student*aux = heap.elements[first];
			heap.elements[first] = heap.elements[minChild];
			heap.elements[minChild] = aux; 
			ReheapDown(heap, minChild);
		}
		

	}

}

Student * dequeue(Heap& heap) {
	Student * value = NULL;
	if (heap.noEl > 0) {
		value = heap.elements[0];
		heap.noEl--;
		heap.elements[0] = heap.elements[heap.noEl];
		ReheapDown(heap, 0);

	}
	return value;
}

void main() {

	FILE *pFile = fopen("Data.txt", "r");
	Student* data = NULL;
	if (pFile)
	{
		Heap priorityQue;
		InitHeap(&priorityQue, 10);

		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int key = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &key);
			//create useful info
			
			Student* student = createElement(key, buffer);
			Enqueue(priorityQue, student);

			

		}
		fclose(pFile);
		//printHeap(priorityQue);
		Student * value = NULL;
		while ((value = dequeue(priorityQue)) != NULL)
		{
			printf("Value:%d == %s\n", value->pKey, value->name);
		}

	}
}