\ Turtle graphics for the bitkanone
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

\ turtle position and color
0 variable tx
0 variable ty
$20.20.20 2variable tc

\ set turtle position
: pos ( x y -- )
    ty ! tx ! ;

\ set turtle color
: color ( d-rgb -- )
    tc 2! ;

\ draw dot
: dot ( -- )
    tc 2@ tx @ ty @ xy! ;
    \ cr ." DOT:" tx @ . ty @ . ." C:" tc 2@ hex d. decimal ;

\ order 2 number descending, increment higher
: desc1+ ( u1 u2 -- u3 u4 )
    2dup < if swap then swap 1+ swap ;

\ draw orthogonal line
: line ( to-x to-y -- )
    2dup \ save end point
    dup ty @ = if
        \ horizontal line
        drop
        tx @ desc1+ ?do
            i tx ! dot
        loop
    else
        \ vertical line
        nip
        ty @ desc1+ ?do
            i ty ! dot
        loop
    then pos ; \ save new position

: rect ( to-x to-y -- )
    2dup
        ." TODO: imlement me!"
    pos ;
