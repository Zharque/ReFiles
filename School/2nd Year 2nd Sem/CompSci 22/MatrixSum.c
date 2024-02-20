/*
Make a program that accepts n, and creates a multiplication table that is n by n.
Then, calculate for T(n) on a paper. 
printf() does not have T(n).

Coded by: Rynz A. Daval
Teacher: Ma'am Chuchi Montenegro
Date: 2023.02.27
*/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

void FA(int n, int A[n][n]);
int FB(int n, int A[n][n]);

int main(){
	int n, sum;
	printf("\n\tINPUT A NUMBER: ");
	scanf("%d", &n);
	while(getchar()!='\n');
	
	int A[n][n];
	FA(n, A);
	sum = FB(n, A);
	printf("\n\tThe sum is %d.", sum);
}

void FA(int n, int A[n][n]){
	int column, row;
	
	for(column=0; column<n; column++){
		printf("\n");
		for(row=0; row<n; row++){
			if(column!=0 && row!=0){
				A[column][row] = A[0][row] * A[column][0];	
			}
			else{
				A[column][row] = column + row + 1; //already assumed that column or row is 0
			}
			printf("%d\t", A[column][row]); //display the cell
		}
	}
	return;
}

int FB(int n, int A[n][n]){
	int column, row, sum = 0;
	for(column=0; column<n; column++){
		for(row=0; row<n; row++){
			sum = sum + A[column][row];
		}
	}
	return sum;
}