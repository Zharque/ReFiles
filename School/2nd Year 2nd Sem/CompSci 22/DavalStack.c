/*
Make a program that manually adds large numbers using stacks.

Coded by: Rynz A. Daval
Teacher: Ma'am Chuchi Montenegro
Date: 2023.02.06
*/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define SIZE 10

void createStack(int *);
void getOperandStack (int *, int, int *);
void displayStack(int *, int);
void addStacks(int *, int, int *, int, int *, int*);

int main(){
	int operand_1 = 0, operand_2 = 0, sum = 0, carry = 0;
	int stack_1[SIZE], stack_2[SIZE], stack_3[SIZE];
	int tos_1 = -1, tos_2 = -1, tos_3 = -1; //counter for how many nodes in the stack, top of stack
	createStack(stack_1);
	createStack(stack_2);
	createStack(stack_3);
	
	printf("\n\tAdding Large Numbers Using Stack");
	
	printf("\n\n\tInput operand 1: ");
	scanf("%d", &operand_1);
	while(getchar()!='\n');
	
	printf("\tInput operand 2: ");
	scanf("%d", &operand_2);
	while(getchar()!='\n');
	
	
	getOperandStack(stack_1, operand_1, &tos_1);
//	displayStack(stack_1, tos_1);
//	printf("\n\tThe TOS is %d", tos_1);
	getOperandStack(stack_2, operand_2, &tos_2);
	
	addStacks(stack_1, tos_1, stack_2, tos_2, stack_3, &tos_3);
	
	displayStack(stack_3, tos_3);
	
	return 0;
}

void createStack(int *stack){
	int n;
	for (n = 0; n < SIZE; n++){
		stack[n] = -1; //declare all cells as -1 to signify that it is empty
	}
	
	return;
}

void getOperandStack (int *stack, int operand, int *tos){
	int exponent, temp = operand, n = *tos;
	
	while (operand > 0){ //getting the leftmost digit
		exponent = 1;
		temp = operand;
		while (temp > 10){
			temp /= 10;
			exponent *= 10;
		}
		
		operand = operand % exponent; //remove leftmost digit
		n++; //since tos was declared as -1, increment before adding to stack
		stack[n] = temp; //pushing the leftmost digit		
//		printf("\noperand = %d, temp = %d, tos = %d", operand, temp, n);
	}
	*tos = n;
//	printf("\n\ttos = %d", *tos);
	return;
}

void addStacks(int *stack_1, int tos_1, int *stack_2, int tos_2, int *stack_3, int *tos_3){
	int n = *tos_3;
	int operand_1 = 0, operand_2 = 0, carry = 0, sum = 0;
	
	while (carry != 0 || tos_1 >= 0 || tos_2 >= 0){ //while there are still things to add
		if (tos_1 >= 0){
			operand_1 = stack_1[tos_1]; //get the top of the stack
			tos_1--;
		}
		if (tos_2 >= 0){
			operand_2 = stack_2[tos_2];
			tos_2--;
		}
		sum = operand_1 + operand_2 + carry; //add the two digits as well as the carry to get the sum
			
		n++;
		stack_3[n] = sum % 10; //push the ones digit
		
		operand_1 = 0; //reset the values
		operand_2 = 0;
		sum = 0;
		carry = sum / 10; //set the new carry
		printf("\n\ttos %d %d %d\n", tos_1, tos_2, n);
	}
	
	*tos_3 = n; //set new value of the tos of the sum stack
	return;
}

void displayStack(int *stack, int tos){ 
	printf("\n\n\tThe sum is ");

	for (tos; tos >= 0; tos--){
		printf("%d", stack[tos]);
	}
	
	return;
}
