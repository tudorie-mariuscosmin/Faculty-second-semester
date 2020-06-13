#include<stdio.h>
#include<malloc.h>
#include<string.h>


struct Student
{
	char* name;
	int age;
};
struct Node {
	Node* next;
	Student* info;
	Node* prev;
};

struct Queue
{
	Node* head = NULL;
	Node* tail = NULL;
};

Node* createNode(char* name, int age) {
	Node* node = (Node*)malloc(sizeof(Node));
	node->info = (Student*)malloc(sizeof(Student));
	node->info->name = (char*)malloc(strlen(name) + 1);
	strcpy(node->info->name, name);
	node->info->age = age;
	node->next = NULL;
	node->prev = NULL;
	return node;
}

void PushStack(Node*& stack, Node* node) {
	if (stack == NULL) {
		stack = node;
	}
	else {
		node->next = stack;
		stack->prev = node;
		stack = node;
	}
}

Student* PopStack(Node*& stack) {
	Student* val = NULL;
	if (stack) {
		val = stack->info;
		Node* tmp = stack;
		stack = stack->next;
		if (stack)
			stack->prev = NULL;
		free(tmp);
		
	}
	return val;
}

void PutQueue(Queue& queue, Node* node) {
	if (queue.head == NULL) {
		queue.head = queue.tail = node;
	}
	else{
		node->next = queue.tail;
		queue.tail->next = node;
		queue.tail = node;
	}
}

Student* GetQueue(Queue& queue) {
	Student *value = NULL;
	if (queue.head != NULL) {
		if (queue.head == queue.tail) {
			value = queue.head->info;
			free(queue.head);
			queue.head = queue.tail = NULL;
		}
		else {
			value = queue.head->info;
			Node* tmp = queue.head;
			queue.head = queue.head->next;
			queue.head->prev = NULL;
			free(tmp);
		}
	}
	return value;
}

//int main() {
//	FILE* pfile = fopen("Data.txt", "r");
//	Node* stack = NULL;
//	Queue queue;
//	if (pfile) {
//		while (!feof(pfile)){
//			char buffer[50];
//			int age;
//			fscanf(pfile, "%s", buffer);
//			fscanf(pfile, "%d", &age);
//			Node* node = createNode(buffer, age);
//			PushStack(stack, node);
//			PutQueue(queue, node);
//		}
//
//		/*Student* info =  PopStack(stack);
//		printf("%s : %d \r\n", info->name, info->age);
//		info = PopStack(stack);
//		printf("%s : %d \r\n", info->name, info->age);
//		while (stack) {
//			info = PopStack(stack);
//			printf("%s : %d \r\n", info->name, info->age);
//		}*/
//		printf("\n----------------Queue------------------------\n");
//
//		Student* info = GetQueue(queue);
//		printf("%s : %d \r\n", info->name, info->age);
//		
//		info = GetQueue(queue); printf("%s : %d \r\n", info->name, info->age);
//		info = GetQueue(queue); printf("%s : %d \r\n", info->name, info->age);
//		info = GetQueue(queue); printf("%s : %d \r\n", info->name, info->age);
//		info = GetQueue(queue); printf("%s : %d \r\n", info->name, info->age);
//		info = GetQueue(queue); printf("%s : %d \r\n", info->name, info->age);
//	}
//}