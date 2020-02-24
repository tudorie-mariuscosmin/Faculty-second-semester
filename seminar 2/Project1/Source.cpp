#include "stdio.h"
#include "malloc.h"

void main()
{
	int *** matrix = NULL;
	FILE* pFile = fopen("data.txt", "r");
	if (pFile)
	{
		int noCols = 0, noRows = 0;
		fscanf(pFile, "%d %d", &noRows, &noCols);

		matrix = (int***)malloc(sizeof(int**)*noRows);
		for (register int rowIndex = 0; rowIndex < noRows; rowIndex++)
		{
			matrix[rowIndex] = (int**)malloc(sizeof(int*)*noCols);
		}

		int index = 0;
		while (!feof(pFile))
		{
			int value = 0;
			fscanf(pFile, "%d", &value);
			
			int i = index / noCols;
			int j = index % noRows;
			index++;

			matrix[i][j] = (int*)malloc(sizeof(int));

			*matrix[i][j] = value;


		}

	}

}