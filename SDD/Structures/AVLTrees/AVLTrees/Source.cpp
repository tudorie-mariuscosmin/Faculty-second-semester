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
	int balaceFactor;
};
NodeBST* createNodeBST(Student* value)
{
	NodeBST* node = (NodeBST*)malloc(sizeof(NodeBST));
	node->info = value;
	node->left = node->right = NULL;
	return node;
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
int max(int a, int b) {
	return a > b ? a : b;
}
int getHeight(NodeBST* root) {
	if (root == NULL)
		return 0;
	else return 1 + max(getHeight(root->left), getHeight(root->right));
}
int getBalanceFactor(NodeBST* root) {
	if (root == NULL)
		return 0;
	else
	{
		return getHeight(root->right) - getHeight(root->left);
	}
}

NodeBST* rotRight(NodeBST* pivot) {
	NodeBST* desc = pivot->left;
	pivot->left = desc->right;
	desc->right = pivot;
	return desc;
}

NodeBST* rotLeft(NodeBST* pivot) {
	NodeBST* desc = pivot->right;
	pivot->right = desc->left;
	desc->left = pivot;
	return desc;
}

NodeBST* rebalaceBst(NodeBST* pivot) {
	pivot->balaceFactor = getBalanceFactor(pivot);
	if (pivot->balaceFactor == 2) {
		NodeBST* desc = pivot->right;
		if (desc->balaceFactor == -1) 
			pivot->right = rotRight(desc);
		pivot = rotLeft(pivot);
		
	}
	else if (pivot->balaceFactor == -2) {
		NodeBST* desc = pivot->left;
		if (desc->balaceFactor == 1)
			pivot->left = rotLeft(desc);
		pivot = rotRight(pivot);

	}
	return pivot;
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

	*ptrRoot = rebalaceBst(*ptrRoot);
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
	FILE* pFile = fopen("Text.txt", "r");
	if (pFile)
	{
		NodeBST* root = NULL;
		while (!feof(pFile))
		{
			char buffer[100]; int key = 0;
			fscanf(pFile, "%d", &key);
			fscanf(pFile, "%s", buffer);
			
			Student* student = createElement(buffer, key);

			insertBST(&root, student);
		}
		fclose(pFile);
		printf("-------Inorder--------\n");
		printBST_Inorder(root);

		/*deleteBST(root, 25);
		printf("-------Inorder--------\n");
		printBST_Inorder(root);*/
	}
}