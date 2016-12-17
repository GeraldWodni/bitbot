\ Use controller to drive bot
\ D-Pad: drive / rotate 1/4 speed
\ D-Pad + A: 1/2  speed
\ D-Pad + B: full speed
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

\ both motors
: bm ( n-speed -- )
    dup lm rm ;

: nes-drive ( -- )
    motor-on
    begin
        nes> >r
        1 r@ $3 and 5 + lshift \ calculate speed [None: 32, A: 64, B: 128, A+B: 256]

        $00.00.20 buffer!
        0 over 1- color     \ set color according to speed
        2 2 pos 2 4 line    \ draw arrow ( vertical-line )
        1 3 pos 3 3 line    \ horizontal line
        0 2 pos 4 2 line    \ triangle dots
        r> $F0 and case
            $10 of          bm endof  \ forward
            $20 of cw cw    negate bm endof        \ backward ( mirror arrow )
            $40 of cw cw cw dup negate lm rm endof \ left   ( rotate arrow )
            $80 of cw       dup negate rm lm endof \ right
            drop 0 bm \ drop speed and stop
        endcase
        flush
    key?
    until
    motor-off ;

nes-drive
