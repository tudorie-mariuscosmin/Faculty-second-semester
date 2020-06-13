#include<stdio.h>
#include<malloc.h>
#include<string.h>
// binary search tree
struct Student
{
	char* name;
	int pKey;
};

struct BstNode {
	Student* info;
	BstNode* left;
	BstNode* right;
};

Student* createStud(char* name, int key) {
	Student* stud = (Student*)malloc(sizeof(Student));
	stud->name = (char*)malloc(strlen(name) + 1);
	strcpy(stud->name, name);
	stud->pKey = key;
	return stud;
}

BstNode* createNode(Student* stud) {
	BstNode* node = (BstNode*)malloc(sizeof(BstNode));
	node->info = stud;
	node->right = NULL;
	node->left = NULL;
	return node;
}

void insetInBST(BstNode*& root, Student* stud) {
	if (root == NULL) {
		root = createNode(stud);
	}
	else
	{
		if (root->info->pKey > stud->pKey)
			insetInBST(root->left, stud);
		else if (root->info->pKey < stud->pKey)
			insetInBST(root->right, stud);
		else
			printf("Duplicate key detected, cant be inserted!\n");
	}
}

void printBstInorder(BstNode* root) {
	if (root != NULL) {
		printBstInorder(root->left);
		printf("Student %s : %d \n", root->info->name, root->info->pKey);
		printBstInorder(root->right);
	}
}
void printBstPreOrder(BstNode* root) {
	if (root != NULL) {
		printf("Student %s : %d \n", root->info->name, root->info->pKey);
		printBstPreOrder(root->left);
		printBstPreOrder(root->right);
	}
}
void printBstPostOrder(BstNode* root) {
	if (root != NULL) {
		printBstInorder(root->left);
		printBstInorder(root->right);
		printf("Student %s : %d \n", root->info->name, root->info->pKey);
	}
}

void deleteBstLogical(BstNode*& root, BstNode*& left) {
	if (left->right != NULL) {
		deleteBstLogical(root, left->right);
	}
	else {
		Student* val = root->info;
		root->info = left->info;
		free(val->name);
		free(val);
		BstNode* aux = left;
		left = aux->left;
		free(aux);
	}
}

void deleteBst(BstNode*& root, int key) {
	if (root) {
		if (root->info->pKey < key)
			deleteBst(root->right, key);
		else if (root->info->pKey > key)
			deleteBst(root->left, key);
		else {
			if (root->left == NULL && root->right == NULL) {
				free(root->info->name);
				free(root->info);
				free(root);
				root = NULL;
			}
			else
			{
				if (root->left == NULL || root->right == NULL) {
					BstNode* tmp = NULL;
					if (root->left == NULL)
						tmp = root->left;
					else
						tmp = root->right;
					free(root->info->name);
					free(root->info);
					free(root);
					root = tmp;
				}
				else {
					deleteBstLogical(root, root->left);
				}
			}
		}

	}
	else
		printf("The key doesn't exist!");
	

	
}

void main() {
	FILE * file = fopen("Data.txt", "r");
	BstNode* root = NULL;
	if (file) {
		while (!feof(file))
		{
			char buffer[50];
			int key;
			fscanf(file, "%s", buffer);
			fscanf(file, "%d", &key);
			Student* stud = createStud(buffer, key);
			insetInBST(root, stud);

		}
		printf("----Inorder Print--------\n");
		printBstInorder(root);

		printf("----Pre-Order Print--------\n");
		printBstPreOrder(root);

		printf("----Post-Order Print--------\n");
		printBstPostOrder(root);


		deleteBst(root, 29);
		printf("----Inorder Print--------\n");
		printBstInorder(root);


	}

}