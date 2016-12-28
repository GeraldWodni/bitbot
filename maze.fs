compiletoflash

#include smile.fs

\ maze angle
0 variable angle

\ both motors
: bm ( n-left n-right u-duration -- )
    >r rm lm r> ms 0 rm 0 lm ;

\ draw maze
: maze ( -- )
    $00.00.1F buffer! \ background

    0 0 pos         \ maze background
    $1F.1F.00 color
    10 dup rect

    0 0 pos         \ outer border
    $27.00.00 color
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

    8 4 pos dot

    $00.7F.00 color \ target
    3 3 pos dot ;

\ angle sensitive movement
: dir+! ( n -- )
    angle @ case
        0 of toy +! endof
        1 of tox +! endof
        2 of negate toy +! endof
        3 of negate tox +! endof
    endcase ;

: angle+! ( n -- )
    angle @ +   \ add new offset
    4 +         \ ensure it is positive
    4 mod       \ clamp
    angle ! ;   \ store

\ forward
: fwd ( -- )
    2 3 xy@ $27.00.00 d<> if    \ wall in front?
        -1 dir+!        \ nope -> move ( logically )
         55 80 80 bm    \ move ( physically )
    then ;

\ backward
: bwd ( -- )
    2 1 xy@ $27.00.00 d<> if    \ wall in front?
         1 dir+!
        -55 -80 80 bm
    then ;

: arrow ( -- )
    tox @ toy @         \ save offset
    $00.00.00 buffer!
    0 tox ! 0 toy !
    2 4 pos dot
    1 3 pos 3 3 line
    toy ! tox !         \ restore offset
    flush ;

\ left & right
: lft ( -- )
    arrow
    -55  80 550 bm  \ rotate
     1 angle+!  ;   \ offset angle

: rgt ( -- )
    arrow
     55 -80 550 bm  \ rotate
    -1 angle+!  ;   \ offset angle

\ drive in maze
\ : drive ( -- )
\     begin
\         maze flush
\         false
\         key case
\             [CHAR] w of fwd endof
\             [CHAR] s of bwd endof
\             [CHAR] a of lft endof
\             [CHAR] d of rgt endof
\             bl of drop true endof
\         endcase
\     until ." done" ;
\ drive

: nes-drive ( -- )
    1 tox ! 1 toy !         \ reset position
    motor-on
    begin
        nes> >r
        \ 1 r@ $3 and 5 + lshift \ calculate speed [None: 32, A: 64, B: 128, A+B: 256]

        r@ $F0 and case
            $10 of fwd endof \ forward
            $20 of bwd endof \ backward ( mirror arrow )
            $40 of lft endof \ left   ( rotate arrow )
            $80 of rgt endof \ right
        endcase

        maze
        angle @ 0 ?do cw loop
        $7F.7F.00 12 rgb-px! flush

        tox @ -1 = toy @ -1 = and if
            \ $3F.3F.00 leds
            smile
            begin nes> $08 = until \ wait for start press
            1 tox ! 1 toy !         \ reset position
        then

        \ wait for key-release
        r> $F0 and if
            begin nes> 0= until
        then
    key?
    until
    motor-off ;
\ nes-drive

: init init nes-drive ;
