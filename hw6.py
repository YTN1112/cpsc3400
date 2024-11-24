# Homework 6
import re

# REGULAR EXPRESSIONS

# Write patterns for regular expressions a-d here.
# You must use a single regular expression for each item.
# For part d, also include a substitution string.

a = re.compile(r"^(?=.*qu)(?=.*zz)[A-Za-z]+$")

b = re.compile(r"^(\([0-9]{3}\)\s?[0-9]{3}-[0-9]{4}|[0-9]{3}-[0-9]{3}-[0-9]{4})$")

c = re.compile(r"^\[(([1-9][0-9]*;\s*)*[1-9][0-9]*)\]$")

d = re.compile(r"^([^\?:\s]+[^\?:]*?)\s*\?\s*([^\?:\s]+[^\?:]*?)\s*:\s*([^\?:\s]+[^\?:]*)$")
# Matching is most imporant part.
# LOOK AHEAD NO ALLOWED, please use a differnt stragey.
# ___ ? ____ : ____
# you need to remember what you need to exlcude what you don't want.
# What do you not want for each.
# The subsittion needs 3 groups.
# There can any number of spaces(/S is allowed)
# What I need to exclude on each part and follow that from there

subStr = r"\2 if \1 else \3"   # Place what you want to substitute (used in sub)

# TESTS

print("----Part a tests that match:")
print(a.search("aquapizza"))

print("----Part a tests that do not match:")
print(a.search("aquataco"))

print("----Part b tests that match:")
print(b.search("(555) 123-4567"))

print("----Part b tests that do not match:")
print(b.search("(555)-123-4567"))

print("----Part c tests that match:")
print(c.search("[1; 4; 6; 12; 3; 70]"))
print(c.search("[1; 4; 6; 12;     3; 70]"))

print("----Part c tests that do not match:")
print(c.search("[1; 4; 25; 12; 3; 70;]"))

print("----Part d tests:")
print(d.sub(subStr, "a < b ? x ? : 3 + y ? "))

print(d.sub(subStr,"a < b ? x : 3 + y")) # Output: "x if a < b else 3 + y"
print(d.sub(subStr,"a : b ? x : 3 + y")) # Output: "a : b ? x : 3 + y"
print(d.sub(subStr,"a < b ? x ? y : 3 + y")) # Output: "a < b ? x ? y : 3 + y"
print(d.sub(subStr,"a < b ? x : 3 + y ?")) # Output: "a < b ? x : 3 + y ?"
print(d.sub(subStr,"a < b ? x : 3 + y :")) # Output: "a < b ? x : 3 + y :"
print(d.sub(subStr,"a < b ?        : 456")) # Output: "x if a < b else 3 + y"
print(d.sub(subStr,"a < b ? x : y : 3")) # Output: "a < b ? x : y : 3"
print(d.sub(subStr,"a < b ? x : y : 3")) # Output: "a < b ? x : y : 3"