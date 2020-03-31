# calculator V2

from colorama import init
from colorama import Fore, Back, Style

# use Colorama to make Termcolor work on Windows too
init()

print(Back.GREEN)

what = input ("Что делаем?(+,-):")

a = float(input("Введите первое число:"))
b = float(input("Введите второе число:"))

if what == "+":
    c = a+b
    print("Результат!"+str(c))
elif what == "-":
    c = a-b
    print("Результат"+str(c))
else:
    print("Выбрана не верная операция!")
