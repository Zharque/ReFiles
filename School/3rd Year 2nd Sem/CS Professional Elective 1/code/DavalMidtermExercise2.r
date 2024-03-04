#Daval MidtermExercise2
my.num <- c(3, 9, 13, 39, 75, 123) # 1
my.num <- my.num * 4 # 2
my.char <- c("z", "h", "a", "r", "q") # 3
both <- c(my.num, my.char) # 4
length(both) # 5) the length is 11
class(both) # 6) the class is character
# both / 3 # 7) Error and Execution halted
x <- c(1, 2, 3, 4, 5, 6) # 8
y <- c(10, 20, 30, 40, 50) # 9
# x + y # 10) the 6th element of x is added to the 1st element of y
y <- c(y, 60) # 11
x + y # 12) 11 22 33 44 55 66
x * y # 13) each element of x is multiplied to the corresponding element of y
