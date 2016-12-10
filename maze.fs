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

\ forward
: fwd ( -- )
    2 1 xy@ $3F.00.00 d<> if    \ wall in front?
         1 toy +! \ nope -> move
    then ;

\ backward
: bwd ( -- )
    2 3 xy@ $3F.00.00 d<> if    \ wall in front?
        -1 toy +!
    then ;

\ left & right (will not be used in final version, just for testing
: lft ( -- )
    1 2 xy@ $3F.00.00 d<> if    \ wall in front?
         1 tox +!
    then ;
: rgt ( -- )
    3 2 xy@ $3F.00.00 d<> if    \ wall in front?
        -1 tox +!
    then ;

\ drive in maze
: drive ( -- )
    begin
        maze flush
        false
        key case
            [CHAR] w of fwd endof
            [CHAR] s of bwd endof
            [CHAR] a of lft endof
            [CHAR] d of rgt endof
            bl of drop true endof
        endcase
    until ." done" ;
drive
