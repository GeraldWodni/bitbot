\ Draw non-orthogonal lines
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

\ note: this file is a draft. I discarded the idea of non-orthogonal lines, as they would be barely used and waste a lot of code space.
\ if you are eager, feel free to finish this and send me a pull-request ;)

compiletoflash

\ : line ( x1 y1 x2 y2 -- )
\     2over 2over     ( x1 y1 x2 y2  x1 y1 x2 y2  )
\     rot -           ( x1 y1 x2 y2  x1 x2 dy     )
\     -rot swap -     ( x1 y1 x2 y2  dy dx        )
\     abs swap abs    ( x1 y2 x2 y2 |dx| |dy|     )
\     > if
\         ." x"
\     else
\         ." y"
\     then
\     ;

: ~~ .s cr ;

: clearstack depth 0 ?do drop loop ;

: line ( x1 x2 y1 y2 -- )
    ~~
    2over swap - abs        ( x1 x2 y1 y2  dx )
    ~~
    >r 2dup swap - abs r>   ( x1 x2 y1 y2  dy dx )
    ~~
    < if \ move along x
        ." x"
    else \ move along y
        ." y"
        2dup < if \ swap start/end point to move positively
            swap 2swap swap 2swap
        then
        swap 1+ swap \ increment end point
        ~~
        do
            i
            1 rpick . cr
            ~~ . cr
        loop
    then
    ~~
    clearstack
    ;
\ 1 2 5 9 line
1 5 2 9 line
