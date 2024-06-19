Given a board of 9x9 it will recursively attempt each number for each slot until all numbers fit the board

# To Use
- Insert each row of the sudoku board as strings
```c#
string[] board = [
"000820940",
"802096000",
"790000800",
"007000051",
"005000000",
"428751000",
"089305100",
"000060500",
"500084070" ];
```
- Run `dotnet run`

- Should output
```c#
153|827|946
842|596|713
796|413|825
-----------
937|648|251
615|239|487
428|751|639
-----------
289|375|164
374|162|598
561|984|372
```
