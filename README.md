# c-sharp-console-game-1

## Synopsis

The project is a game which developed on the c# console. It is played on two 3*3 boards: Computer's board and player's board.At the beginning, computer shapes its board placing random X marks. Each square is filled by X or left

empty. The objective of the game is to create the same board with the computer in minimum number of rounds.In each round, a 1*2 small random piece is generated in order to be placed by the player on the player's

board.Player can rotate this piece as many times as he likes, then place it wherever he wants. The piece should not be placed out of the board. Otherwise, an error occurs. Each error, rotation and placement takes one 

round. After the placement, a new round starts.

    
    Game playing commands are as follows:

    Placement commands:

          YX: Place the small piece starting from row Y and column X. 

                (Y and X values can be 1, 2 or 3) 

    Rotation commands:

          41: Rotate the small piece 90 degrees clockwise. 

          42: Rotate the small piece 90 degrees anticlockwise. 

When the small piece is being placed, XOR operation is applied with the existing player's board.
When the same board is formed by the player the game is over. The score is calculated as follows:

          Score = 200 - 10 * (the number of rounds)

Otherwise, the next round begins and the game continues.

