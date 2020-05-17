#include "stdio.h"
#include "malloc.h"
#include "string.h"
struct Student
{
	char* name;
	int pKey;
};
struct NodeBST
{
	NodeBST* left;
	Student* info;
	NodeBST* right;
	int balanceFactor;
};
NodeBST* createNodeBST(Student* value)
{
	NodeBST* node = (NodeBST*)malloc(sizeof(NodeBST));
	node->info = value;
	node->left = node->right = NULL;
	return node;
	node->balanceFactor = 0;
}
Student* createElement(char* name, int key)
{
	Student* stud = NULL;
	stud = (Student*)malloc(sizeof(Student));
	stud->pKey = key;
	stud->name = (char*)malloc(strlen(name) + 1);
	strcpy(stud->name, name);
	return stud;
}
int max(int left, int right) {
	if (left > right)
		return right;
	else
		return left;
}
int getHigh(NodeBST* root) {
	if (root != NULL)
		return 1 + max(getHigh(root->left), getHigh(root->right));
	else
		return 0;
}

int getBalanceFactor(NodeBST* pivot) {
	int leftDepth = 0, rightDepth = 0;
	if (pivot->left)
		leftDepth = getHigh(pivot->left);
	if (pivot->right)
		rightDepth = getHigh(pivot->right);
	return rightDepth - leftDepth;
}
NodeBST* rightRotation(NodeBST* pivot) {
	NodeBST* desc = pivot->left;
	pivot->left = desc->right;
	desc->right = pivot;
	return desc;
}
NodeBST* leftRotation(NodeBST* pivot) {

}
NodeBST* rebelanceBst(NodeBST* pivot) {
	if (pivot->balanceFactor == -2) {
		NodeBST* desc = pivot->left;
		if (desc->balanceFactor == 1)
			pivot->left = leftRotation(desc);
		pivot = rightRotation(pivot);
	}
	else if (pivot->balanceFactor == 2) {
		NodeBST* desc = pivot->right;
		if (desc->balanceFactor == -1) {
			pivot->right 
		}
	}
}
void insertBST(NodeBST** ptrRoot, Student* value)
{
	if (*ptrRoot == NULL)
		*ptrRoot = createNodeBST(value);
	else
	{
		if ((*ptrRoot)->info->pKey > value->pKey)
			insertBST(&(*ptrRoot)->left, value);
		else if ((*ptrRoot)->info->pKey < value->pKey)
			insertBST(&(*ptrRoot)->right, value);
		else
			printf("Duplicate key detected, can't insert!");
	}
	(*ptrRoot) = rebelanceBst(*ptrRoot);
}
void printBST_Inorder(NodeBST* root)
{
	if (root != NULL)
	{
		printBST_Inorder(root->left);
		printf("Key: %3d <---> Value: %s\n", root->info->pKey, root->info->name);
		printBST_Inorder(root->right);
	}
}

void deleteBSTLogical(NodeBST*& root, NodeBST*& leftTree)
{
	if (leftTree->right != NULL)
		deleteBSTLogical(root, leftTree->right);
	else
	{
		Student* tmp = root->info;
		root->info = leftTree->info;
		free(tmp->name);
		free(tmp);
		NodeBST* aux = leftTree;
		leftTree = aux->left;
		free(aux);
	}
}
void deleteBST(NodeBST*& root, int key)
{
	if (root == NULL)
		printf("The key does not exist!\n");
	else
	{
		if (root->info->pKey > key)
			deleteBST(root->left, key);
		else if (root->info->pKey < key)
			deleteBST(root->right, key);
		else
		{
			// delete leaf
			if (root->left == NULL && root->right == NULL)
			{
				free(root->info->name);
				free(root->info);
				free(root);
				root = NULL;
			}
			else
				//delete node with 1 descendant
				if (root->left == NULL || root->right == NULL)
				{
					NodeBST* aux = NULL;
					if (root->left != NULL)
						aux = root->left;
					else
						aux = root->right;
					free(root->info->name);
					free(root->info);
					free(root);
					root = aux;
				}
			//delete with 2 descendants
				else
					deleteBSTLogical(root, root->left);
		}
	}
}
void main()
{
	FILE* pFile = fopen("Data.txt", "r");
	if (pFile)
	{
		NodeBST* root = NULL;
		while (!feof(pFile))
		{
			//1.read the name
			char buffer[100]; int key = 0;
			fscanf(pFile, "%s", buffer);
			//2.read the year
			fscanf(pFile, "%d", &key);
			Student* student = createElement(buffer, key);
			//3.insert element in the binary tree
			insertBST(&root, student);
		}
		fclose(pFile);
		printf("-------Inorder--------\n");
		printBST_Inorder(root);

		deleteBST(root, 25);
		printf("-------Inorder--------\n");
		printBST_Inorder(root);
	}
}