#include<stdio.h>
#include<malloc.h>
#include<string.h>

struct Angajat {
	char* nume;
	char* departament;
	int salariu;
	int echipa;
	int experienta;
};

struct Node
{
	Angajat* info;
	Node* next;
	Node* prev;
};



Node* createNode(char* nume, char*departament, int salariu, int echipa, int experienta) {
	Node* node = (Node*)malloc(sizeof(Node));
	node->info = (Angajat*)malloc(sizeof(Angajat));
	node->info->nume = (char*)malloc(strlen(nume) + 1);
	node->info->departament = (char*)malloc(strlen(departament) + 1);
	strcpy(node->info->nume, nume);
	strcpy(node->info->departament, departament);
	node->info->salariu = salariu;
	node->info->echipa = echipa;
	node->info->experienta = experienta;
	node->next = NULL;
	node->prev = NULL;
	return node;
}

void insertNode(Node*& head, Node* node) {
	if (head == NULL) {
		head = node;
	}
	else
	{
		Node* tmp = head;
		while (tmp->next)
		{
			tmp = tmp->next;
		}
		tmp->next = node;
		node->prev = tmp;
	}
}

void printList(Node* head) {
	while (head) {
		printf("Employee %s who works in department %s, team %d has a salary of %d and an experience of %d year/s\n", head->info->nume, head->info->departament, head->info->echipa, head->info->salariu, head->info->experienta);
		head = head->next;
	}
}
//2
void freeNode(Node* node) {
	free(node->info->nume);
	free(node->info->departament);
	free(node->info);
	free(node);
}
void deleteNodesByKey(Node*& head,const char* key) {
	if (head) {
		Node* tmp = head;
		while (tmp) {
			if (strcmp(tmp->info->departament, key) == 0) {
				if (tmp->next == NULL && tmp->prev == NULL) {
					Node* aux = tmp;
					tmp = tmp->next;
					freeNode(aux);
					if (head == aux)
						head = tmp;
				
				}
				else {
					tmp->next->prev = tmp->prev;
					if (tmp->prev != NULL)
						tmp->prev->next = tmp->next;
					Node* aux = tmp;
					tmp = tmp->next;
					freeNode(aux);
					if (head == aux)
						head = tmp;

				}
			}
			else {
				tmp = tmp->next;
			}
			
		}
	}
}

// 3
struct BSTNode {
	Angajat* info;
	BSTNode* left;
	BSTNode* right;
};

BSTNode* createBstNode(char* nume, char*departament, int salariu, int echipa, int experienta) {
	BSTNode* node = (BSTNode*)malloc(sizeof(BSTNode));
	node->info = (Angajat*)malloc(sizeof(Angajat));
	node->info->nume = (char*)malloc(strlen(nume) + 1);
	node->info->departament = (char*)malloc(strlen(departament) + 1);
	strcpy(node->info->nume, nume);
	strcpy(node->info->departament, departament);
	node->info->salariu = salariu;
	node->info->echipa = echipa;
	node->info->experienta = experienta;
	node->left = NULL;
	node->right = NULL;
	return node;
}

void insertBst(BSTNode*& root, BSTNode* node){
	if (root == NULL) {
		root = node;
	}
	else {
		if (root->info->salariu < node->info->salariu)
			insertBst(root->left, node);
		else if (root->info->salariu > node->info->salariu)
			insertBst(root->right, node);
		else
			"Duplicate key can't insert";
	}
}

BSTNode* copyFromListToBst(Node* head, int key) {
	BSTNode* root = NULL;
	if (head) {
		while (head) {
			if (head->info->salariu > key) {
				BSTNode* node = createBstNode(head->info->nume, head->info->departament, head->info->salariu, head->info->echipa, head->info->experienta);
				insertBst(root, node);
			}
			head = head->next;
		}
	}
	return root;
}
void printBstInorder(BSTNode* root) {
	if (root!=NULL) {
		printBstInorder(root->left);
		printf("Bst emp name %s from the dep %s has the salary of %d \n", root->info->nume, root->info->departament, root->info->salariu);
		printBstInorder(root->right);
	}
}

//4

void copyfromBstToArray(BSTNode* root, int key,BSTNode** array, int& noEl ) {
	if (root) {
		if (root->info->salariu < key) {
			array[noEl++] = root;
			copyfromBstToArray(root->right, key, array, noEl);
		}
		else if (root->info->salariu > key) {
			array[noEl++] = root;
			copyfromBstToArray(root->left, key, array, noEl);
		}
		else {
			array[noEl++] = root;
		}
	}
}

// 5


void deleteList(Node*& list) {
	while (list)
	{
		Node* tmp = list;
		list = list->next;
		free(tmp->info->nume);
		free(tmp->info->departament);
		free(tmp->info);
		free(tmp);
	}
}

void freeBst(BSTNode*& root) {
	if (root) {
		freeBst(root->left);
		freeBst(root->left);
		if (root) {
			free(root->info->nume);
			free(root->info->departament);
			free(root->info);
			free(root);
			root = NULL;
		}
	}
}
void main() {
	FILE* file = fopen("Data.txt", "r");
	Node* head = NULL;
	if (file) {
		while (!feof(file))
		{
			char nume[50]; fscanf(file, "%s", nume);
			char departament[50]; fscanf(file, "%s", departament);
			int salariu; fscanf(file, "%d", &salariu);
			int echipa; fscanf(file, "%d", &echipa);
			int experienta; fscanf(file, "%d", &experienta);
			Node* node = createNode(nume, departament, salariu, echipa, experienta);
			insertNode(head, node);

		}
	}fclose(file);

	printList(head);
	//deleteNodesByKey(head, "IT");
	printf("----------after deletion-----------	\n");
	printList(head);
	//3
	printf("\n");
	BSTNode* root = copyFromListToBst(head, 100);
	printBstInorder(root);
	//4 nu prea merge asta dar oh well!
	int noEl = 0;
	BSTNode* array[10];
	copyfromBstToArray(root, 2478, array, noEl);
	for (int i = 0; i < noEl; i++) {
		printf("arr emp %s => dep: %s, salary: %d \n", array[i]->info->nume, array[i]->info->departament, array[i]->info->salariu);
	}

	// 5
	deleteList(head);
	freeBst(root);


	
}
