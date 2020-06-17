#include <stdio.h>
#include<malloc.h>
#include<string.h>

struct Library {
	char* name;
	int noLines;
	int noClasses;
};

struct BstNode
{
	Library* info;
	BstNode* left;
	BstNode* right;
};



Library* createLibrary(char* name, int lines, int classes) {
	Library* library = (Library*)malloc(sizeof(Library));
	library->name = (char*)malloc(strlen(name) + 1);
	strcpy(library->name, name);
	library->noLines = lines;
	library->noClasses = classes;
	return library;
}
BstNode* createNode(Library* lib) {
	BstNode* node = (BstNode*)malloc(sizeof(BstNode));
	node->info = lib;
	node->left = NULL;
	node->right = NULL;
	return node;
}
int getNameSum(char* name) {
	int sum = 0;
	for (int i = 0; i < strlen(name); i++) {
		sum += name[i];
	}
	return sum;
}

void insertBst(BstNode*& root, Library* library) {
	BstNode* node = createNode(library);
	if (root == NULL) {
		root = node;
	}
	else {
		if (getNameSum(root->info->name) > getNameSum(library->name))
			insertBst(root->left, library);
		else if (getNameSum(root->info->name) < getNameSum(library->name))
			insertBst(root->right, library);
		else
			printf("Can't insert duplicate key \n");
	}
}


void copyBst( BstNode* source,BstNode*& destination, int key) {
	if (source) {
		if (source->info->noLines > key)
			insertBst(destination, source->info);
		copyBst(source->right, destination, key);
		copyBst(source->left, destination, key);	
	}
}


void getLeaves(BstNode* root, Library** array, int& noEL) {
	if (root) {
		getLeaves(root->right, array, noEL);
		
		if (root && root->left == NULL && root->right == NULL)
			array[noEL++] = root->info;
		getLeaves(root->left, array, noEL);
	}
}


void freeBst(BstNode*& root) {
	if (root) {
		freeBst(root->left);
		freeBst(root->left);
		if (root) {
			free(root->info->name);
			free(root->info);
			free(root);
			root = NULL;
		}
	}
}



void printIndorder(BstNode* root){
	if (root != NULL) {
		printIndorder(root->left);
		printf("Library named %s has %d classes and %d lines of code <=> keyNo:%d \n", root->info->name, root->info->noClasses, root->info->noLines, getNameSum(root->info->name));
		printIndorder(root->right);
	}
}
int main() {
	FILE* file = fopen("Data.txt", "r");
	BstNode* root = NULL;
	BstNode* copy = NULL;
	if (file) {
		while (!feof(file)) {
			char buffer[50];
			int lines;
			int classes;
			fscanf(file, "%s", buffer);
			fscanf(file, "%d", &lines);
			fscanf(file, "%d", &classes);
			Library* library = createLibrary(buffer, lines, classes);
			insertBst(root, library);

		}
	}
	printf("------root----- \n");
	printIndorder(root);
	//2
	copyBst(root, copy, 500);
	printf("------copy----- \n");
	printIndorder(copy);
	// 4
	Library* array[10];
	int noEl = 0;
	getLeaves(root, array, noEl);
	for (int i = 0; i < noEl; i++) {
		printf("\n leaf: %s key:%d\n", array[i]->name, getNameSum(array[i]->name));
	}
	
	freeBst(root);
	
}