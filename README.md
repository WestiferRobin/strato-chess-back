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
    - Proxy Tables
        - Need to add some proxy tables per session
        - Maybe update the session id attribues and keep a table to the REAL values

## Game Controller
CLASSIC:
    POST: Create ClassicGame (ClassicView)
        - Request
            - White: Player
            - Black: Player
            - Scenarios:
                - UserPlayer vs PrismPlayer
                - PrismPlayer vs PrismPlayer
                - UserPlayer vs UserPlayer
        - Response
            - View
                - WhiteID
                - BlackID
                - BoardID
            - SessionID
    GET: View ClassicGame
        - Request
            - SessionID
        - Response
            - WhiteID
            - BlackID
            - BoardID
    DELETE: Delete Game
        - Request
            - SessionID
        - Response
            - HTTP status 204

## Board Controller
CLASSIC:
    POST: View Classic Game Board
        - Request
            - SessionID
            - BoardID
        - Response
            - BoardDto
    PUT: UserPlayer vs PrismPlayer updates Classic Game Board
        - Request
            - SessionID
            - BoardID
            - PlayerID
            - Command: 
                - Piece: ex.) Rook R for white and r for black
                - CurrentPosition: A:1
                - TargetPosition: A:5
        - Response
            - PlayerId
            - BoardId

## Player Controller
CLASSIC:
    POST: Sheet
        - Request:
            - SessionId
            - PlayerId
        - Response:
            - PlayerSheetDto
    POST: Run Command
        - Request:
            - PlayerCommandDto
        - Response:
            - PlayerId
            - BoardId
