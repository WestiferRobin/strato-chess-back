# strato-chess-back

## TODO:
- Make ClassicView work with backend
    - ClassicView is a Classic game of chess between two people
    - Each Classic game has a session id attached
        - 2 players
        - 1 board
        - relationship is chess pieces that can move according to chess
        - each player moves on the ui but will have the notation
        - the notation will update the database and will return to the board using the session id
    - Flow
        - Get Board by sessionId
        - Get Player by sessionId and playerId
            - Player POST move
            - returns with history move and enemys move
            - repeat until checkmate