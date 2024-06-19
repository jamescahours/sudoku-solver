
// insert a two-dimensional array of numbers or convert a string array (faster insertion)
// int[][] example1 = [
//             [7, 0, 2, 0, 5, 0, 6, 0, 0],
//             [0, 0, 0, 0, 0, 3, 0, 0, 0],
//             [1, 0, 0, 0, 0, 9, 5, 0, 0],
//             [8, 0, 0, 0, 0, 0, 0, 9, 0],
//             [0, 4, 3, 0, 0, 0, 7, 5, 0],
//             [0, 9, 0, 0, 0, 0, 0, 0, 8],
//             [0, 0, 9, 7, 0, 0, 0, 0, 5],
//             [0, 0, 0, 2, 0, 0, 0, 0, 0],
//             [0, 0, 7, 0, 4, 0, 2, 0, 3],
//         ];

// string[] example2 = [
//     "000820940",
//     "802096000",
//     "790000800",
//     "007000051",
//     "005000000",
//     "428751000",
//     "089305100",
//     "000060500",
//     "500084070"
// ];

string[] board = [
    "", // row 1
    "", // row 2
    "", // row 3
    "", // row 4
    "", // row 5
    "", // row 6
    "", // row 7
    "", // row 8
    ""  // row 9
];

SudokuSolver.Solve(board);

public class SudokuSolver {
    private static int GridSize = 9;

    private static bool IsNumberInRow(int[][] board, int number, int row) {
        return board[row].Contains(number);
    }

    private static bool IsNumberInColumn(int[][] board, int number, int column) {
        for (int i = 0; i < GridSize; i++) {
            if (board[i][column] == number) {
                return true;
            }
        }
        return false;
    }

    private static bool IsNumberInBox(int[][] board, int number, int row, int column) {
        var localBoxRowStart = row - row % 3;
        var localBoxColumnStart = column - column % 3;

        for (int i = localBoxRowStart; i < localBoxRowStart + 3; i++) {
            for (int j = localBoxColumnStart; j < localBoxColumnStart + 3; j++) {
                if (board[i][j] == number) {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool IsValidPlacement(int[][] board, int number, int row, int column) {
        return !IsNumberInBox(board, number, row, column) &&
            !IsNumberInColumn(board, number, column) &&
            !IsNumberInRow(board, number, row);
    }

    public static bool Solve(string[] numberStrings) {
        var board = ConvertToBoard(numberStrings);
        return Solve(board);
    }

    public static bool Solve(int[][] board) {
        Console.WriteLine("Solving board...");
        LogBoard(board);

        if (SolveBoard(board)) {
            Console.WriteLine("Solved board:");
            LogBoard(board);
            return true;
        } else {
            Console.WriteLine("No solution found.");
            return false;
        }
    }

    public static bool SolveBoard(int[][] board) {
        for (int row = 0; row < GridSize; row++) {
            for (int col = 0; col < GridSize; col++) {
                if (board[row][col] == 0) { // if zone is empty, attempt each number 1-9
                    for (int att = 1; att <= GridSize; att++) {
                        if (IsValidPlacement(board, att, row, col)) {
                            board[row][col] = att;
                            
                            if (SolveBoard(board)) {
                                return true;
                            }
                            board[row][col] = 0;
                        }                        
                    }
                    return false;
                }
            }
        }
        return true;
    }

    public static void LogBoard (int[][] board){
        for (int row = 0; row < GridSize; row++) {
            if (row != 0 && row % 3 == 0) {
                Console.WriteLine("-----------");
            }
            for (int col = 0; col < GridSize; col++) {
                if (col != 0 && col % 3 == 0){
                    Console.Write("|" + board[row][col]);
                } else {
                    Console.Write(board[row][col]);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static int[][] ConvertToBoard(string[] numberStrings) {
        
        var board = new int[GridSize][];
        for (int row = 0; row < GridSize; row++) {
            board[row] = new int[GridSize];
            for (int col = 0; col < GridSize; col++) {
                board[row][col] = int.Parse(numberStrings[row].Substring(col, 1));
            }
        }
        return board;
    }

}
