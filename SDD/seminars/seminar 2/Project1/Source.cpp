#include "stdio.h"
#include "malloc.h"

void main()
{
	int *** matrix = NULL;
	FILE* pFile = fopen("data.txt", "r");
	int noCols = 0, noRows = 0;
	if (pFile)
	{
		
		fscanf(pFile, "%d %d", &noRows, &noCols);

		matrix = (int***)malloc(sizeof(int**)*noRows);
		for ( int rowIndex = 0; rowIndex < noRows; rowIndex++)
		{
			matrix[rowIndex] = (int**)malloc(sizeof(int*)*noCols);
		}

		int index = 0;
		while (!feof(pFile))
		{
			int value = 0;
			fscanf(pFile, "%d", &value);
			int i = index / noCols;
			int j = index % noCols;
			index++;


			matrix[i][j] = (int*)malloc(sizeof(int));

			*matrix[i][j] = value;
		}

		

	}
	fclose(pFile);

	for (int i = 0; i < noRows; i++) {
		for (int j = 0; j < noCols; j++)
		{
			printf("%d, ", *matrix[i][j]);
		}
		printf("\n");
	}

}