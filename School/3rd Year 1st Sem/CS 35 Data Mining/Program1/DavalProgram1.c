/*
Day 1 progress: Made a function that creates a new csv file and copy the contents of the original csv file into it. Next step is to alter the contents of the new file.
*/
#include <stdio.h>
#include <string.h>
#include<stdbool.h>

void displayCSV(FILE *file) {
    char line[256];

    rewind(file);
    // header
    if (fgets(line, sizeof(line), file) != NULL) {
        char *token = strtok(line, ",");
        while (token != NULL) {
            printf("%s\t", token);
            token = strtok(NULL, ",");
        }
        printf("\n");
    }

    // row
    while (fgets(line, sizeof(line), file) != NULL) {
        char *token = strtok(line, ",");
        while (token != NULL) {
            printf("%s\t", token);
            token = strtok(NULL, ",");
        }
        printf("\n");
    }
    rewind(file);
    return;
}

void copyCSV(FILE *inputFile, FILE *outputFile) {
    char buffer[256];

    rewind(inputFile);
    rewind(outputFile);
    while (fgets(buffer, sizeof(buffer), inputFile) != NULL) {
        fputs(buffer, outputFile);
    }
    rewind(inputFile);
    rewind(outputFile);
    return;
}

bool hasMissingData(const char *row) {
    bool missing = false;
    size_t rowLength = strlen(row);
    bool inField = false;

    for (size_t i = 0; i < rowLength; i++) {
        if (row[i] == ',') {
            if (!inField) {
                // consecutive commas is empty field
                missing = true;
            }
            inField = false;
        } else {
            inField = true;
        }
    }
    if (!inField || row[rowLength - 2] == ',') {
        missing = true;
    }
    return missing;
}

void removeRows(FILE *file) {
    // Create a temporary file
    FILE *tempFile = fopen("temp_remove_rows.csv", "w+");
    if (!tempFile) {
        printf("Error creating temporary file\n");
        return;
    }

    char line[256];

    // Rewind the input file
    rewind(file);

    // Copy rows without missing data to the temporary file
    while (fgets(line, sizeof(line), file) != NULL) {
        if (!hasMissingData(line)) {
            fputs(line, tempFile);
        }
    }


    // Close both files
    fclose(file);
    fclose(tempFile);

    // Delete the original file
    remove("remove_rows_dataset.csv");

    // Rename the temporary file to the original filename
    rename("temp_remove_rows.csv", "remove_rows_dataset.csv");

}

double custom_atof(const char *str) {
    double result = 0.0;
    double fraction = 0.1;
    bool isNegative = false;
    bool hasFraction = false; // Flag to track the presence of a fractional part
    int decimalPosition = 0;   // Position of the decimal point

    // Handle the sign
    if (*str == '-') {
        isNegative = true;
        str++;
    }

    // Parse the integer part and fractional part
    while (*str != '\0') {
        if (*str >= '0' && *str <= '9') {
            if (!hasFraction) {
                result = result * 10.0 + (*str - '0');
            } else {
                result += (*str - '0') * fraction;
                fraction *= 0.1;
            }
        } else if (*str == '.') {
            hasFraction = true;
        } else {
            // Handle invalid characters
            // Optionally, you can add error handling here.
            // For simplicity, this example ignores invalid characters.
        }

        // Move to the next character
        str++;
    }

    // Apply the sign if necessary
    if (isNegative) {
        result = -result;
    }

    printf("\nresult %f", result);
    return result;
}

double calculateColumnAverage(FILE *file, int columnIndex) {
    char line[256];
    double sum = 0.0;
    double count = 0;

    rewind(file);
    if (fgets(line, sizeof(line), file) != NULL) {
        // discard header
    }

    // Read data from the column and calculate the sum and count
    while (fgets(line, sizeof(line), file) != NULL) {
        char *token = strtok(line, ",");
        int column = 0;
        while (token != NULL) {
            if (column == columnIndex) {
                double value = custom_atof(token);
                sum += value;
                count++;
            }
            token = strtok(NULL, ",");
            column++;
        }
    }

    printf("\nsum %f count %f\n", sum, count);
    return (sum/count); // Calculate and return the average
}

// Function to fill missing data with the column average
void fillAverage(FILE *inputFile, FILE *outputFile) {
    char buffer[256];

    // Rewind both files
    rewind(inputFile);
    rewind(outputFile);

    // Copy the header from the input file to the output file
    if (fgets(buffer, sizeof(buffer), inputFile) != NULL) {
        fputs(buffer, outputFile);
    }

    // Determine the number of columns in the header
    int numColumns = 0;
    char *token = strtok(buffer, ",");
    while (token != NULL) {
        numColumns++;
        token = strtok(NULL, ",");
    }
    // Create an array to store the column averages
    double columnAverages[numColumns];

    // Calculate and store the column averages
    for (int i = 0; i < numColumns; i++) {
        columnAverages[i] = calculateColumnAverage(inputFile, i);
        printf("\ncolumn average of %d is %f", i, columnAverages[i], numColumns);
    }

    // Process data rows and fill missing values with column averages
    while (fgets(buffer, sizeof(buffer), inputFile) != NULL) {
        char *token = strtok(buffer, ",");
        int column = 0;
        while (token != NULL) {
            if (strlen(token) == 0) {
                // Missing data found, fill with the column average
                fprintf(outputFile, "%.2lf", columnAverages[column]);
            } else {
                // Non-empty data, copy it as is
                fputs(token, outputFile);
            }

            // Add a comma unless it's the last column
            if (column < numColumns - 1) {
                fputs(",", outputFile);
            }

            token = strtok(NULL, ",");
            column++;
        }

        // End the line
        fputs("\n", outputFile);
    }
}


int main() {
    FILE *inputFile = fopen("dataset.csv", "r");
    if (!inputFile) {
        printf("Error opening input file\n");
        return 1;
    }

    FILE *outputFile1 = fopen("remove_rows_dataset.csv", "w+");
    if (!outputFile1) {
        printf("Error opening output file 1\n");
        fclose(inputFile);
        return 1;
    }
    FILE *outputFile2 = fopen("fill_average_dataset.csv", "w+");
    if (!outputFile2) {
        printf("Error opening output file 2\n");
        fclose(inputFile);
        fclose(outputFile1);
        return 1;
    }
    FILE *outputFile3 = fopen("fill_interpolation_dataset.csv", "w+");
    if (!outputFile3) {
        printf("Error opening output file 3\n");
        fclose(inputFile);
        fclose(outputFile1);
        fclose(outputFile2);
        return 1;
    }
    FILE *outputFile4 = fopen("fill_constant_dataset.csv", "w+");
    if (!outputFile4) {
        printf("Error opening output file 4\n");
        fclose(inputFile);
        fclose(outputFile1);
        fclose(outputFile2);
        fclose(outputFile3);
        return 1;
    }

    printf("Original CSV:\n");
    displayCSV(inputFile);

    copyCSV(inputFile, outputFile1);
    //copyCSV(inputFile, outputFile2);
    copyCSV(inputFile, outputFile3);
    copyCSV(inputFile, outputFile4);

    // processes
    removeRows(outputFile1);
    printf("\n\nRemoved Rows CSV:\n");
    outputFile1 = fopen("remove_rows_dataset.csv", "r+");
    if (!outputFile1) {
        printf("Error reopening the updated file for reading\n");
        return;
    }
    displayCSV(outputFile1);

    fillAverage(inputFile, outputFile2);
    printf("\n\nFill with Average CSV:\n");
    displayCSV(outputFile2);

    fclose(inputFile);
    fclose(outputFile1);
    fclose(outputFile2);
    fclose(outputFile3);

    return 0;
}
