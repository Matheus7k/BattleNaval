using System.Data.Common;
using battleNaval.Entity;

internal class Program
{
    private static void Main(string[] args)
    {
        int[,] aux = new int[20, 20];

        aux[0, 3] = 5;
        //aux[0, 6] = 5;
        //aux[0, 7] = 5;
        //aux[19, 17] = 5;
        //aux[0, 9] = 5;

        Board board = new Board();
        Player player = new Player();
        Destroyer destroyer = new();
        Submarine submarine = new();
        AircraftCarrier carrier = new();

        //Console.WriteLine(VerifyRowColumn(board, 5, 17, destroyer, "vertical", aux));
        //Console.WriteLine(VerifyRowColumn(board, 0, 4, carrier, "horizontal", aux));
        //Console.WriteLine(VerifyRowColumn(board, 0, 19, carrier, "horizontal", aux));

        Console.WriteLine(VerifyRowToRight(board, 0, 0, carrier, "horizontal", aux));

        if (VerifyRowToRight(board, 0, 2, carrier, "horizontal", aux) == 0)
        {
            Console.WriteLine(VerifyRowToLeft(board, 0, 0, carrier, "horizontal", aux));
        }
    }

    static public int VerifyRowToRight(Board board, int row, int column, Ship ship, string orientation, int[,] aux)
    {
        // Verificação da horizontal da esquerda para a direita;
        if (orientation == "horizontal")
        {
            // Verifica se cabe na horizontal para a direita;
            if (column + ship._life - 1 <= board._board.GetLength(1) - 1)
            {
                // Percorre as colunas;
                for (int coluna = column; coluna < column + ship._life - 1; coluna++)
                {
                    // Verifica em cima, em baixo e uma posição a frente;
                    if (row == 0)
                    {
                        if (aux[row + 1, coluna] != 0 || aux[row, coluna + 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (row == 19)
                    {
                        if (aux[row - 1, coluna] != 0 || aux[row, coluna + 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (aux[row - 1, coluna] != 0 || aux[row + 1, coluna] != 0 || aux[row, coluna + 1] != 0)
                        {
                            return 0;
                        }
                    }
                }

                // Verifica diagonal frente e tras
                if (row == 0)
                {
                    if (aux[row, column + ship._life] != 0 || aux[row + 1, column + ship._life] != 0)
                    {
                        return 0;
                    }
                    else if (aux[row, column - 1] != 0 || aux[row + 1, column - 1] != 0)
                    {
                        return 0;
                    }
                }
                else if (row == 19)
                {
                    if (aux[row, column + ship._life] != 0 || aux[row - 1, column + ship._life] != 0)
                    {
                        return 0;
                    }
                    else if (aux[row, column - 1] != 0 || aux[row - 1, column - 1] != 0)
                    {
                        return 0;
                    }
                }
                else
                {
                    if (aux[row, column + ship._life] != 0 || aux[row + 1, column + ship._life] != 0 || aux[row - 1, column + ship._life] != 0)
                    {
                        return 0;
                    }
                    else if (aux[row, column - 1] != 0 || aux[row + 1, column - 1] != 0 || aux[row - 1, column + ship._life] != 0)
                    {
                        return 0;
                    }
                }

                return 1;
            }

            return 0;
        }

        return 0;
    }

    static public int VerifyRowToLeft(Board board, int row, int column, Ship ship, string orientation, int[,] aux)
    {
        if(orientation == "horizontal")
        {
            if (column - (ship._life - 1) >= 0)
            {
                // Percorre coluna
                for (int coluna = column; coluna > column - (ship._life - 1); coluna--)
                {
                    // Verifica em cima e em baixo
                    if (row == 0)
                    {
                        if (aux[row + 1, coluna] != 0 || aux[row, coluna - 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else if (row == 19)
                    {
                        if (aux[row - 1, coluna] != 0 || aux[row, coluna - 1] != 0)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (aux[row - 1, coluna] != 0 || aux[row + 1, coluna] != 0 || aux[row, coluna -1] != 0)
                        {
                            return 0;
                        }
                    }
                }

                // Verifica diagonal frente e tras
                if (row == 0)
                {
                    if (aux[row, column - ship._life] != 0 || aux[row + 1, column - ship._life] != 0)
                    {
                        return 0;
                    }
                    else if (aux[row, column - 1] != 0 || aux[row + 1, column - 1] != 0)
                    {
                        return 0;
                    }
                }
                else if (row == 19)
                {
                    if (aux[row, column - ship._life] != 0 || aux[row - 1, column - ship._life] != 0)
                    {
                        return 0;
                    }
                    else if (aux[row, column - 1] != 0 || aux[row - 1, column - 1] != 0)
                    {
                        return 0;
                    }
                }
                else
                {
                    if (aux[row, column - ship._life] != 0 || aux[row + 1, column - ship._life] != 0 || aux[row - 1, column - ship._life] != 0)
                    {
                        return 0;
                    }
                    else if (aux[row, column - 1] != 0 || aux[row + 1, column - 1] != 0 || aux[row - 1, column - ship._life] != 0)
                    {
                        return 0;
                    }
                }

                return 2;
            }
        }

        return 0;
    }

    static public int VerifyColumnToDown(Board board, int row, int column, Ship ship, string orientation, int[,] aux)
    {
        // Verifica se cabe na vertical
        if (orientation == "vertical")
        {
            // Verifica se cabe na vertical para baixo
            if (row + ship._life - 1 <= board._board.GetLength(0) - 1)
            {
                // Percorre as linhas
                for(int linha = row; linha < row + ship._life - 1; linha++)
                {
                    // Verifica em cima e em baixo e uma posição a frente
                    if(column == 0)
                    {
                        if (aux[linha,column + 1] != 0 || aux[linha + 1, column] != 0)
                        {
                            return 0;
                        }
                    }
                    else if(column == 19)
                    {
                        if (aux[linha, column - 1] != 0 || aux[linha + 1, column] != 0)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        if (aux[linha, column - 1] != 0 || aux[linha, column + 1] != 0 || aux[linha + 1,column] != 0)
                        {
                            return 0;
                        }
                    }
                }

                // Verifica diagonal frente e tras
                if (column == 0)
                {
                    if (aux[row + ship._life, column] != 0 || aux[row + ship._life, column + 1] != 0) 
                    {
                        return 0;
                    }
                    else if(aux[row - 1, column] != 0 || aux[row - 1, column + 1] != 0){
                        return 0;
                    }
                }
                else if (column == 19)
                {
                    if (aux[row + ship._life, column] != 0 ||  aux[row + ship._life, column - 1] != 0)
                    {
                        return 0;
                    }
                    else if (aux[row - 1, column] != 0 || aux[row - 1, column - 1] != 0) 
                    {
                        return 0;
                    }
                }
                else
                {
                    if(aux[row + ship._life, column] != 0 || aux[row + ship._life, column + 1] != 0 ||  aux[row + ship._life, column - 1] != 0) 
                    {
                        return 0;
                    }
                    else if (aux[row - 1, column] != 0 || aux[row - 1, column - 1] != 0 || aux[row - 1, column + 1] != 0) 
                    {
                        return 0;
                    }
                }

                return 1;
            }

            return 0;
        }

        return 0;
    }

    static public int VerifyColumnToUp(Board board, int row, int column, Ship ship, string orientation, int[,] aux)
    {
        if (orientation == "vertical") 
        {
            // Verifica se cabe na vertical de baixo para cima
            if (row - (ship._life - 1) >= 0)
            {
                // Percorre a linha
                for (int linha = row; linha > row - (ship._life - 1); linha--)
                {
                    // verifica de uma lado e de outro
                    if(column == 0)
                    {
                        if (aux[linha, column + 1] != 0 || aux[linha - 1, column] != 0) 
                        {
                            return 0;
                        }
                    }
                    else if (column == 19) 
                    {
                        if (aux[linha, column - 1] != 0 || aux[linha - 1, column] != 0) 
                        {
                            return 0;
                        }
                    }
                    else 
                    {
                        if(aux[linha, column + 1] != 0 || aux[linha - 1, column] != 0 || aux[linha, column - 1] != 0) 
                        {
                            return 0;
                        }
                    }
                }

                // Verifica diagonal frente e tras
                if (column == 0) 
                {
                    if(aux[row - ship._life, column] != 0 || aux[row - ship._life, column + 1] != 0) 
                    {
                        return 0;
                    }
                    else if(aux[row - 1, column] != 0 || aux[row - 1, column + 1] != 0) 
                    {
                        return 0;
                    }
                }
                else if (column == 19) 
                {
                    if(aux[row - ship._life, column] != 0 || aux[row - ship._life, column - 1] != 0) 
                    {
                        return 0;
                    }
                    else if(aux[row - 1, column] != 0 || aux[row - 1, column - 1] != 0) 
                    {
                        return 0;
                    }
                }
                else 
                {
                    if (aux[row - ship._life, column] != 0 || aux[row - ship._life, column + 1] != 0 || aux[row - ship._life, column - 1] != 0) 
                    {
                        return 0;
                    }
                    else if (aux[row - 1, column] != 0 || aux[row - 1, column + 1] != 0 || aux[row - 1, column - 1] != 0) 
                    {
                        return 0;
                    }
                }
                
                return 2;
            }
        }

        return 0;
    }
}