compiletoflash

\ draw maze
: maze ( -- )
    $00.00.3F buffer! \ background

    0 0 pos         \ maze background
    $1F.1F.00 color
    10 dup rect

    0 0 pos         \ outer border
    $3F.00.00 color
    9 0 line
    9 9 line
    0 9 line
    0 0 line

    2 9 pos         \ main sepp
    2 2 line
    4 2 line
    4 4 line
    6 4 line
    6 2 line
    7 2 line

    4 5 pos         \ extension
    4 6 line

    4 8 pos         \ bottom
    5 8 line

    6 6 pos         \ right side
    7 6 line
    7 7 line

    8 4 pos dot ;

\ drive in maze
: drive ( -- )
    begin
        maze flush
        false
        key case
            [CHAR] w of  1 toy +! endof
            [CHAR] s of -1 toy +! endof
            [CHAR] a of  1 tox +! endof
            [CHAR] d of -1 tox +! endof
            bl of drop true endof
        endcase
    until ." done" ;
drive
