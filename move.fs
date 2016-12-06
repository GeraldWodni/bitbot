compiletoflash

: move ( n-left n-right -- )
    rm lm
    motor-on
    200 ms
    motor-off ;

: forward ( -- )
    100 100 move ;

: backward ( -- )
    -100 -100 move ;

: left
    -50 50 move ;

: right
    50 -50 move ;
